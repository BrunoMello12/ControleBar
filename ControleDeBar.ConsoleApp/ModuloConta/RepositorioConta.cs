using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloPedido;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class RepositorioConta : RepositorioBase
    {
        public double Total()
        {
            double totalDeContas = 0;

            foreach(Conta conta in listaRegistros)
            {
                if(conta.data == DateTime.Now.Date)
                {
                    conta.CalcularValorTotal();
                    totalDeContas += conta.CalcularValorTotal();
                }
            }
            return totalDeContas;
        }
    }
}
