using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    //CLasse base
    public abstract class Lancamento
    {
        //Construtor;
        //Data, mostrará a data dos lançamentos, saque, deposito, dependendo do método que ela for inclusa.
        //Se conta for nula, disparará uma exception;
        //Valor só aceita números maior que 0, se for igual ou menor disparará uma exception.
        public Lancamento(decimal valor, DateTime data, ContaBancaria conta)
        {
            Data = data;
            Conta = conta ?? throw new ArgumentNullException(nameof(conta));
            Valor = (valor > 0) ? valor : throw new Exception("Valor do lançamento deve ser maior que zero!");
        }

        public decimal Valor { get; init; }
        public DateTime Data { get; init; }
        public ContaBancaria Conta { get; init; }
    }
}