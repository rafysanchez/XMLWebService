using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace WebService2
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://localhost/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        SqlConnection cn = new SqlConnection("Data Source = .; Initial Catalog = datos; Integrated Security = true;");
        SqlCommand cmd = new SqlCommand();


        [WebMethod]
        public int insertados()
        {
            int retorna = 0;

            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load("E:/Normas y estandares de calidad/UnidadIV/Tienda_Arreglada/ProyectoCompleto_Bookieshop/bookie2013/cargadedatos.xml");
                XmlNodeList factura = xmldoc.GetElementsByTagName("factura");
                XmlNodeList lista = ((XmlElement)factura[0]).GetElementsByTagName("detalle");
                foreach (XmlElement nodo in lista)
                {
                    XmlNodeList exito = nodo.GetElementsByTagName("Exito");
                    try
                    {
                        for (int i = 0; i < exito.Count; i++)
                        {
                            string valor = exito[i].InnerText;
                            if (valor == "insertado")
                            {
                                retorna = retorna + 1;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return retorna;

            }
            catch (Exception exa)
            {
                throw exa;
            }
        }

        [WebMethod]
        public int erroneos()
        {
            int retorna = 0;

            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load("E:/Normas y estandares de calidad/UnidadIV/Tienda_Arreglada/ProyectoCompleto_Bookieshop/bookie2013/cargadedatos.xml");
                XmlNodeList factura = xmldoc.GetElementsByTagName("factura");
                XmlNodeList lista = ((XmlElement)factura[0]).GetElementsByTagName("detalle");
                foreach (XmlElement nodo in lista)
                {
                    XmlNodeList exito = nodo.GetElementsByTagName("Exito");
                    try
                    {
                        for (int i = 0; i < exito.Count; i++)
                        {
                            string valor = exito[i].InnerText;
                            if (valor == "error")
                            {
                                retorna = retorna + 1;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return retorna;

            }
            catch (Exception exa)
            {
                throw exa;
            }
        }


        [WebMethod]
        public void Proce_insertar(string texto, int insertados)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "proced_insertar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = texto;
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = insertados;
            cmd.ExecuteNonQuery();
        }

        [WebMethod]
        public void Proce_erroneos(string textos2,int erroneos)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "proced_erroneos";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = textos2;
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = erroneos;
            cmd.ExecuteNonQuery();
        }

    }
}