using System;
using System.Data;
using CadATM.DTO;

namespace CadATM.BLL
{
    public class BLLATM
    {
        public BLLATM()
        {

        }

        public ATM Pesquisa(string paramPC)
        {
            try
            {
                ATM objATM = new ATM();

                string query = "select atmID, atmDTCadastro, atmNome, atmPA, atmPC, atmEndereco, atmComplemento, atmBairro, atmCidade, atmUF, atmCEP, " +
                    " atmPontoRef, atmLAtitude, atmLongitude from ATMs where atmPC = '" + paramPC + "';";

                DataTable dt = DAL.ExecutaQuery(query);

                if (dt.Rows.Count > 0)
                {
                    var dr = dt.Rows[0];
                    objATM = MontaObjeto(dr);
                }

                return objATM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ATM PesquisaPA(int paramPA)
        {
            try
            {
                ATM objATM = new ATM();

                string query = "select atmID, atmDTCadastro, atmNome, atmPA, atmPC, atmEndereco, atmComplemento, atmBairro, atmCidade, atmUF, atmCEP, " +
                    " atmPontoRef, atmLAtitude, atmLongitude from ATMs where atmPA = " + paramPA + ";";

                DataTable dt = DAL.ExecutaQuery(query);

                if (dt.Rows.Count > 0)
                {
                    var dr = dt.Rows[0];
                    objATM = MontaObjeto(dr);
                }

                return objATM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Exclusao(int paramID)
        {
            try
            {
                string query = "delete from ATMs where atmID = " + paramID.ToString() + ";";

                DAL.ExecutaQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Salvar(DTO.ATM objATM)
        {
            try
            {
                if (objATM.ID <= 0)
                {
                    this.Insert(objATM);
                }
                else
                {
                    this.Update(objATM);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Insert(DTO.ATM objATM)
        {
            try
            {
                VerificaPA(ref objATM);

                string query = string.Format("insert into atms (atmID, atmDTCadastro, atmNome, atmPA, atmPC, atmEndereco, atmComplemento, " +
                    "atmBairro, atmCidade, atmUF, atmCEP, atmPontoRef, atmLAtitude, atmLongitude) values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, " +
                    "{7}, {8}, {9}, {10}, {11}, {12}, {13}, {14});",
                    objATM.ID, objATM.DataCadastro, objATM.Nome, objATM.PA,
                    objATM.PC, objATM.Endereco, objATM.Complemento, objATM.Bairro,
                    objATM.Municipio, objATM.UF, objATM.CEP, objATM.PontoReferencia,
                    objATM.Latitude, objATM.Longitude);

                DAL.ExecutaQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Update(DTO.ATM objATM)
        {
            try
            {
                VerificaPA(ref objATM);

                string query = string.Format("update atms set atmNome = '{0}', atmPA = '{1}', atmPC = '{2}', atmEndereco = '{3}', atmComplemento = '{4}', " +
                   "atmBairro = '{5}', atmCidade = {6}, atmUF = '{7}', atmCEP = '{8}', atmPontoRef = '{9}', atmLAtitude = {10}, atmLongitude = {11} " +
                   " where atmID = {12};",
                    objATM.Nome, objATM.PA,
                   objATM.PC, objATM.Endereco, objATM.Complemento, objATM.Bairro,
                   objATM.Municipio, objATM.UF, objATM.CEP, objATM.PontoReferencia,
                   objATM.Latitude, objATM.Longitude,
                   objATM.ID);

                DAL.ExecutaQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ATM MontaObjeto(DataRow dr)
        {
            ATM objATM = new ATM();

            objATM.ID = (int)dr["atmID"];
            objATM.DataCadastro = (DateTime)dr["atmDtCadastro"];
            objATM.Nome = dr["atmNome"].ToString();
            objATM.PA = (int)dr["atmPA"];
            objATM.PC = dr["atmPC"].ToString();
            objATM.Endereco = dr["atmEndereco"].ToString();
            objATM.Complemento = dr["atmComplemento"].ToString();
            objATM.Bairro = dr["atmBairro"].ToString();

            //municipio/UF
            Municipio objMunicipio = new Municipio();
            BLLMunicipio _Mun = new BLLMunicipio();
            int IDMunicipio = (int)dr["atmCidade"];
            objATM.Municipio = _Mun.Recupera(IDMunicipio);
            objATM.UF = objATM.Municipio.UF;

            objATM.CEP = dr["atmCEP"].ToString();
            objATM.PontoReferencia = dr["atmPontoRef"].ToString();
            objATM.Latitude = (decimal)dr["atmLatitude"];
            objATM.Longitude = (decimal)dr["atmLongitude"];

            return objATM;

        }

        public void VerificaPA(ref ATM objATM)
        {
            //Verifica se existe PA cadastrado
            ATM objATM_PA = new ATM();
            objATM_PA = PesquisaPA(objATM.PA);

            if (objATM_PA != null && objATM_PA.ID > 0)
            {
                //mantem mesmo endereco do ATM com PA cadastrado
                objATM.Endereco = objATM_PA.Endereco;
                objATM.Bairro = objATM_PA.Bairro;
                objATM.Complemento = objATM_PA.Complemento;
                objATM.UF = objATM_PA.UF;
                objATM.Municipio = objATM_PA.Municipio;
            }
        }
    }
}
