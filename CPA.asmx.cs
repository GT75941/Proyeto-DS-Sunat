using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

//namespace para acceso a sql server
using System.Data.SqlClient; //acceso para sql server
using System.Data;//archivos generales
using System.Configuration;// archivos  de configuración
namespace SunatProy
{
    /// <summary>
    /// Descripción breve de CPA
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class CPA : System.Web.Services.WebService
    {
        //acceder a la cadena de conexión 
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static SqlConnection conexion = new SqlConnection(cadena);

        [WebMethod(Description = " Listar Ruc con Procedimientos Almacenados")]
        public DataSet ListarRuc()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand("spListarTRuc", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adaptador.Fill(data);
                return data;
            }
        }
        [WebMethod(Description = " Listar Contribuyente con Procedimientos Almacenados")]
        public DataSet ListarTContribuyente()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand("spListarTContribuyente", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adaptador.Fill(data);
                return data;
            }
        }
        [WebMethod(Description = "Agregar Ruc con Procedimientos Almacenados")]
        public string[] AgregarRuc(string IdRuc, string NroRuc, string TipoContribuyente, string NombreComercial, DateTime FechaInscripcion, DateTime FechaInicioActividades, string CondicionContribuyente, string DomicilioFiscal,
            string SistemaEmisionComprobante, string ActividadComercioExterior, string SistemaContabilidad, string ActividadEconomica, string ComprobantesPago, string SistemaEmisionElectronica, DateTime EmisorElectronico,
            string ComprobanteElectronico, string AfiliadoAlPLE, string Padrones, DateTime FechaConsulta, string IdContribuyente)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand("spAgregarRuc", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdRuc", IdRuc);
                comando.Parameters.AddWithValue("@NroRuc", NroRuc);
                comando.Parameters.AddWithValue("@TipoContribuyente", TipoContribuyente);
                comando.Parameters.AddWithValue("@NombreComercial", NombreComercial);
                comando.Parameters.AddWithValue("@FechaInscripcion", FechaInscripcion);
                comando.Parameters.AddWithValue("@FechaInicioActividades", FechaInicioActividades);
                comando.Parameters.AddWithValue("@CondicionContribuyente", CondicionContribuyente);
                comando.Parameters.AddWithValue("@DomicilioFiscal", DomicilioFiscal);
                comando.Parameters.AddWithValue("@SistemaEmisionComprobante", SistemaEmisionComprobante);
                comando.Parameters.AddWithValue("@ActividadComercioExterior", ActividadComercioExterior);
                comando.Parameters.AddWithValue("@SistemaContabilidad", SistemaContabilidad);
                comando.Parameters.AddWithValue("@ActividadEconomica", ActividadEconomica);
                comando.Parameters.AddWithValue("@ComprobantesPago", ComprobantesPago);
                comando.Parameters.AddWithValue("@SistemaEmisionElectronica", SistemaEmisionElectronica);
                comando.Parameters.AddWithValue("@EmisorElectronico", EmisorElectronico);
                comando.Parameters.AddWithValue("@ComprobanteElectronico", ComprobanteElectronico);
                comando.Parameters.AddWithValue("@AfiliadoAlPLE", AfiliadoAlPLE);
                comando.Parameters.AddWithValue("@Padrones", Padrones);
                comando.Parameters.AddWithValue("@FechaConsulta", FechaConsulta);
                comando.Parameters.AddWithValue("@IdContribuyente", IdContribuyente);

                string[] arreglo = new string[2]; // Arreglo que trae los datos de CodError y Mensaje
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                arreglo[0] = data.Tables[0].Rows[0]["CodError"].ToString();
                arreglo[1] = data.Tables[0].Rows[0]["Mensaje"].ToString();
                return arreglo;
            }

        }
        [WebMethod(Description = "Agregar Contribuyente con Procedimientos Almacenados")]
        public string[] AgregarContribuyente(string IdContribuyente, string NombreContribuyente, string ApellidoContribuyente, string NroTelefonoContribuyente,
            string UbicacionContribuyente, string TipoDeDocumento, string NroDeDocumento, string EstadoContribuyente)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand("spAgregarContribuyente", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdContribuyente", IdContribuyente);
                comando.Parameters.AddWithValue("@NombreContribuyente", NombreContribuyente);
                comando.Parameters.AddWithValue("@ApellidoContribuyente", ApellidoContribuyente);
                comando.Parameters.AddWithValue("@NroTelefonoContribuyente", NroTelefonoContribuyente);
                comando.Parameters.AddWithValue("@UbicacionContribuyente", UbicacionContribuyente);
                comando.Parameters.AddWithValue("@TipoDeDocumento", TipoDeDocumento);
                comando.Parameters.AddWithValue("@NroDeDocumento", NroDeDocumento);
                comando.Parameters.AddWithValue("@EstadoContribuyente", EstadoContribuyente);

                string[] arreglo = new string[2]; // Arreglo que trae los datos de CodError y Mensaje
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                arreglo[0] = data.Tables[0].Rows[0]["CodError"].ToString();
                arreglo[1] = data.Tables[0].Rows[0]["Mensaje"].ToString();
                return arreglo;
            }
        }
        
        [WebMethod(Description = "Eliminar Ruc con Procedimientos Almacenados")]
        public string[] EliminarRuc(string IdRuc)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand("spEliminarRuc", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdRuc", IdRuc);
                string[] arreglo = new string[2]; // Arreglo que trae los datos de CodError y Mensaje
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                arreglo[0] = data.Tables[0].Rows[0]["CodError"].ToString();
                arreglo[1] = data.Tables[0].Rows[0]["Mensaje"].ToString();
                return arreglo;
            }
        }
        [WebMethod(Description = "Eliminar Contribuyente con Procedimientos Almacenados")]
        public string[] EliminarContribuyente(string IdContribuyente)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand("spEliminarContribuyente", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdContribuyente", IdContribuyente);
                string[] arreglo = new string[2]; // Arreglo que trae los datos de CodError y Mensaje
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                arreglo[0] = data.Tables[0].Rows[0]["CodError"].ToString();
                arreglo[1] = data.Tables[0].Rows[0]["Mensaje"].ToString();
                return arreglo;
            }
        }

        [WebMethod(Description = "Editar Ruc con Procedimientos Almacenados")]
        public string[] EditarRuc(string IdRuc, string NroRuc, string TipoContribuyente, string NombreComercial, DateTime FechaInscripcion, DateTime FechaInicioActividades, string CondicionContribuyente, string DomicilioFiscal,
            string SistemaEmisionComprobante, string ActividadComercioExterior, string SistemaContabilidad, string ActividadEconomica, string ComprobantesPago, string SistemaEmisionElectronica, DateTime EmisorElectronico,
            string ComprobanteElectronico, string AfiliadoAlPLE, string Padrones, DateTime FechaConsulta, string IdContribuyente)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand("spEditarRuc", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdRuc", IdRuc);
                comando.Parameters.AddWithValue("@NroRuc", NroRuc);
                comando.Parameters.AddWithValue("@TipoContribuyente", TipoContribuyente);
                comando.Parameters.AddWithValue("@NombreComercial", NombreComercial);
                comando.Parameters.AddWithValue("@FechaInscripcion", FechaInscripcion);
                comando.Parameters.AddWithValue("@FechaInicioActividades", FechaInicioActividades);
                comando.Parameters.AddWithValue("@CondicionContribuyente", CondicionContribuyente);
                comando.Parameters.AddWithValue("@DomicilioFiscal", DomicilioFiscal);
                comando.Parameters.AddWithValue("@SistemaEmisionComprobante", SistemaEmisionComprobante);
                comando.Parameters.AddWithValue("@ActividadComercioExterior", ActividadComercioExterior);
                comando.Parameters.AddWithValue("@SistemaContabilidad", SistemaContabilidad);
                comando.Parameters.AddWithValue("@ActividadEconomica", ActividadEconomica);
                comando.Parameters.AddWithValue("@ComprobantesPago", ComprobantesPago);
                comando.Parameters.AddWithValue("@SistemaEmisionElectronica", SistemaEmisionElectronica);
                comando.Parameters.AddWithValue("@EmisorElectronico", EmisorElectronico);
                comando.Parameters.AddWithValue("@ComprobanteElectronico", ComprobanteElectronico);
                comando.Parameters.AddWithValue("@AfiliadoAlPLE", AfiliadoAlPLE);
                comando.Parameters.AddWithValue("@Padrones", Padrones);
                comando.Parameters.AddWithValue("@FechaConsulta", FechaConsulta);
                comando.Parameters.AddWithValue("@IdContribuyente", IdContribuyente);

                string[] arreglo = new string[2]; // Arreglo que trae los datos de CodError y Mensaje
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                arreglo[0] = data.Tables[0].Rows[0]["CodError"].ToString();
                arreglo[1] = data.Tables[0].Rows[0]["Mensaje"].ToString();
                return arreglo;
            }
        }
        [WebMethod(Description = "Editar Contribuyente con Procedimientos Almacenados")]
        public string[] EditarContribuyente(string IdContribuyente, string NombreContribuyente, string ApellidoContribuyente, string NroTelefonoContribuyente,
            string UbicacionContribuyente, string TipoDeDocumento, string NroDeDocumento, string EstadoContribuyente)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand("spEditarContribuyente", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdContribuyente", IdContribuyente);
                comando.Parameters.AddWithValue("@NombreContribuyente", NombreContribuyente);
                comando.Parameters.AddWithValue("@ApellidoContribuyente", ApellidoContribuyente);
                comando.Parameters.AddWithValue("@NroTelefonoContribuyente", NroTelefonoContribuyente);
                comando.Parameters.AddWithValue("@UbicacionContribuyente", UbicacionContribuyente);
                comando.Parameters.AddWithValue("@TipoDeDocumento", TipoDeDocumento);
                comando.Parameters.AddWithValue("@NroDeDocumento", NroDeDocumento);
                comando.Parameters.AddWithValue("@EstadoContribuyente", EstadoContribuyente);

                string[] arreglo = new string[2]; // Arreglo que trae los datos de CodError y Mensaje
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                arreglo[0] = data.Tables[0].Rows[0]["CodError"].ToString();
                arreglo[1] = data.Tables[0].Rows[0]["Mensaje"].ToString();
                return arreglo;
            }
        }
        [WebMethod(Description = "Buscar Contribuyente con Procedimientos Almacenados")]
        public DataSet BuscarContribuyente(string texto, string criterio)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand("spBuscarContribuyente", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Texto", texto);
                comando.Parameters.AddWithValue("@Criterio", criterio);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                return data;
            }
        }
        
        [WebMethod(Description = " Busqueda Ruc con Procedimientos Almacenados (spRuc)")]
        public DataSet BuscarRuc(string Buscar)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand("spRuc", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Buscar", Buscar);
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adaptador.Fill(data);
                return data;
            }
        }
        [WebMethod(Description = " Listar Razon Social con Procedimientos Almacenados (spRuc)")]
        public DataSet BuscarRazonSocial(string Buscar)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand("spRazonSocial", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Buscar", Buscar);
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adaptador.Fill(data);
                return data;
            }
        }
        [WebMethod(Description = " Busqueda Documento con Procedimientos Almacenados (spRuc)")]
        public DataSet BuscarDocumento(string Buscar)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand("spDocumento", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Buscar", Buscar);
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adaptador.Fill(data);
                return data;
            }
        }

    }
}
