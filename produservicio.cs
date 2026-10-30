
using QuintoProyecto.models;

namespace QuintoProyecto.service;

public class Productoservice
{
    private readonly List<Producto> _productos = new List<Producto>
    {
        new Producto
        {
            Id = 1,
            nombre = "milky_way_cakes",
            detalles = "media libra"
        },
        new Producto
        {
            Id = 2,
            nombre = "piña cakes",
            detalles = "una libra"
        }
    };

    // Retorna la lista de productos
    public List<Producto> FindAll()
    {
        return _productos;
    }


  public bool Delete(int id) {
    var producto = _productos.FirstOrDefault((b) => b.Id == id);

     
    if (producto is null) {
      return false;
    }

    
    _productos.Remove(producto); 

    return true;
    }
     
    
     public bool Create(Producto producto) {
    _productos.Add(producto);
    return true;
  }
}
