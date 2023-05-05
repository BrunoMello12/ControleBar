using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class RepositorioGarcom : RepositorioBase<Garcom>
    {
        public RepositorioGarcom(List<Garcom> listaGarcom)
        {
            listaRegistros = listaGarcom;
        }
    }
}
