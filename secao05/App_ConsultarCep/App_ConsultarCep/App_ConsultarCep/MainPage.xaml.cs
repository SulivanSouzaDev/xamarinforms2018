using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App_ConsultarCep.servicos.modelo;
using App_ConsultarCep.servicos;

namespace App_ConsultarCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            BOTAO.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs args)
        {
            // TODDO - logica do programa.


            //TODO - Validações.
            string cep = CEP.Text.Trim();

            if (isValidCep(cep)) { 
                try
                {
                    Endereco end = viaCEPServico.BuscarEnderecoViaCep(cep);
                    RESULTADO.Text = string.Format("Endereço: {2} de {3} {0},{1} ", end.localidade, end.uf, end.logradouro, end.bairro);
                }
                catch(Exception e)
                {
                    DisplayAlert("Erro Critico", e.Message, "OK");
                }
                }
            }

        private bool isValidCep(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERROR","CEP Inválido o CEP deve conter 8 Caracter", "OK");
                valido = false;
            }

            int NovoCep = 0;
            if (!int.TryParse (cep, out NovoCep))
            {
                DisplayAlert("ERROR", "CEP Inválido, Deve ser numero", "OK");
                valido = false;
            }
            return valido;
        }
    }
}
