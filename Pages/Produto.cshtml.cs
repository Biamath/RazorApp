using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace At_Net_Q4.Pages
{
    public class ProdutoModel : PageModel
    {
        public List<Produto> Produtos { get; set; } = new List<Produto>(); 

        [BindProperty]
        public Produto NovoProduto { get; set; } 
        public void OnGet()
        {
            CarregarProdutosDaSessao();

            if (Produtos.Count == 0) 
            {
                Produtos = new List<Produto>
                {
                    new Produto {Descricao="Peixe",Preco=9.50m},
                    new Produto {Descricao="Alface",Preco=3.50m},
                    new Produto {Descricao="Salame",Preco=15.0m},
                    new Produto {Descricao="Ovo",Preco=9.99m},
                    new Produto {Descricao="Queijo",Preco=35.50m},
                    new Produto {Descricao="Carne",Preco=40.99m},
                    new Produto {Descricao="Uva",Preco=8.50m},
                    new Produto {Descricao="Pera",Preco=15.50m},
                    new Produto {Descricao="Açúcar",Preco=8.50m},
                };

                SalvarProdutosNaSessao();
            }
        }

        
        public IActionResult OnPost()
        {
            CarregarProdutosDaSessao();

            if (!string.IsNullOrWhiteSpace(NovoProduto.Descricao) && NovoProduto.Preco > 0)
            {
                Produtos.Add(NovoProduto);
                SalvarProdutosNaSessao();
                CarregarProdutosDaSessao();
                
            }

            return Page(); 
        }
        private void CarregarProdutosDaSessao()
        {
            var produtosJson = HttpContext.Session.GetString("Produtos");
            if (!string.IsNullOrEmpty(produtosJson))
            {
                Produtos = JsonSerializer.Deserialize<List<Produto>>(produtosJson);
            }
        }

        // Salva a lista de produtos na sessão
        private void SalvarProdutosNaSessao()
        {
            var produtosJson = JsonSerializer.Serialize(Produtos);
            HttpContext.Session.SetString("Produtos", produtosJson);
        }
    }

    public class Produto
    {
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
