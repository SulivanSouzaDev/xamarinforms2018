using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App_ConsultarCep.servicos.modelo;
using Newtonsoft.Json;

namespace App_ConsultarCep.servicos.modelo
{
    public class viaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public  static Endereco BuscarEnderecoViaCep(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            return end;
        }
    }
}
