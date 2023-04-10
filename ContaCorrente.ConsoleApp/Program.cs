using System.ComponentModel;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ContaCorrente conta1 = new ContaCorrente(123, 1000, true, 500);
            //123: número da conta
            //1000: saldo inicial da conta
            //true: status especial da conta
            //500: limite de saque da conta
            ContaCorrente conta2 = new ContaCorrente(456, 500, false, 0);

            conta1.Depositar(500);
            conta1.Sacar(200);

            conta2.Depositar(500);
            conta2.Sacar(800);

            Console.WriteLine("Saldo da conta 1: " + conta1.Saldo);
            Console.WriteLine("Saldo da conta 2: " + conta2.Saldo);

            conta1.Transferir(300, conta2);

            Console.WriteLine("Saldo da conta 1 após transferência: " + conta1.Saldo);
            Console.WriteLine("Saldo da conta 2 após transferência: " + conta2.Saldo);

            Console.WriteLine("Extrato da conta 1:");
            foreach (Movimentacao movimentacao in conta1.Extrato())
            {
                Console.WriteLine(movimentacao.Valor + (movimentacao.EntradaDinheiro ? " (entrada)" : " (saída)"));
            }

            Console.WriteLine("Extrato da conta 2:");
            foreach (Movimentacao movimentacao in conta2.Extrato())
            {
                Console.WriteLine(movimentacao.Valor + (movimentacao.EntradaDinheiro ? " (entrada)" : " (saída)"));
            }

            //Movimentacao movimentacao = new Movimentacao();

            //ContaCorrente conta1 = new ContaCorrente();
            //conta1.saldo = 1000;
            //conta1.numero = 12;
            //conta1.limite = 0;
            //conta1.ehEspecial = true;

            //conta1.Sacar(200);

            //conta1.Depositar(300);

            //conta1.Depositar(500);

            //conta1.Sacar(200);

            //ContaCorrente conta2 = new ContaCorrente();
            //conta2.saldo = 300;
            //conta2.numero = 13;
            //conta2.limite = 0;
            //conta2.ehEspecial = true;

            //movimentacao.TransferirPara(conta2, 400);

            //conta1.Sacar(200);

            //Console.ReadKey();
        }
    }
}