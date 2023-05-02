using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ControleDeBar.ConsoleApp
{
    public class Menus
    {
        private TelaGarcom telaGarcom;
        private TelaConta telaConta;
        private TelaMesa telaMesa;
        private TelaProduto telaProduto;

        public Menus(TelaGarcom telaGarcom, TelaConta telaConta, TelaMesa telaMesa, TelaProduto telaProduto)
        {
            this.telaGarcom = telaGarcom;
            this.telaConta = telaConta;
            this.telaMesa = telaMesa;
            this.telaProduto = telaProduto;
        }

        public void VisualizarMenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Digite 1 para gerenciar Garçons");
                Console.WriteLine("Digite 2 para gerenciar Mesas");
                Console.WriteLine("Digite 3 para gerenciar Produtos");
                Console.WriteLine("Digite 4 para gerenciar Contas");
                Console.WriteLine("Digite s para sair");

                string opcaoMenuPrincipal = Console.ReadLine();

                if (opcaoMenuPrincipal == "s" || opcaoMenuPrincipal == "S")
                {
                    Console.WriteLine("Saindo...");
                    break;
                }

                switch (opcaoMenuPrincipal)
                {
                    case "1": VisualizarMenuGarcom(); break;
                    case "2": VisualizarMenuMesas(); break;
                    case "3": VisualizarMenuProdutos(); break;
                    case "4": VisualizarMenuContas(); break;
                }
            }
        }

        public void VisualizarMenuGarcom()
        {
            string opcaoMenuGarcom = telaGarcom.ApresentarMenu();

            switch (opcaoMenuGarcom)
            {
                case "1": telaGarcom.InserirNovoRegistro(); break;
                case "2": telaGarcom.VisualizarRegistros(false); break;
                case "3": telaGarcom.EditarRegistro(); break;
                case "4": telaGarcom.ExcluirRegistro(); break;
            }
        }

        public void VisualizarMenuMesas()
        {
            string opcaoMenuMesas = telaMesa.ApresentarMenu();

            switch (opcaoMenuMesas)
            {
                case "1": telaMesa.InserirNovoRegistro(); break;
                case "2": telaMesa.VisualizarRegistros(false); Console.ReadLine(); break;
                case "3": telaMesa.EditarRegistro(); break;
                case "4": telaMesa.ExcluirRegistro(); break;
            }
        }

        public void VisualizarMenuProdutos()
        {
            string opcaoMenuProduto = telaProduto.ApresentarMenu();

            switch(opcaoMenuProduto)
            {
                case "1": telaProduto.InserirNovoRegistro(); break;
                case "2": telaProduto.VisualizarRegistros(false); Console.ReadLine(); break;
                case "3": telaProduto.EditarRegistro(); break;
                case "4": telaProduto.ExcluirRegistro(); break;
            }
        }

        public void VisualizarMenuContas()
        {
            Console.Clear();
            Console.WriteLine("Digite 1 para Abrir uma conta");
            Console.WriteLine("Digite 2 para Registrar Pedidos");
            Console.WriteLine("Digite 3 para Fechar uma conta");
            Console.WriteLine("Digite 4 para Visualizar Contas abertas");
            Console.WriteLine("Digite 5 para visualizar Total faturado no dia");

            string opcaoMenuContas = Console.ReadLine();

            switch(opcaoMenuContas) 
            {
                case "1": telaConta.InserirNovoRegistro(); break;
                case "2": telaConta.RegistrarPedidos(); break;
                case "3": telaConta.FecharConta(); break;
                case "4": telaConta.VisualizarRegistros(false); Console.ReadLine(); break;
                case "5": telaConta.VisualizarFaturamentoDoDia(); Console.ReadLine(); break;
            }
        }
    }
}
