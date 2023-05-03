using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloPedido;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public string nome;
        public Mesa mesa;
        public string status;
        public ArrayList listaPedidos = new ArrayList();
        public int total = 0;
        public DateTime dataPedido;

        public Conta(string nome, Mesa mesa)
        {
            this.nome = nome;
            this.mesa = mesa;
            status = "ABERTO";
        }

        public double CalcularValorTotal()
        {
            foreach(Pedido pedido in listaPedidos)
            {
                total += pedido.produto.valor;
            }
            return total;
        }

        public void FecharConta(Conta conta)
        {
            conta.status = "FECHADO";
        }


        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");


            return erros;
        }
    }
}
