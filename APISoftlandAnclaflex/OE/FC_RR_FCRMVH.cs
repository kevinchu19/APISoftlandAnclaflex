using APISoftlandAnclaflex.Entities;
using APISoftlandAnclaflex.Helpers;
using APISoftlandAnclaflex.Models;
using APISoftlandAnclaflex.OE.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.OE
{
    public class FC_RR_FCRMVH: IOEObject
    {
        private Type OEType { get; set; }
        private object OEInst { get; set; }
        private object oApplication { get; set; }
        private object oCompany { get; set; }
        private object oWizard { get; set; }

        private object oCurrentStep { get; set; }
        private object oTableWizard { get; set; }
        public object oFieldsWizard { get; private set; }
        private object oInstance { get; set; }
        private object oTable { get; set; }
        private object oRow { get; set; }
        private object oField { get; set; }
        private object oFieldWizard { get; set; }
        public IConfiguration _configuration { get; }

        public FC_RR_FCRMVH(string user, string password, string companyName, IConfiguration configuration) //NO AGREGAR DEPENDENCIAS A OTROS SERVICIOS
        {
            OEType = Type.GetTypeFromProgID("cwlwoe.global");
            OEInst = Activator.CreateInstance(OEType);
            string[] userPassword = new string[] { user, password };
            object[] company = new string[] { companyName };

            oApplication = OEType.InvokeMember("GetApplication", BindingFlags.InvokeMethod, null, OEInst, userPassword);
            oCompany = OEType.InvokeMember("Companies", BindingFlags.GetProperty, null, oApplication, company);
            _configuration = configuration;
        }

        public void InstancioObjeto(string tipoOperacion)
        {
            object[] objetoSoftland = new object[] {"FCRMVH",4, tipoOperacion};
            oWizard = OEType.InvokeMember("GetObject", BindingFlags.InvokeMethod | BindingFlags.Instance, null, oCompany, objetoSoftland);
            oCurrentStep = OEType.InvokeMember("CurrentStep", BindingFlags.GetProperty, null, oWizard, null );
            oTableWizard = OEType.InvokeMember("Table", BindingFlags.GetProperty, null, oCurrentStep, null);

            oFieldsWizard = OEType.InvokeMember("Fields", BindingFlags.InvokeMethod, null, oTableWizard, null);

            oFieldWizard = OEType.InvokeMember("Item", BindingFlags.InvokeMethod, null, oFieldsWizard, new object[] { 1 });//VIRT_CIRCOM
            OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oFieldWizard, new object[] { "0200" });

            oFieldWizard = OEType.InvokeMember("Item", BindingFlags.InvokeMethod, null, oFieldsWizard, new object[] {2}); //VIRT_CIRAPL
            OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oFieldWizard, new object[] { "0200" });

            oFieldWizard = OEType.InvokeMember("Item", BindingFlags.InvokeMethod, null, oFieldsWizard, new object[] {6}); //VIRT_CODCFC
            OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oFieldWizard, new object[] { "NPW" });

            OEType.InvokeMember("MoveNext", BindingFlags.InvokeMethod, null, oWizard, null);
            oInstance = OEType.InvokeMember("NextObject", BindingFlags.GetProperty, null, oWizard, null);

        }

        public void AsignoaTM<T>(string table, T valor, int deepnessLevel)
        {
            object value = new object();

            oRow = null;

            oTable = OEType.InvokeMember("Table", BindingFlags.GetProperty, null, oInstance, null);
            if (deepnessLevel == 1)
            {
                oRow = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTable, new object[] { 1 });
            }
            else
            {
                dynamic oTableHeader = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTable, new object[] { 1 });
                dynamic oTableGrid = OEType.InvokeMember("Tables", BindingFlags.GetProperty, null, oTableHeader, new object[] { table });
                dynamic oRows = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTableGrid, null);
                dynamic count = OEType.InvokeMember("Count", BindingFlags.GetProperty, null, oRows, null);

                oRow = OEType.InvokeMember("Add", BindingFlags.InvokeMethod, null, oRows, new object[] { (int)count + 1 });
            }
        
            Type typeObjeto = valor.GetType();

            System.Reflection.PropertyInfo[] listaPropiedades = typeObjeto.GetProperties();

            foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
            {
                string[] camposAuditoria = { "Fecalt", "Fecmod", "Ultopr", "Oalias","Userid", "Debaja" };
                string[] camposNavigation = {"Pedido","Items"};
                    
                if (camposNavigation.Contains(propiedad.Name) == false &&
                    camposAuditoria.Contains(propiedad.Name.Substring(propiedad.Name.Length - 6)) == false)
                {
                    oField = OEType.InvokeMember("Fields", BindingFlags.GetProperty, null, oRow, new object[] { propiedad.Name });
                    value = propiedad.GetValue(valor, null);
                           
                    resuelvoValor(oField, value);
                }
            }

        }

        public void LimpioGrilla(string table)
        {
            dynamic oTableHeader = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTable, new object[] { 1 });
            dynamic oTableGrid = OEType.InvokeMember("Tables", BindingFlags.GetProperty, null, oTableHeader, new object[] { table });
            dynamic oRows = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTableGrid, null);
            //Limpio grilla
            OEType.InvokeMember("Clear", BindingFlags.InvokeMethod, null, oRows, null);
        }

        public void CloseObjectInstance()
        {
            Marshal.ReleaseComObject(oField);
            Marshal.ReleaseComObject(oRow);
            Marshal.ReleaseComObject(oTable);
            Marshal.ReleaseComObject(oInstance);
            Marshal.ReleaseComObject(oApplication);
            Marshal.ReleaseComObject(oCompany);
            //OEType = null;
        }

        public Save Save()
        {
            string[] sErrorMessage = new string[] { null };
            object result = OEType.InvokeMember("Save", BindingFlags.InvokeMethod, null, oInstance, sErrorMessage);

            if ((bool)result == false && sErrorMessage[0] == null)
            {
                Translate oTranslate = new Translate(_configuration);
                int messageCount = (int)OEType.InvokeMember("MessageCount", BindingFlags.GetProperty, null, oInstance, null);
                int i = 0;
                for (i = messageCount; i >= 1; i--)
                {
                    dynamic oMessages = OEType.InvokeMember("Messages", BindingFlags.GetProperty, null, oInstance, new object[] { i });
                    string description = (string)OEType.InvokeMember("Description", BindingFlags.GetProperty, null, oMessages, null);
                    if (description != "")
                    {
                        sErrorMessage[0] =  oTranslate.traducir(description);
                        //sErrorMessage[0] = description;
                        break;
                    }
                }
            }

            this.CloseObjectInstance();

            return new Save
            {
                Result = (bool)result,
                errorMessage = sErrorMessage[0]
            };


        }

        private void resuelvoValor(dynamic oField, object value)
        {
            if ((bool)OEType.InvokeMember("Readonly", BindingFlags.GetProperty, null, oField, null) == false)
            {
                //try
               // {
                    switch ((int)OEType.InvokeMember("DataType", BindingFlags.GetProperty, null, oField, null))
                    {
                        case 4: case 7: case 9: //Numero
                            if (value != null)
                            {
                                OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oField, new object[] { value });
                            }

                            break;
                        case 8: //Fecha

                            if (value != null)
                            {
                            DateTime dateValue = (DateTime)value;
                                value = dateValue.ToString("yyyyMMdd");
                                OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oField, new object[] { value });
                            }
                            break;
                        default: //string
                            if ((string)value != "null" && (string)value != "NULL" && value != null)
                            {
                                OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oField, new object[] { value });
                            }
                            break;
                    }
                //}

                //catch (Exception e)
                //{
                //    throw new BadRequestException($"Error al completar el campo {OEType.InvokeMember("Name", BindingFlags.GetProperty, null, oField, null)} con el valor {value}: {e.Message}");
                //}

            };
        }
    }
}
