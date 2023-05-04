using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloProduto;
using ControleDeBar.ConsoleApp.ModuloPedido;
using System.Collections;

namespace ControleDeBar.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioGarcom repositorioGarcom = new RepositorioGarcom();
            RepositorioConta repositorioConta = new RepositorioConta();
            RepositorioMesa repositorioMesa = new RepositorioMesa();  
            RepositorioProduto repositorioProduto = new RepositorioProduto();


            TelaGarcom telaGarcom = new TelaGarcom(repositorioGarcom);
            TelaMesa telaMesa = new TelaMesa(repositorioMesa);
            TelaProduto telaProduto = new TelaProduto(repositorioProduto);
            TelaConta telaConta = new TelaConta(repositorioConta, telaMesa, repositorioMesa, telaProduto, repositorioProduto, repositorioGarcom, telaGarcom);

            Menus menu = new Menus(telaGarcom, telaConta, telaMesa, telaProduto);

            
            menu.Menu();
        }
    }
}