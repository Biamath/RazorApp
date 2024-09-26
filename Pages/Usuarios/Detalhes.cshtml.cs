using At_Net_Q4.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace At_Net_Q4.Pages.Usuarios
{
	public class DetalhesModel : PageModel
	{
		public Usuario Usuario { get; set; }
		public IActionResult OnGet(int id)
		{
			var usuarios = CarregarUsuarios();
			Usuario = usuarios.FirstOrDefault(u => u.Id == id);
			if (Usuario == null)
			{
				return RedirectToPage("/Usuario/Index");
			}
			return Page();
		}


		public List<Usuario> CarregarUsuarios()
		{
			var Usuarios = new List<Usuario>();


			if (System.IO.File.Exists("usuarios.txt"))
			{
				var linhas = System.IO.File.ReadAllLines("usuarios.txt");
				foreach (var linha in linhas)
				{
					var dados = linha.Split('|');
					var usuario = new Usuario()
					{
						Id = int.Parse(dados[0]),
						Nome = dados[1],
						Email = dados[2],
						DataNascimento = DateTime.Parse(dados[3])


					};
					Usuarios.Add(usuario);
				}

			}
			return Usuarios;
		}
	}
}

