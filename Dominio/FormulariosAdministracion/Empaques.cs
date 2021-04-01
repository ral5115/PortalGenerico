using Dominio.Modelos;
using Infraestructura.CRUD;
using System.Data;

namespace Dominio.FormulariosAdministracion
{
    public class Empaques
    {
        private readonly BDConsultar _BDConsultar = new BDConsultar();
        private readonly BDEmpaques _BDEmpaques = new BDEmpaques();

        public DataSet Consultar()
        {
            return _BDConsultar.Query("Sp_ListadoEmpaques");
        }

        public string Insertar(ModeloEmpaque Modelo)
        {
            if (_BDEmpaques.Sp_ValidarEmpaque(Modelo.NombreEmpaque).Tables[0].Rows.Count > 0)
            {
                return "EXISTE";
            }
            else
            {
                _BDEmpaques.Sp_AlmacenarEmpaques(Modelo.NombreEmpaque, Modelo.Largo, Modelo.Peso,Modelo.Alto,
                    Modelo.Ancho, Modelo.Unidades, Modelo.Ubl);
                return "";
            }
        }

        public void Actualizar(ModeloEmpaque Modelo)
        {
            _BDEmpaques.Sp_ActualizarEmpaques(Modelo.RowId, Modelo.NombreEmpaque, Modelo.Largo, Modelo.Peso, Modelo.Alto,
                    Modelo.Ancho, Modelo.Unidades, Modelo.Ubl);
        }

        public void Eliminar(int RowId)
        {
            _BDEmpaques.Sp_EliminarEmpaques(RowId);
        }


        public ModeloEmpaque EnviarModelo(int RowId)
        {
            DataSet DsGenerico = _BDEmpaques.Sp_BuscarEmpaques(RowId);

            ModeloEmpaque Modelo = new ModeloEmpaque();

            Modelo.RowId = (int)DsGenerico.Tables[0].Rows[0]["RowId"];
            Modelo.NombreEmpaque = DsGenerico.Tables[0].Rows[0]["Descripcion"].ToString();
            Modelo.Largo = DsGenerico.Tables[0].Rows[0]["Largo"].ToString();
            Modelo.Peso = DsGenerico.Tables[0].Rows[0]["Peso"].ToString();
            Modelo.Alto = DsGenerico.Tables[0].Rows[0]["Alto"].ToString();
            Modelo.Ancho = DsGenerico.Tables[0].Rows[0]["Ancho"].ToString();
            Modelo.Unidades = DsGenerico.Tables[0].Rows[0]["Unidades"].ToString();
            Modelo.Ubl = DsGenerico.Tables[0].Rows[0]["Ubl"].ToString();

            return Modelo;
        }
    }
}
