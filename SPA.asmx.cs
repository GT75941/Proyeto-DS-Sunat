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
    /// Descripción breve de SPA
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class SPA : System.Web.Services.WebService
    {

    }
}
