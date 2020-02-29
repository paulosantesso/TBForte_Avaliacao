using System;
using System.Collections.Generic;
using System.Text;

namespace CadATM.DTO
{
    public class ATM
    {
        public ATM()
        {

        }

        public int ID { get; set; }

        public DateTime DataCadastro { get; set; }

        public string Nome { get; set; }

        public int PA { get; set; }

        public string PC { get; set; }

        public string Endereco { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public Municipio Municipio { get; set; }

        public UF UF { get; set; }

        public string CEP { get; set; }

        public string PontoReferencia { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }


        //Metodos
        public bool Valida(ref string message)
        {

            if (this.PC.Length > 5)
            {
                message = "Campo PC nao pode ser maior que 5 caracteres";
                return false;
            }

            if (this.Nome.Length > 50)
            {
                message = "Campo Nome nao pode ser maior que 50 caracteres";
                return false;
            }

            if (this.Endereco.Length > 50)
            {
                message = "Campo Endereco nao pode ser maior que 50 caracteres";
                return false;
            }

            if (this.Bairro.Length > 50)
            {
                message = "Campo Bairro nao pode ser maior que 50 caracteres";
                return false;
            }

            if (this.Complemento.Length > 20)
            {
                message = "Campo Complemento nao pode ser maior que 20 caracteres";
                return false;
            }

            if (this.Complemento.Length > 20)
            {
                message = "Campo Complemento nao pode ser maior que 20 caracteres";
                return false;
            }

            if (this.CEP.Length > 8)
            {
                message = "Campo CEP nao pode ser maior que 8 caracteres";
                return false;
            }

            if (this.PontoReferencia.Length > 50)
            {
                message = "Campo Ponto Referência nao pode ser maior que 50 caracteres";
                return false;
            }

            return true;
        }


    }

    



}
