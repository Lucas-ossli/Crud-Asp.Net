

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace aspnet.Models{
    public class Usuario{
        
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo Nome deve ser preenchido")]
        public string Nome{get;set;}

        [Required(ErrorMessage ="O campo Email deve ser preenchido")]
        public string Email { get; set; }

        private static List<Usuario> listagem = new List<Usuario>();
        
        public static IQueryable<Usuario> Listagem
        {
            get
            {
                return listagem.AsQueryable();
            }
        }

        static Usuario()
        {
            Usuario.listagem.Add(new Usuario {Id=1, Nome="Fulano", Email="Fulano@email.com"});
            Usuario.listagem.Add(new Usuario {Id=2, Nome="Siclano", Email="Siclano@email.com"});
            Usuario.listagem.Add(new Usuario {Id=3, Nome="Beltrano", Email="Beltrano@email.com"});
            Usuario.listagem.Add(new Usuario {Id=4, Nome="teste", Email="teste@email.com"});
            
        }

        public static void Salvar(Usuario usuario)
        {
            var usuarioExistente = listagem.Find(i => i.Id == usuario.Id);
            if(usuarioExistente != null)
            {
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Email = usuario.Email;
            }
            else
            {
                int maiorId = Usuario.Listagem.Max(i => i.Id);
                usuario.Id = maiorId + 1;
                Usuario.listagem.Add(usuario);
            }

           
        }

        public static bool Excluir(int? idUsuario){
            
            var usuarioExistente = Usuario.listagem.Find(i => i.Id == idUsuario);
            if(usuarioExistente != null){
                return listagem.Remove(listagem.Find(i => i.Id == idUsuario));
            }

            return false;
            
        }
    }
}