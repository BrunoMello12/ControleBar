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

        public string VisualizarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Digite 1 para gerenciar Garçons");
            Console.WriteLine("Digite 2 para gerenciar Mesas");
            Console.WriteLine("Digite 3 para gerenciar Produtos");
            Console.WriteLine("Digite 4 para gerenciar Contas");
            Console.WriteLine("Digite s para sair");

            string opcaoMenuPrincipal = Console.ReadLine();

            return opcaoMenuPrincipal;
        }

        public void Menu()
        { 
            while (true)
            {
                TelaBase tela = SelecionarTela();

                if (tela == null)
                    break;

                if (tela is TelaConta)
                    CadastrarContas(tela);
                else
                    ExecutarCadastros(tela);
            }
        }

        private void CadastrarContas(TelaBase tela)
        {
            string subMenu = tela.ApresentarMenu();

            TelaConta telaConta = (TelaConta)tela;

            switch (subMenu)
            {
                case "1": telaConta.InserirNovoRegistro(); break;
                case "2": telaConta.RegistrarPedidos(); break;
                case "3": telaConta.FecharConta(); break;
                case "4": telaConta.VisualizarRegistros(false); Console.ReadLine(); break;
                case "5": telaConta.VisualizarFaturamentoDoDia(); Console.ReadLine(); break;
            }
        }

        private void ExecutarCadastros(TelaBase tela)
        {
            string subMenu = tela.ApresentarMenu();

            switch(subMenu)
            {
                case "1": tela.InserirNovoRegistro(); break;
                case "2": tela.VisualizarRegistros(false); Console.ReadLine(); break;
                case "3": tela.EditarRegistro(); break;
                case "4": tela.ExcluirRegistro(); break;
            }
        }

        public TelaBase SelecionarTela()
        {
            string opcao = VisualizarMenuPrincipal();

            switch (opcao)
            {
                case "1": return telaGarcom;
                case "2": return telaMesa;
                case "3": return telaProduto;
                case "4": return telaConta;
            }

            return null;
        }
    }
}
