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
    public class Produto : EntidadeBase
    {
        public string nome;
        public int valor;
        public string dataValidade;

        public Produto(string nome, int valor, string dataValidade)
        {
            this.nome = nome;
            this.valor = valor;
            this.dataValidade = dataValidade;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Produto produtoAtualizado = (Produto)registroAtualizado;

            this.nome = produtoAtualizado.nome;
            this.valor = produtoAtualizado.valor;
            this.dataValidade = produtoAtualizado.dataValidade;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (valor == null)
                erros.Add("O campo \"valor\" é obrigatório");

            if (string.IsNullOrEmpty(dataValidade.Trim()))
                erros.Add("O campo \"data de validade\" é obrigatório");

            return erros;
        }
    }
}
