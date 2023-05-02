using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class TelaMesa : TelaBase
    {
        public TelaMesa(RepositorioMesa repositorioMesa)
        {
            this.repositorioBase = repositorioMesa;
            nomeEntidade = "Mesa";
            sufixo = "s";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20}", "Id", "Mesa");

            Console.WriteLine("------------------------------");

            foreach (Mesa mesa in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20}", mesa.id, "Mesa" + mesa.numeroMesa);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o numero da mesa: ");
            string numeroMesa = Console.ReadLine();

            return new Mesa(numeroMesa);
        }
    }
}
