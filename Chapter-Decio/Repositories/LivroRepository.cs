using Chapter_Decio.Contexts;
using Chapter_Decio.Controllers;
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
            return _context.Livros.Find(id);
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
                int QuantidadePaginas = livro.QuantidadePaginas;
                LivroBuscado.QuantidadePaginas = QuantidadePaginas;
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

        internal void Cadastrar(LivroController livro)
        {
            throw new NotImplementedException();
        }

        internal void Atualizar(int id, LivroController livro)
        {
            throw new NotImplementedException();
        }
    }

}
