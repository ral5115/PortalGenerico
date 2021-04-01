using Dominio.Modelos;
using Infraestructura.CRUD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.FormulariosAdministracion
{
    public class Bodegas
    {
        private readonly BDConsultar _BDConsultar = new BDConsultar();
        private readonly BDBodegas _BDBodegas = new BDBodegas();

        public DataSet Consultar()
        {
            return _BDConsultar.Query("Sp_ListadoBodegas");
        }

        public void Insertar(ModeloBodega Modelo)
        {
            int Orden = Convert.ToInt32(_BDConsultar.Query("ObtenerUltimaBodega").Tables[0].Rows[0]["Orden"]) + 1;
            var Bodega = Modelo.IdBodega.Split('-');
            _BDBodegas.Sp_AlmacenarBodegas(Orden, Bodega[0], Bodega[1], Bodega[2], Modelo.Correo);
        }

        public void Actualizar(ModeloBodega Modelo)
        {
            var Bodega = Modelo.IdBodega.Split('-');

            int OrdenActual = Convert.ToInt32(_BDBodegas.Sp_BuscarBodegas(Modelo.RowId).Tables[0].Rows[0]["Orden"]);
            var Opcion = string.Empty;

            if (OrdenActual < Modelo.Orden)
            {
                Opcion = "Mayor";
            }
            else
            {
                Opcion = "Menor";
            }

            _BDBodegas.Sp_ActualizarBodegas(Modelo.RowId, Modelo.Orden, Bodega[0], Bodega[1], Bodega[2], Modelo.Correo, Modelo.Activo);

            DataSet ListadoBodegas = _BDBodegas.Sp_BuscarBodegasOrden(OrdenActual, Modelo.Orden, Opcion);

            foreach (DataRow Registro in ListadoBodegas.Tables[0].Rows)
            {
                if (Convert.ToInt32(Registro["RowId"]) != Modelo.RowId)
                {
                    _BDBodegas.Sp_ActualizarBodegas(Convert.ToInt32(Registro["RowId"]), Convert.ToInt32(Registro["NuevoOrden"]),
                  Registro["IdBodega"].ToString(), Registro["Descripcion"].ToString(), Registro["CentroOperacion"].ToString(),
                  Registro["Correo"].ToString(), Convert.ToBoolean(Registro["Activo"]));
                }
            }
        }

        public void Eliminar(int RowId)
        {
            _BDBodegas.Sp_EliminarBodegas(RowId);
        }

        public string ValidarBodega(string IdBodega)
        {
            DataSet DsGenerico = _BDBodegas.Sp_ValidarBodega(IdBodega);

            if (DsGenerico.Tables[0].Rows.Count > 0)
            {
                return "EXISTE";
            }
            return "";

        }

        public ModeloBodega EnviarModelo(int RowId)
        {
            DataSet DsGenerico = _BDBodegas.Sp_BuscarBodegas(RowId);

            ModeloBodega Modelo = new ModeloBodega();

            Modelo.RowId = (int)DsGenerico.Tables[0].Rows[0]["RowId"];
            Modelo.Orden = (int)DsGenerico.Tables[0].Rows[0]["Orden"];
            Modelo.IdBodega = DsGenerico.Tables[0].Rows[0]["Bodega"].ToString();
            Modelo.Correo = DsGenerico.Tables[0].Rows[0]["Correo"].ToString();
            Modelo.Activo = (bool)DsGenerico.Tables[0].Rows[0]["Activo"];

            return Modelo;
        }
    }
}
