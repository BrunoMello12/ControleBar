using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloPedido
{
    public class Pedido
    {
        public Produto produto;
        public Garcom garcom;
        public int quantidade;

        public Pedido(Produto produto, Garcom garcom, int quantidade)
        {
            this.produto = produto;
            this.garcom = garcom;
            this.quantidade = quantidade;
        }

        public int CalcularValor()
        {
           return quantidade * produto.valor;
        }
    }
}
