using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class TelaProduto : TelaBase
    {
        public TelaProduto(RepositorioProduto repositorioProduto)
        {
            this.repositorioBase = repositorioProduto;
            nomeEntidade = "Produto";
            sufixo = "s";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Nome", "Valor");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Produto produto in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", produto.id, produto.nome, produto.valor);
            }

            Console.ResetColor();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            int valor = 0;
            bool valorInvalido;

            do
            {
                valorInvalido = false;
                try
                {
                    Console.Write("Digite o preço: ");
                    valor = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    valorInvalido = true;
                    MostrarMensagem("Valor inválido, tente novamente", ConsoleColor.Red);

                }
            } while (valorInvalido);
            
            return new Produto(nome, valor);

        }
    }
}
