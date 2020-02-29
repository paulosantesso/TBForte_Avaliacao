using System;
using System.Collections.Generic;
using System.Data;
using CadATM.DTO;

namespace CadATM.BLL
{
    public class BLLMunicipio
    {
        public BLLMunicipio()
        {

        }

        public List<Municipio> RetornaLista(string siglaUF)
        {
            var lista = new List<Municipio>();

            string query = "select m.MunID, m.MunNome, m.MunUF, m.MunISS, m.MunICMS, m.MunICMSInterno from Municipios m " +
                " where m.MunUF = '" + siglaUF + "';";

            DataTable dt = DAL.ExecutaQuery(query);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var dr = dt.Rows[i];
                    Municipio objMunicipio = MontaObjeto(dr);
                    lista.Add(objMunicipio);
                }               
            }

            return lista;
        }

        public Municipio Recupera(int ID)
        {
            var objMunicipio = new Municipio();

            string query = "select m.MunID, m.MunNome, m.MunUF, m.MunISS, m.MunICMS, m.MunICMSInterno from Municipios m " +
                " where m.MunID = " + ID.ToString() + ";";

            DataTable dt = DAL.ExecutaQuery(query);

            if (dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
                objMunicipio = MontaObjeto(dr);                
            }

            return objMunicipio;
        }

        public Municipio MontaObjeto(DataRow dr)
        {
            Municipio objMunicipio = new Municipio();

            objMunicipio.ID = (int)dr["MunID"];
            objMunicipio.Nome = dr["MunNome"].ToString();

            UF objUF = new UF();
            BLLUF _UF = new BLLUF();
            string siglaUF = dr["MunUF"].ToString();
            objMunicipio.UF = _UF.Recupera(siglaUF);

            objMunicipio.ISS = dr["MunISS"].ToString();
            objMunicipio.ICMS = dr["MunICMS"].ToString();
            objMunicipio.ICMSInterno = dr["MunICMSInterno"].ToString();

            return objMunicipio;

        }
    }
}
