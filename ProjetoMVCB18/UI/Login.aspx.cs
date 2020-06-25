﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using ProjetoMVCB18.BLL;
using ProjetoMVCB18.DTO;

namespace ProjetoMVCB18.UI
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblAuthor.Text = ConfigurationManager.AppSettings.Get("author");
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                tabelaClienteDTO cliente = new tabelaClienteDTO();
                tabelaClienteBLL bllCliente = new tabelaClienteBLL();

                cliente.EmailCliente = txtEmail.Text;
                cliente.SenhaCliente = txtPassword.Text;

                if (bllCliente.Auth(cliente.EmailCliente, cliente.SenhaCliente))
                {
                    status.Visible = true;
                    status.Text = "Cliente Localizado";
                }
                else
                {
                    status.Visible = true;
                    status.Text = "Cliente não Localizado";
                }
            }
            catch (Exception ex)
            {
                status.Visible = true;
                status.Text = ex.Message;
            }
        }
    }
}