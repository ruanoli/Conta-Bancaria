using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public class Endereco
    {
        //Construnindo os dados de endereço do cliente.
        public Endereco(string logradouro, string cep, string cidade, string estado, string bairro)
        {
            Logradouro = logradouro.ValidaStringVazia();
            CEP = cep.ValidaStringVazia();
            Cidade = cidade.ValidaStringVazia();
            Estado = estado.ValidaStringVazia();
            Bairro = bairro.ValidaStringVazia();
        }

        public string Logradouro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Bairro { get; private set; }
    }
}