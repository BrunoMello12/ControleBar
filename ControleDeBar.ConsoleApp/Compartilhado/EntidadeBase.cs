using System.Collections;

namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public int id;

        public abstract void AtualizarInformacoes(T registroAtualizado);

        public abstract ArrayList Validar();
        
    }
}