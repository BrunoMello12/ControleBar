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
    public class Conta : EntidadeBase<Conta>
    {
        public string nome;
        public Mesa mesa;
        public string status;
        public ArrayList listaPedidos = new ArrayList();
        public int total;
        public DateTime data;

        public Conta(int id, string nome, Mesa mesa)
        {
            this.id = id;
            this.nome = nome;
            this.mesa = mesa;
            status = "ABERTO";
            this.data = DateTime.Now.Date;
        }

        public double CalcularValorTotal()
        {
            total = 0;
            foreach (Pedido pedido in listaPedidos)
            {
                total += pedido.CalcularValor();
            }
            return total;
        }

        public void FecharConta(Conta conta)
        {
            conta.status = "FECHADO";
        }

        public override void AtualizarInformacoes(Conta contaAtualizada)
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
