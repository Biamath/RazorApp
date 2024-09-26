using At_Net_Q4.Model;
using At_Net_Q4.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace At_Net_.Pages.Usuarios
{
	public class EditarModel : PageModel
	{
		[BindProperty]
		public Usuario Usuario { get; set; }
		public void OnGet(int id)
		{
			var usuarios = CarregarUsuarios();
		Usuario = usuarios.FirstOrDefault(u => u.Id == id);

		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			var linhas=System.IO.File.ReadAllLines("usuarios.txt").ToList();
			for(int i = 0; i < linhas.Count; i++)
			{
				var dados = linhas[i].Split('|');
				if (int.Parse(dados[0]) == Usuario.Id)
				{
					linhas[i] = Usuario.Id + ";" + Usuario.Nome + ";" + Usuario.Email + ";" + Usuario.DataNascimento;
					break;

				}
			}
			System.IO.File.WriteAllLines("usuarios.txt",linhas);
			return RedirectToPage("/Usuarios/Index");
		}

		
		public int Id { get; private set; }

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
				
