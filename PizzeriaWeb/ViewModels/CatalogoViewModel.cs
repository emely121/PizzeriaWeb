namespace PizzeriaWeb.ViewModels;

public class ProductoCatalogoItem
{
    public int Id { get; set; }
    public int CategoriaId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public string? ImagenUrl { get; set; }
    public long? UnidadesVendidas { get; set; }
}

public class CategoriaFiltroItem
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
}

public class CatalogoViewModel
{
    public string? Busqueda { get; set; }
    public int? CategoriaId { get; set; }
    public List<CategoriaFiltroItem> Categorias { get; set; } = new();
    public List<ProductoCatalogoItem> Productos { get; set; } = new();
    public List<ProductoCatalogoItem> MasVendidos { get; set; } = new();
}
