﻿using APISoftlandAnclaflex.Entities;
using APISoftlandAnclaflex.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.MapperHelp
{
	public class TipoProductoResolver : IValueResolver<PedidoItemsDTO, Fcrmvi, string>
	{
		public string Resolve(PedidoItemsDTO source, Fcrmvi destination, string member, ResolutionContext context)
		{
			return source.IdProducto.Split("|")[0].Trim();
		}
	}

	public class TipoProductoResolverPpto : IValueResolver<PresupuestoItemsDTO, Fcrmvi, string>
	{
		public string Resolve(PresupuestoItemsDTO source, Fcrmvi destination, string member, ResolutionContext context)
		{
			return source.IdProducto.Split("|")[0].Trim();
		}
	}
}
