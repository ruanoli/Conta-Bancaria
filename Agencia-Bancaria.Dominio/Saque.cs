using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    //Saque herda todas as propriedades do lançamento.
    public class Saque : Lancamento
    {
        public Saque(decimal valor, DateTime data, ContaBancaria conta) : base(valor, data, conta)
        {

        }
    }
}