using Arnald.Series.Interfaces;

namespace Arnald.Series.src.Classes.Enum
{
    public class FilmeRepositorio : IRepositorio<Filmes>
    {
        private List<Filmes> listaFilmes = new List<Filmes>();
        public virtual void Atualiza(int id, Filmes objeto)
        {
            listaFilmes[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaFilmes[id].Excluir();
        }

        public void Insere(Filmes objeto)
        {
            listaFilmes.Add(objeto);
        }

        public List<Filmes> Lista()
        {
            return listaFilmes;
        }

        public int ProximoId()
        {
            return listaFilmes.Count;
        }

        public Filmes RetornaPorId(int id)
        {
            return listaFilmes[id];
        }
    }
    
}