using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ProjetoMVCB18.DAL;

namespace ProjetoMVCB18.BLL
{
    public class tabelaClienteBLL
    {
        private ConexaoDAL database = new ConexaoDAL();

        public Boolean Auth(string email, string senha)
        {
            string consult = string.Format($@"select * from tblCliente where email = '{email}' and senha = '{senha}'");
            DataTable dt = database.executeConsult(consult);
            if (dt.Rows.Count == 1) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}