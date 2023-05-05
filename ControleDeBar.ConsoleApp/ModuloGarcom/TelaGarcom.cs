using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class TelaGarcom : TelaBase<RepositorioGarcom, Garcom>
    {
        private RepositorioGarcom repositorioGarcom;

        public TelaGarcom(RepositorioGarcom repositorioGarcom)
        {
            this.repositorioBase = repositorioGarcom;
            this.repositorioGarcom = repositorioGarcom;
            nomeEntidade = "Garçom";
        }

        protected override void MostrarTabela(List<Garcom> garcoms)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Nome", "Cpf");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Garcom garcom in garcoms)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", garcom.id, garcom.nome, garcom.cpf);
            }

            Console.ResetColor();
        }

        protected override Garcom ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o cpf: ");
            string cpf = Console.ReadLine();

            return new Garcom(repositorioGarcom.contadorRegistros,nome, cpf);
        }
    }
}
