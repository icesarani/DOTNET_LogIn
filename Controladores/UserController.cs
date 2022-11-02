using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Web.Services.Description;
//using System.Data.Entity.DbContext;
using Dapper;
using System.Configuration;

namespace WebApplication7.Controladores
{

    public class UserController
    {
        public static int ValidateUser(string user, string pass)
        {
            try
            {
                ConexionDB datos = new ConexionDB(ConfigurationManager.ConnectionStrings["costos"].ConnectionString);
                MisterMaker mk = new MisterMaker();
                string consulta = MisterMaker.ReadDocument("UserValidation");
                consulta = consulta.Replace("@user", user);
                consulta = consulta.Replace("@pass", pass);
                var response = datos.GetCustomSelectQuery(consulta);
                return int.Parse(response.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    
    }
}