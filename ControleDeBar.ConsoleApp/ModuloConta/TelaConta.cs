using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloPedido;
using ControleDeBar.ConsoleApp.ModuloProduto;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class TelaConta : TelaBase
    {
        Pedido pedido;
        Conta conta;
        private RepositorioConta repositorioConta;
        private RepositorioMesa repositorioMesa;
        private TelaMesa telaMesa;
        private TelaProduto telaProduto;
        private RepositorioProduto repositorioProduto;

        public TelaConta(RepositorioConta repositorioConta, TelaMesa telaMesa, RepositorioMesa repositorioMesa, TelaProduto telaProduto, RepositorioProduto repositorioProduto)
        {
            this.repositorioBase = repositorioConta;
            this.repositorioConta = repositorioConta;
            this.telaMesa = telaMesa;
            this.repositorioMesa = repositorioMesa;
            this.telaProduto = telaProduto;
            this.repositorioProduto = repositorioProduto;
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            if(conta.status == "ABERTO")
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Nome", "Mesa");

                Console.WriteLine("------------------------------------------------------");

                foreach (Conta conta in registros)
                {
                    Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", conta.id, conta.nome, conta.mesa.numeroMesa);
                }
            }
        }

        public void RegistrarPedidos()
        {
            Pedido pedido = new Pedido();

            telaProduto.VisualizarRegistros(false);
            Console.WriteLine();
            telaMesa.VisualizarRegistros(false);
            Console.WriteLine();

            Console.WriteLine("Informe o produto: ");
            int idSelecionado = int.Parse(Console.ReadLine());
            pedido.produto = (Produto)repositorioProduto.SelecionarPorId(idSelecionado);

            Console.WriteLine("Informe a quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());

            pedido.produto.valor *= quantidade;

            Console.WriteLine("Informe a mesa que deseja fazer o pedido: ");
            int id = int.Parse(Console.ReadLine());
            pedido.mesa = (Mesa)repositorioMesa.SelecionarPorId(id);


            pedido.Pedidos.Add(pedido);

            MostrarMensagem("Pedido registrado com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarFaturamentoDoDia()
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "ID", "Produto", "Mesa");

            Console.WriteLine("------------------------------------------------------");
            foreach (Pedido pedido in pedido.Pedidos)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {1, -20}", pedido.id, pedido.produto, pedido.mesa);
                pedido.Total += pedido.produto.valor;
            }

            Console.WriteLine($"O total faturado no Dia foi de: {pedido.Total}");
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaMesa.VisualizarRegistros(false);

            Console.WriteLine();
            Console.Write("Informe o id da mesa: ");
            int idSelecionado = int.Parse(Console.ReadLine());
            Mesa mesa = (Mesa)repositorioMesa.SelecionarPorId(idSelecionado);

            Console.Write("Informe o nome da conta: ");
            string nome = Console.ReadLine();

            return new Conta(nome, mesa);
        }

        public void FecharConta()
        {
            MostrarTabela(repositorioConta.listaRegistros);

            Console.WriteLine();
            Console.WriteLine("Informe o id da conta que deseja fechar: ");
            int idSelecionado = int.Parse(Console.ReadLine());
            Conta conta = (Conta)repositorioConta.SelecionarPorId(idSelecionado);
            repositorioConta.FecharConta(conta);

            MostrarMensagem("Conta fechada com sucesso!", ConsoleColor.Green);
        }
    }
}
