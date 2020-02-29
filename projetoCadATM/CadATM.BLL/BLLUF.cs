using System;
using System.Collections.Generic;
using System.Data;
using CadATM.DTO;

namespace CadATM.BLL
{
    public class BLLUF
    {
        public BLLUF()
        {

        }

        public List<UF> RetornaLista()
        {
            var lista = new List<UF>();

            string query = "select ufSigla, ufNome from UFS;";

            DataTable dt = DAL.ExecutaQuery(query);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var dr = dt.Rows[i];
                    UF ojbUF = MontaObjeto(dr);
                    lista.Add(ojbUF);
                }
            }

            return lista;
        }

        public UF Recupera(string sigla)
        {
            var objUF = new UF();

            string query = "select ufSigla, ufNome from UFS where ufSigla = '" + sigla + "';";

            DataTable dt = DAL.ExecutaQuery(query);

            if (dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
                objUF = MontaObjeto(dr);
            }

            return objUF;
        
        }

        public UF MontaObjeto(DataRow dr)
        {
            UF objUF = new UF();

            objUF.Sigla = dr["ufSigla"].ToString();
            objUF.Nome = dr["ufNome"].ToString();

            return objUF;

        }
    }
}
