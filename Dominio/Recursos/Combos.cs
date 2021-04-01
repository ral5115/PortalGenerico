using Infraestructura.CRUD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace Dominio.Recursos
{
    public class Combos
    {
        private readonly BDConsultar _BDConsultar = new BDConsultar();

        public List<SelectListItem> Obtener()
        {
            List<SelectListItem> Item = new List<SelectListItem>();
            Item.Add(new SelectListItem { Text = "-- Seleccione --", Value = "" });

            return Item;
        }

        public List<SelectListItem> Obtener(string NombreProcedimiento)
        {
            DataSet DsGenercio = _BDConsultar.Query(NombreProcedimiento);
            List<SelectListItem> Item = new List<SelectListItem>();
            Item.Add(new SelectListItem { Text = "-- Seleccione --", Value = "", Selected = true });

            foreach (DataRow Registro in DsGenercio.Tables[0].Rows)
            {
                Item.Add(new SelectListItem { Text = Registro["Descripcion"].ToString(), Value = Registro["RowId"].ToString() });
            }

            return Item;
        }

        public List<SelectListItem> Obtener(string NombreProcedimiento, string RowId)
        {
            if (RowId != string.Empty)
            {
                DataSet DsGenercio = _BDConsultar.Query(NombreProcedimiento);
                List<SelectListItem> Item = new List<SelectListItem>();

                foreach (DataRow Registro in DsGenercio.Tables[0].Rows)
                {
                    if (Registro["RowId"].ToString() == RowId)
                    {
                        Item.Add(new SelectListItem { Text = Registro["Descripcion"].ToString(), Value = Registro["RowId"].ToString(), Selected = true });
                    }
                    else
                    {
                        Item.Add(new SelectListItem { Text = Registro["Descripcion"].ToString(), Value = Registro["RowId"].ToString() });
                    }
                }

                return Item;
            }
            else
            {
                return Obtener("Sp_ListadoEmpaques");
            }
        }

        public List<SelectListItem> ObtenerBodegas(string NombreProcedimiento)
        {
            DataSet DsGenercio = _BDConsultar.Query(NombreProcedimiento);
            List<SelectListItem> Item = new List<SelectListItem>();
            Item.Add(new SelectListItem { Text = "-- Seleccione --", Value = "", Selected = true });

            foreach (DataRow Registro in DsGenercio.Tables[0].Rows)
            {
                Item.Add(new SelectListItem
                {
                    Text = Registro["RowId"].ToString() + "-" +
                           Registro["Descripcion"].ToString() + "-" +
                           Registro["CentroOperacion"].ToString(),
                    Value = Registro["RowId"].ToString() + "-" +
                           Registro["Descripcion"].ToString() + "-" +
                           Registro["CentroOperacion"].ToString()
                });
            }

            return Item;
        }

        public List<SelectListItem> ObtenerBodegas(string NombreProcedimiento, string IdBodega)
        {
            DataSet DsGenercio = _BDConsultar.Query(NombreProcedimiento);
            List<SelectListItem> Item = new List<SelectListItem>();

            foreach (DataRow Registro in DsGenercio.Tables[0].Rows)
            {
                if (Registro["RowId"].ToString() == IdBodega)
                {
                    Item.Add(new SelectListItem
                    {
                        Text = Registro["RowId"].ToString() + "-" +
                          Registro["Descripcion"].ToString() + "-" +
                          Registro["CentroOperacion"].ToString(),
                        Value = Registro["RowId"].ToString() + "-" +
                          Registro["Descripcion"].ToString() + "-" +
                          Registro["CentroOperacion"].ToString(),
                        Selected = true
                    });
                }
                else
                {
                    Item.Add(new SelectListItem
                    {
                        Text = Registro["RowId"].ToString() + "-" +
                         Registro["Descripcion"].ToString() + "-" +
                         Registro["CentroOperacion"].ToString(),
                        Value = Registro["RowId"].ToString() + "-" +
                         Registro["Descripcion"].ToString() + "-" +
                         Registro["CentroOperacion"].ToString()
                    });
                }
            }
            return Item;
        }

        public List<SelectListItem> ObtenerOrden(string NombreProcedimiento, string IdBodega)
        {
            DataSet DsGenercio = _BDConsultar.Query(NombreProcedimiento);
            List<SelectListItem> Item = new List<SelectListItem>();

            foreach (DataRow Registro in DsGenercio.Tables[0].Rows)
            {
                if (Registro["RowId"].ToString() == IdBodega)
                {
                    Item.Add(new SelectListItem
                    {
                        Text = Registro["Orden"].ToString(),
                        Value = Registro["Orden"].ToString(),
                        Selected = true
                    });
                }
                else
                {
                    Item.Add(new SelectListItem
                    {
                        Text = Registro["Orden"].ToString(),
                        Value = Registro["Orden"].ToString()
                    });
                }
            }
            return Item;
        }
    }
}
