using At_Net_Q4.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace At_Net_Q4.Pages.Usuarios
{
    public class CriarModel : PageModel
    {
        [BindProperty] 
        public Usuario usuario { get; set; }
        public void OnGet()
        {
        }


        public IActionResult OnPost()
        {

            if(!ModelState.IsValid)
            {

                return Page();

            }
            else
            {
                using(var writer=new StreamWriter("usuarios.txt",true))
                {

                    writer.WriteLine(usuario.Nome+":"+usuario.Email+";"+usuario.DataNascimento);
                    return RedirectToPage("/Usuarios/Index");
                }
            }


        }
    }
}
