using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class TelaMesa : TelaBase<RepositorioMesa, Mesa>
    {
        private RepositorioMesa repositorioMesa;

        public TelaMesa(RepositorioMesa repositorioMesa)
        {
            this.repositorioBase = repositorioMesa;
            this.repositorioMesa = repositorioMesa;
            nomeEntidade = "Mesa";
            sufixo = "s";
        }

        protected override void MostrarTabela(List<Mesa> mesas)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0, -10} | {1, -20}", "Id", "Mesa");

            Console.WriteLine("------------------------------");

            foreach (Mesa mesa in mesas)
            {
                Console.WriteLine("{0, -10} | {1, -20}", mesa.id, "Mesa" + mesa.numeroMesa);
            }

            Console.ResetColor();
        }

        protected override Mesa ObterRegistro()
        {
            Console.Write("Digite o numero da mesa: ");
            string numeroMesa = Console.ReadLine();

            return new Mesa(repositorioMesa.contadorRegistros,numeroMesa);
        }
    }
}
