using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication7.Controladores;

namespace WebApplication7.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void ShowMessage(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = (msg.Length > 0);
        }

        protected void ValidateCredentials(object sender, EventArgs e)
        {
            string user = inUser.Text.Trim();
            string pass = inPass.Text.Trim();
            int response = UserController.ValidateUser(user,pass);
            if (response == 1)
            {
                ShowMessage("Usuario Correcto");
                Thread.Sleep(3000);
                Response.Redirect("CreateUser.aspx");
            }
            else 
            {
                ShowMessage("Usuario Incorrecto");
            }
        }

    }
}