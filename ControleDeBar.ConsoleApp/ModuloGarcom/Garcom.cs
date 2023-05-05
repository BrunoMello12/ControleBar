using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class Garcom : EntidadeBase<Garcom>
    {
        public string nome;
        public string cpf;

        public Garcom(int id, string nome, string cpf)
        {
            this.id = id;
            this.nome = nome;
            this.cpf = cpf;
        }

        public override void AtualizarInformacoes(Garcom garcomAtualizado)
        {
            this.nome = garcomAtualizado.nome;
            this.cpf = garcomAtualizado.cpf;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(cpf.Trim()))
                erros.Add("O campo \"cpf\" é obrigatório");

            return erros;
        }
    }
}
