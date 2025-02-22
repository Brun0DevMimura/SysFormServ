using System.Collections.Generic;
using System.Linq;
namespace USANDOVIEWS.Models
{
    public class Usuario{
        public int IdUsuario {get; set;}

        public string Nome {get; set;}

        public string Email{get; set;}


        private static List<Usuario> listagem = new List<Usuario>();

        public static IQueryable<Usuario> Listagem{
            get{
                return listagem.AsQueryable();//Listagem somente consulta
            }
        }

        static Usuario(){
            Usuario.listagem.Add(new Usuario {IdUsuario=1,Nome="Fulano",Email="fulano@email.com"});
            Usuario.listagem.Add(new Usuario {IdUsuario=2,Nome="Sicrano",Email="Sicrano@email.com"});
            Usuario.listagem.Add(new Usuario {IdUsuario=3,Nome="Beltrano",Email="beltrano@email.com"});
            Usuario.listagem.Add(new Usuario {IdUsuario=4,Nome="João",Email="joao@email.com"});
            Usuario.listagem.Add(new Usuario {IdUsuario=5,Nome="Maria",Email="maria@email.com"});
        }

        public static void Salvar(Usuario usuario){
            var usuarioExistente = Usuario.listagem.Find(u=>u.IdUsuario == usuario.IdUsuario);
            if(usuarioExistente != null){
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Email = usuario.Email;
            }
            else{
                int marioId = Usuario.Listagem.Max(u => u.IdUsuario);
                usuario.IdUsuario = marioId + 1;
                Usuario.listagem.Add(usuario);
            }
        }

        
        public static bool Excluir(int idUsuario){
            var usuarioExistente = Usuario.listagem.Find(u=>u.IdUsuario == idUsuario);
            if(usuarioExistente != null){
               return Usuario.listagem.Remove(usuarioExistente);
            }
            return false; 
        }
    }
}