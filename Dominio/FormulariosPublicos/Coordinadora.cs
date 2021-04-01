using Dominio.Recursos;
using Infraestructura.CRUD;
//using Infraestructura.WsGenerarGuiasPruebas;
using Infraestructura.WsGenerarGuiasReal;
using System;
using System.Data;
using System.Threading;

namespace Dominio.FormulariosPublicos
{
    public class Coordinadora
    {
        private Agw_typeGenerarGuiaIn GenerarGuiaIn = new Agw_typeGenerarGuiaIn();
        private Agw_typeGenerarGuiaOut GenerarGuiaOut = new Agw_typeGenerarGuiaOut();
        private Agw_imprimirRotulosIn RotulosIn = new Agw_imprimirRotulosIn();
        private Agw_imprimirRotulosOut RotulosOut = new Agw_imprimirRotulosOut();
        private Agw_typeGuiaDetalle GuiaDetalle = new Agw_typeGuiaDetalle();
        private Agw_typeGuiaDetalle[] ArrayGuiaDetalle = new Agw_typeGuiaDetalle[1];
        private Agw_typeGuiaDetalleRecaudo DetalleRecaudo = new Agw_typeGuiaDetalleRecaudo();
        private Agw_typeGuiaDetalleRecaudo[] ArrayDetalleRecaudo = new Agw_typeGuiaDetalleRecaudo[1];
        private JRpcServerSoapManagerService ServerSoapManagerService = new JRpcServerSoapManagerService();
        private BDPedidos _BDPedidos = new BDPedidos();
        private Encriptar _Encriptar = new Encriptar();

        public string GenerarGuia(string OrderId, string CodigoAlterno, string RespuestaFactura)
        {
            if (RespuestaFactura.Contains("Factura: Importacion exitosa"))
            {

                DataSet DsGuias = _BDPedidos.Sp_ConsultarCoordinadoraPorOrderId(OrderId);

                if (DsGuias.Tables.Count > 0)
                {
                    foreach (DataRow Registro in DsGuias.Tables[0].Rows)
                    {
                        GenerarGuiaIn.codigo_remision = Registro["codigo_remision"].ToString();
                        GenerarGuiaIn.fecha = Registro["fecha"].ToString();
                        GenerarGuiaIn.id_cliente = Convert.ToInt32(Registro["id_cliente"]);
                        GenerarGuiaIn.usuario = Registro["usuario"].ToString();
                        GenerarGuiaIn.clave = _Encriptar.Clave(Registro["clave"].ToString());
                        GenerarGuiaIn.valor_declarado = Convert.ToInt32(Registro["valor_declarado"]);

                        GenerarGuiaIn.id_remitente = Convert.ToInt32(Registro["id_remitente"]);
                        GenerarGuiaIn.direccion_remitente = Registro["direccion_remitente"].ToString();
                        GenerarGuiaIn.nombre_remitente = Registro["nombre_remitente"].ToString();
                        GenerarGuiaIn.ciudad_remitente = Registro["ciudad_remitente"].ToString();
                        GenerarGuiaIn.telefono_remitente = Registro["telefono_remitente"].ToString();

                        GenerarGuiaIn.nit_destinatario = Registro["nit_destinatario"].ToString();
                        GenerarGuiaIn.nombre_destinatario = Registro["nombre_destinatario"].ToString();
                        GenerarGuiaIn.direccion_destinatario = Registro["direccion_destinatario"].ToString();
                        GenerarGuiaIn.ciudad_destinatario = CodigoAlterno != string.Empty ? CodigoAlterno : Registro["ciudad_destinatario"].ToString();
                        GenerarGuiaIn.telefono_destinatario = Registro["telefono_destinatario"].ToString();

                        GenerarGuiaIn.observaciones = Registro["observaciones"].ToString();
                        GenerarGuiaIn.contenido = Registro["contenido"].ToString();
                        GenerarGuiaIn.referencia = Registro["referencia"].ToString();
                        GenerarGuiaIn.estado = Registro["estado"].ToString();
                        GenerarGuiaIn.formato_impresion = Registro["formato_impresion"].ToString();
                        GenerarGuiaIn.codigo_cuenta = Convert.ToInt32(Registro["codigo_cuenta"]);
                        GenerarGuiaIn.codigo_producto = Convert.ToInt32(Registro["codigo_producto"]);
                        GenerarGuiaIn.nivel_servicio = Convert.ToInt32(Registro["nivel_servicio"]);

                        GenerarGuiaIn.div_destinatario = Registro["div_destinatario"].ToString();
                        GenerarGuiaIn.centro_costos = Registro["centro_costos"].ToString();
                        GenerarGuiaIn.cuenta_contable = Registro["cuenta_contable"].ToString();

                        GuiaDetalle.largo = Convert.ToInt32(Registro["largo"]);
                        GuiaDetalle.nombre_empaque = Registro["nombre_empaque"].ToString();
                        GuiaDetalle.peso = Convert.ToInt32(Registro["peso"]);
                        GuiaDetalle.referencia = Registro["referencia"].ToString();
                        GuiaDetalle.alto = Convert.ToInt32(Registro["alto"]);
                        GuiaDetalle.ancho = Convert.ToInt32(Registro["ancho"]);
                        GuiaDetalle.unidades = Convert.ToInt32(Registro["unidades"]);
                        GuiaDetalle.ubl = Convert.ToInt32(Registro["ubl"]);

                        ArrayGuiaDetalle[0] = GuiaDetalle;
                        GenerarGuiaIn.detalle = ArrayGuiaDetalle;

                        if (Convert.ToInt32(Registro["valor"]) != 0)
                        {
                            DetalleRecaudo.referencia = Registro["referencia_recaudo"].ToString();
                            DetalleRecaudo.valor = Convert.ToInt32(Registro["valor"]);
                            DetalleRecaudo.valor_base_iva = Convert.ToInt32(Registro["valor_base_iva"]);
                            DetalleRecaudo.valor_iva = Convert.ToInt32(Registro["valor_iva"]);
                            DetalleRecaudo.forma_pago = Convert.ToInt32(Registro["forma_pago"]);

                            ArrayDetalleRecaudo[0] = DetalleRecaudo;
                            GenerarGuiaIn.recaudos = ArrayDetalleRecaudo;
                        }
                        else
                        {
                            GenerarGuiaIn.recaudos = null;
                        }

                        try
                        {
                            GenerarGuiaOut = ServerSoapManagerService.Guias_generarGuia(GenerarGuiaIn);
                            Thread.Sleep(1000);
                        }
                        catch (Exception Ex)
                        {
                            return Ex.Message.ToString();
                        }

                        object[] ArrayRemision = new object[1];
                        ArrayRemision[0] = GenerarGuiaOut.codigo_remision;

                        RotulosIn.id_rotulo = Registro["id_rotulo"].ToString();
                        RotulosIn.codigos_remisiones = ArrayRemision;
                        RotulosIn.usuario = Registro["usuario"].ToString();
                        RotulosIn.clave = _Encriptar.Clave(Registro["clave"].ToString());

                        try
                        {
                            if (ArrayRemision[0].ToString() != "")
                            {
                                RotulosOut = ServerSoapManagerService.Guias_imprimirRotulos(RotulosIn);

                                _BDPedidos.Sp_AlmacenarGuias(Registro["OrderId"].ToString(), GenerarGuiaOut.codigo_remision.ToString(), GenerarGuiaOut.pdf_guia.ToString(), RotulosOut.rotulos.ToString());
                                _BDPedidos.Sp_ActualizarEstados(Registro["OrderId"].ToString(), "10");
                                Thread.Sleep(1000);
                            }
                        }
                        catch (Exception Ex)
                        {
                            return Ex.Message.ToString();
                        }
                    }
                    return "Coordinadora: Importacion exitosa";
                }
                return "Coordinadora: No se encontraron datos por procesar";
            }
            return "Coordinadora: Sin Procesar";
        }
    }
}
