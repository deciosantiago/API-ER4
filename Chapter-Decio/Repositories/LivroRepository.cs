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
    }
}
