using APISoftlandAnclaflex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.OE.Interfaces
{
    public interface IOEObject
    {

        public Save save()
        {
            return new Save
            {
                Result = true,
                errorMessage = ""
            };
        }

        public void AsignoaTM<T>(string table, string field, T value, int deepnessLevel)
        {

        }


        public void InstancioObjeto(string tipoOperacion)
        {

        }

        public void CloseObjectInstance()
        {

        }

        public void LimpioGrilla(string table)
        {

        }
        private void ResuelvoValor(dynamic oField, object value)
        {

        }

    }

}
