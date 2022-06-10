using Chapter_Decio.Contexts;
using Chapter_Decio.Models;

namespace Chapter_Decio.Repositories
{
    public class LivroRepository
    {

        private readonly ChapterContext _context;


        public LivroRepository(ChapterContext context)
        {
            _context = context;
        }

        public List<Livro> Listar()
        {
            return _context.Livros.ToList();
        }

        public Livro BuscarPorId(int id)
        {
            return _context.Livro.find(id);
        }


        public void Cadastrar(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }
        
        public void Atualizar(int id, Livro livro) 
        {
            Livro LivroBuscado = _context.Livros.Find(id);
            
            if (LivroBuscado != null)
	        {

                LivroBuscado.Titulo = livro.Titulo;
                LivroBuscado.QuantidadePaginas = Livro.QuantidadePaginas;
                LivroBuscado.Disponivel = livro.Disponivel;

	        }

            _context.Livros.Update(LivroBuscado);
            _context.SaveChanges();

        }

        public void Deletar(int id) 
        { 

            Livro livro = _context.Livros.Find(id);
            _context.Livros.Remove(livro);
            _context.SaveChanges();
        
        
        }

        
    
    }

}
