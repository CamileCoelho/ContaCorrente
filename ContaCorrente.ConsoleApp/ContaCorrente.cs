using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    internal class ContaCorrente
    {

        int numero;
        decimal saldo;
        bool especial;
        decimal limite;
        List<Movimentacao> movimentacoes;

        public ContaCorrente(int numero, decimal saldo, bool especial, decimal limite)
        {
            this.numero = numero;
            this.saldo = saldo;
            this.especial = especial;
            this.limite = limite;
            this.movimentacoes = new List<Movimentacao>();
        }
        public decimal Saldo
        {
            get { return this.saldo; }
        }
        public decimal Limite
        {
            get { return this.limite; }
        }

        public bool Especial
        {
            get { return this.especial; }
        }

        public void Depositar(decimal valor)
        {
            this.saldo += valor;
            this.movimentacoes.Add(new Movimentacao() { Valor = valor, EntradaDinheiro = true });
        }

        public void Sacar(decimal valor)
        {
            decimal limiteSaque = this.limite + this.saldo;
            if (valor <= limiteSaque)
            {
                this.saldo -= valor;
                this.movimentacoes.Add(new Movimentacao() { Valor = valor, EntradaDinheiro = false });
            }
            else
            {
                throw new Exception("Saque não permitido. Valor excede o limite de saque.");
            }
        }
        public List<Movimentacao> Extrato()
        {
            return this.movimentacoes;
        }

        public decimal VisualizarSaldo()
        {
            return this.saldo;
        }

        public List<Movimentacao> VisualizarExtrato()
        {
            return this.movimentacoes;
        }

        public void Transferir(decimal valor, ContaCorrente contaDestino)
        {
            if (valor <= this.saldo)
            {
                this.saldo -= valor;
                contaDestino.Depositar(valor);
                this.movimentacoes.Add(new Movimentacao() { Valor = valor, EntradaDinheiro = false });
                contaDestino.movimentacoes.Add(new Movimentacao() { Valor = valor, EntradaDinheiro = true });
            }
            else
            {
                throw new Exception("Transferência não permitida. Valor excede o saldo da conta.");
            }
        }
    }
}
