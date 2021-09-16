using AgenciaBancaria.Dominio;
using System;

namespace AgenciaBancaria.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Criando conta.
                Endereco endereco = new Endereco("Rua México", 
                                                 "12345678",
                                                 "Pederneiras",
                                                 "RJ",
                                                 "Ramos");
                Cliente cliente = new Cliente("Ruan",
                                              "222222222",
                                              "555555555",
                                              endereco);
                ContaCorrente conta = new ContaCorrente(cliente, 100);

                Console.WriteLine("Situação da conta: " + conta.Situacao);
                Console.WriteLine("Número e dígito da conta: " + conta.NumeroConta + "-" + conta.DigitoVerificador);
                Console.WriteLine();

                //Recebendo senha do usuário
                //Caso a senha seja validada, a conta será aberta.
                Console.WriteLine("Insira uma senha:");
                string senha = Console.ReadLine();
                conta.Abrir(senha);
                Console.Clear();

                Console.WriteLine();
                Console.WriteLine("Situação da conta: " + conta.Situacao);
                Console.WriteLine("Número e dígito da conta: " + conta.NumeroConta + "-" + conta.DigitoVerificador);
                Console.WriteLine();

                // Saque no valor de 10 pratas.
                conta.Sacar(10, senha);
                Console.WriteLine(conta.VerSaldo());

                //Depósito no valor de 50.
                conta.Depositar(50);
                Console.WriteLine(conta.VerSaldo());

                //Outro saque, no valor de 20 reais.
                conta.Sacar(20, senha);
                Console.WriteLine(conta.VerSaldo());

                //Outro depósito, no valor de 10.
                conta.Depositar(10);
                Console.WriteLine(conta.VerExtrato());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}