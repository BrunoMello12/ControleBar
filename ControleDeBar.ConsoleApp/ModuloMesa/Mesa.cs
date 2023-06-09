﻿using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase<Mesa>
    {
        public string numeroMesa;

        public Mesa(int id, string numeroMesa)
        {
            this.id = id;
            this.numeroMesa = numeroMesa;
        }

        public override void AtualizarInformacoes(Mesa mesaAtualizada)
        {
            this.numeroMesa = mesaAtualizada.numeroMesa;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(numeroMesa.Trim()))
                erros.Add("O campo \"número da mesa\" é obrigatório");

            return erros;
        }
    }
}
