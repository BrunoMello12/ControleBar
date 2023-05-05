using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp
{
    public interface ITelaCadastravel
    {
        public string ApresentarMenu();

        public void InserirNovoRegistro();

        public void VisualizarRegistros(bool mostrarCabecalho);

        public void EditarRegistro();

        public void ExcluirRegistro();

    }
}
