using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    //Classe base.
    //Classe abstrata não pode ser instanciada. Ela pode ser herdada somente.
    public abstract class ContaBancaria
    {
        public ContaBancaria(Cliente cliente)
        {
            //Gerando números aleatórios para a Conta e dígito;
            //Números entre 50000 e 100000;
            //Dígito será gerado entre 0 e 9.
            Random random = new Random();
            NumeroConta = random.Next(50000, 100000);
            DigitoVerificador = random.Next(0, 9);

            Situacao = SituacaoConta.Criada;

            //Se algum dado do cliente estiver nulo, cairá na exception.
            Cliente = cliente ?? throw new Exception("Cadastro incompleto.");
        }

        //Abrindo a conta;
        public void Abrir(string senha)
        {
            SetaSenha(senha);

            Situacao = SituacaoConta.Aberta;
            DataAbertura = DateTime.Now;
            Lancamentos = new List<Lancamento>();
        }

        //Regras e Exceptions da senha.
        private void SetaSenha(string senha)
        {
            senha = senha.ValidaStringVazia();

            // Regras:
            //Mínimo de cacarateres são 8;
            //Deve possuir pelo menos uma letra de [a-z]
            //Deve possuir pelo menos um número de [0-9]
            if (!Regex.IsMatch(senha, @"^(?=.*?[a-z])(?=.*?[0-9]).{8,}$"))
            {
                throw new Exception("Senha inválida!");
            }

            Senha = senha;
        }

        //Instancia da classe deposito;
        //Voce insere o valor de depósito;
        //O valor inserido erá somado ao saldo 
        //E o deposito será adicinado aos lançamentos com a Data que foi feita o deposito.
        public void Depositar(decimal valor)
        {
            var deposito = new Deposito(valor, DateTime.Now, this);

            Saldo += deposito.Valor;
            Lancamentos.Add(deposito);
        }

        ////Se a senha estiver incorreta o saque não será autorizado.
        // Se o saldo for menor que o saque, caíra em uma exception.
        //Adicionando à Lançamentos o valor e a data.
        public virtual void Sacar(decimal valor, string senha)
        {
            if (senha != Senha)
            {
                throw new Exception("Senha incorreta!");
            }

            var saque = new Saque(valor, DateTime.Now, this);

            if (Saldo < saque.Valor)
            {
                throw new Exception("Saldo indisponível!");
            }

            Saldo -= saque.Valor;
            Lancamentos.Add(saque);
        }

        //Verifica o saldo com o valor já atribuído no método acima.
        public string VerSaldo()
        {
            return $"Saldo atual: R$ {Saldo}";
        }

        //Mostra o extrato com todos os lançamentos.
        //Mostra o saldo final.
        public virtual string VerExtrato()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"-- Extrato | Lançamentos --");

            foreach (var lancamento in Lancamentos)
            {
                sb.Append(lancamento.GetType().Name + "  -->  ");
                sb.Append(lancamento.Data.ToString("dd/MM/yyyy hh:mm:ss" + "   -->  "));

                if (lancamento is Saque)
                    sb.Append(" - ");

                if (lancamento is Deposito)
                    sb.Append(" + ");

                sb.Append("R$ ");
                sb.AppendLine(lancamento.Valor.ToString());
            }

            sb.AppendLine("Saldo final:   R$ " + Saldo);

            return sb.ToString();
        }

        public int NumeroConta { get; init; }
        public int DigitoVerificador { get; init; }
        public decimal Saldo { get; protected set; }
        public DateTime? DataAbertura { get; private set; }
        public DateTime? DataEncerramento { get; private set; }
        public SituacaoConta Situacao { get; private set; }
        public string Senha { get; private set; }
        public Cliente Cliente { get; init; }
        public List<Lancamento> Lancamentos { get; private set; }
    }
}
