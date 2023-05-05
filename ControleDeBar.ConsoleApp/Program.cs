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
            RepositorioGarcom repositorioGarcom = new RepositorioGarcom(new());
            RepositorioConta repositorioConta = new RepositorioConta(new());
            RepositorioMesa repositorioMesa = new RepositorioMesa(new());  
            RepositorioProduto repositorioProduto = new RepositorioProduto(new());


            TelaGarcom telaGarcom = new TelaGarcom(repositorioGarcom);
            TelaMesa telaMesa = new TelaMesa(repositorioMesa);
            TelaProduto telaProduto = new TelaProduto(repositorioProduto);
            TelaConta telaConta = new TelaConta(repositorioConta, telaMesa, repositorioMesa, telaProduto, repositorioProduto, repositorioGarcom, telaGarcom);

            Menus menu = new Menus(telaGarcom, telaConta, telaMesa, telaProduto);

            Garcom garcom1 = new Garcom(0, "Vanessa", "123456");
            Garcom garcom2 = new Garcom(1, "Lara", "123456");
            Garcom garcom3 = new Garcom(2, "Carlos", "123456");
            Garcom garcom4 = new Garcom(3, "Mario", "123456");

            repositorioGarcom.listaRegistros.Add(garcom1);
            repositorioGarcom.listaRegistros.Add(garcom2);
            repositorioGarcom.listaRegistros.Add(garcom3);
            repositorioGarcom.listaRegistros.Add(garcom4);

            Mesa mesa1 = new Mesa(0, "1");
            Mesa mesa2 = new Mesa(1, "2");
            Mesa mesa3 = new Mesa(2, "3");
            Mesa mesa4 = new Mesa(3, "4");

            repositorioMesa.listaRegistros.Add(mesa1);
            repositorioMesa.listaRegistros.Add(mesa2);
            repositorioMesa.listaRegistros.Add(mesa3);
            repositorioMesa.listaRegistros.Add(mesa4);

            Produto produto1 = new Produto(0, "Fritas", 25);
            Produto produto2 = new Produto(1, "Xis", 15);
            Produto produto3 = new Produto(2, "Carne", 40);
            Produto produto4 = new Produto(3, "Batata", 70);

            repositorioProduto.listaRegistros.Add(produto1);
            repositorioProduto.listaRegistros.Add(produto2);
            repositorioProduto.listaRegistros.Add(produto3);
            repositorioProduto.listaRegistros.Add(produto4);

            Conta conta1 = new Conta(0, "01", mesa1);
            Conta conta2 = new Conta(1, "02", mesa2);
            Conta conta3 = new Conta(2, "10", mesa3);
            Conta conta4 = new Conta(3, "10", mesa4);

            repositorioConta.listaRegistros.Add(conta1);
            repositorioConta.listaRegistros.Add(conta2);
            repositorioConta.listaRegistros.Add(conta3);
            repositorioConta.listaRegistros.Add(conta4);

            Pedido pedido1 = new Pedido(produto1, garcom1, 2);
            Pedido pedido2 = new Pedido(produto2, garcom2, 3);
            Pedido pedido3 = new Pedido(produto3, garcom3, 2);
            Pedido pedido4 = new Pedido(produto4, garcom4, 1);

            conta1.listaPedidos.Add(pedido1);
            conta2.listaPedidos.Add(pedido2);
            conta3.listaPedidos.Add(pedido3);
            conta4.listaPedidos.Add(pedido4);

            menu.Menu();
        }
    }
}