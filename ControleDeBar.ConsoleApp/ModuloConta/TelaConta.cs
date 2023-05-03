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
        private RepositorioConta repositorioConta;
        private RepositorioMesa repositorioMesa;
        private TelaMesa telaMesa;
        private TelaProduto telaProduto;
        private RepositorioProduto repositorioProduto;
        private RepositorioGarcom repositorioGarcom;

        public TelaConta(RepositorioConta repositorioConta, TelaMesa telaMesa, RepositorioMesa repositorioMesa, TelaProduto telaProduto, RepositorioProduto repositorioProduto, RepositorioGarcom repositorioGarcom)
        {
            this.repositorioBase = repositorioConta;
            this.repositorioConta = repositorioConta;
            this.telaMesa = telaMesa;
            this.repositorioMesa = repositorioMesa;
            this.telaProduto = telaProduto;
            this.repositorioProduto = repositorioProduto;
            this.repositorioGarcom = repositorioGarcom;
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Nome", "Mesa");

            Console.WriteLine("------------------------------------------------------");

            foreach (Conta conta in registros)
            {
                if(conta.status == "ABERTO")
                {
                    Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", conta.id, conta.nome, conta.mesa.numeroMesa);
                }
            }

        }

        public void RegistrarPedidos()
        {

            telaProduto.VisualizarRegistros(false);
            Console.WriteLine();
            telaMesa.VisualizarRegistros(false);
            Console.WriteLine();

            if (repositorioProduto.TemRegistros() == false)
                return;

            if (repositorioMesa.TemRegistros() == false)
                return;

            Console.WriteLine("Informe o produto: ");
            int idSelecionado = int.Parse(Console.ReadLine());
            Produto produto = (Produto)repositorioProduto.SelecionarPorId(idSelecionado);

            Console.WriteLine("Informe a quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o id da conta que deseja fazer o pedido: ");
            int id = int.Parse(Console.ReadLine());
            Conta conta = (Conta)repositorioConta.SelecionarPorId(id);

            Console.WriteLine("Informe o garçom que está fazendo o pedido: ");
            int id2 = int.Parse(Console.ReadLine());

            Garcom garcom = (Garcom)repositorioGarcom.SelecionarPorId(id2);

            conta.listaPedidos.Add(new Pedido(produto, garcom, quantidade));

            MostrarMensagem("Pedido registrado com sucesso!", ConsoleColor.Green);
        }

        

        public void VisualizarFaturamentoDoDia()
        {
            double totalDia = 0;
            foreach(Conta conta in repositorioConta.listaRegistros)
            {
                totalDia += conta.CalcularValorTotal();
            }
            Console.WriteLine();
            Console.WriteLine($"O faturamento total do dia foi: {totalDia}");
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

            if (repositorioConta.TemRegistros() == false)
            {
                MostrarMensagem("Não tem contas cadastradas", ConsoleColor.DarkYellow);
                return;
            }
         
            Console.WriteLine();
            Console.WriteLine("Informe o id da conta que deseja fechar: ");
            int idSelecionado = int.Parse(Console.ReadLine());

            Conta conta = (Conta)repositorioConta.SelecionarPorId(idSelecionado);

            conta.FecharConta(conta);

            MostrarMensagem("Conta fechada com sucesso!", ConsoleColor.Green);
        }
    }
}
