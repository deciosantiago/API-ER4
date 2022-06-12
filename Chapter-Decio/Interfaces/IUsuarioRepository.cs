using Chapter_Decio.Models;

namespace Chapter_Decio.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarPorId(int id);

        void Cadastrar(Usuario usuario);

        void Atualizar(int id, Usuario usuario);

        void deletar(int id);

        Usuario Login(string email, string senha);
        void Deletar(int id);
        void Atualizar(int id);
    }
}
