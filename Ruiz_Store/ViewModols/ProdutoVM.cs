using Ruiz_Store.Models;
namespace Ruiz_Store.ViewModols;

    public class ProdutoVM
    {
        public Produto Produto { get; set; }
        public List<ProdutoFoto> Semelhantes { get; set; }
    }