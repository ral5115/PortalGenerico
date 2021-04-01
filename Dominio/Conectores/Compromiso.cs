using Dominio.Recursos;
using Infraestructura;
using Infraestructura.CRUD;
using System;

namespace Dominio.Conectores
{
    public class Compromiso
    {
        private readonly BDPedidos _BDPedidos = new BDPedidos();
        private readonly GenerarDataSet _GenerarDataSet = new GenerarDataSet();
        private readonly Infraestructura.Ws_GT_Real.wsGenerarPlano _Importar = new Infraestructura.Ws_GT_Real.wsGenerarPlano();

        public void Importar(string OrderId, string CampoLlave, string Requisicion, string Barra, string BodegaSalida, string RowId)
        {
            var Ruta = Configuraciones.RutaPlanosReal;

            var RequisicionSplit = Requisicion.Split('-');

            var Xml = "<MyDataSet>" + Environment.NewLine;

            Xml += "<Inicial>" + Environment.NewLine;
            Xml += "<F_CIA>001</F_CIA>" + Environment.NewLine;
            Xml += "</Inicial>" + Environment.NewLine;

            Xml += "<Compromisos>" + Environment.NewLine;
            Xml += "<F_CIA>001</F_CIA>" + Environment.NewLine;
            Xml += "<f440_id_co>" + RequisicionSplit[0] + "</f440_id_co>" + Environment.NewLine;
            Xml += "<f440_id_tipo_docto>" + RequisicionSplit[1] + "</f440_id_tipo_docto>" + Environment.NewLine;
            Xml += "<f440_consec_docto>" + RequisicionSplit[2] + "</f440_consec_docto>" + Environment.NewLine;
            Xml += "<f441_codigo_barras>" + Barra + "</f441_codigo_barras>" + Environment.NewLine;
            Xml += "<f441_id_bodega>" + BodegaSalida + "</f441_id_bodega>" + Environment.NewLine;
            Xml += "<f441_cant_base>1</f441_cant_base>" + Environment.NewLine;
            Xml += "<f441_id_bodega_ent>02201</f441_id_bodega_ent>" + Environment.NewLine;
            Xml += "<f441_cant_por_remisionar_base>1</f441_cant_por_remisionar_base>" + Environment.NewLine;
            Xml += "<f441_nro_registro>" + RowId + "</f441_nro_registro>" + Environment.NewLine;
            Xml += "</Compromisos>" + Environment.NewLine;

            Xml += "<Final>" + Environment.NewLine;
            Xml += "<F_CIA>001</F_CIA>" + Environment.NewLine;
            Xml += "</Final>" + Environment.NewLine;

            Xml += "</MyDataSet>";

            var Respuesta = _Importar.ImportarDatosDS(91932, "Ecommerce_Compromiso_Requisicion", 2, "1", "gt", "gt", _GenerarDataSet.Obtener(Xml), ref Ruta);

            if (Respuesta == "Importacion exitosa")
            {
                _BDPedidos.Sp_ActualizarCompromiso(CampoLlave);
            }
        }
    }
}
