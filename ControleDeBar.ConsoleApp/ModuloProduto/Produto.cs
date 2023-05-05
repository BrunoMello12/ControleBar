using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class Produto : EntidadeBase<Produto>
    {
        public string nome;
        public int valor;

        public Produto(int id, string nome, int valor)
        {
            this.id = id;
            this.nome = nome;
            this.valor = valor;
        }

        public override void AtualizarInformacoes(Produto produtoAtualizado)
        {
            this.nome = produtoAtualizado.nome;
            this.valor = produtoAtualizado.valor;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (valor == null)
                erros.Add("O campo \"valor\" é obrigatório");

            return erros;
        }
    }
}
