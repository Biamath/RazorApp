using At_Net_Q4.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace At_Net_Q4.Pages.Usuarios
{
   
    public class IndexModel : PageModel
    {
        public List<Usuario> Usuarios { get; set; }
        public void OnGet()
        {
            Usuarios=new List<Usuario>();

            if(System.IO.File.Exists("usuarios.txt"))
            {
                var linhas = System.IO.File.ReadAllLines("usuarios.txt");
                foreach(var linha in linhas)
                {
                    var dados = linha.Split('|');

                    var usuario=new Usuario()
                    {
                        Nome = dados[0],
                        Email= dados[1],
                        DataNascimento = DateTime.Parse(dados[2])

                    };
                    Usuarios.Add(usuario);
                }
            }
        }
    }
}
