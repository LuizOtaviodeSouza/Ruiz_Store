using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ruiz_Store.Models;

namespace Ruiz_Store.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Produto(int id)
    {
        Produto produto = _db.Produtos
        .Where(produto => produto.id == id)
        .Include(produto => produto.Fotos)
        .SingleOrDefault();


        List<ProdutoFoto> semelhantes = _db.Produtos
        .Where(produto => produto.CategoriaId == produto.CategoriaId && p.Id != id)
        .Include(produto => p.Fotos)
        .Take(4)
        .ToList();

        ProdutoVM produtoVM = new(){
            Produto = produto
            Semelhantes = semelhantes
        };

        return View(produtoVM);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
 