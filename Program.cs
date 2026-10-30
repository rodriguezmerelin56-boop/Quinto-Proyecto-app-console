using System.ComponentModel.Design;
using System.Runtime.Serialization;
using QuintoProyecto.models;
using QuintoProyecto.service;
using Spectre.Console;

class Program {

public static bool running = true;
 public static string[] opciones = [
    "1. mostrar productos",
    "2. eliminar un producto",
    "3. agregar un producto",
    "4. salir"
];
public static void Main (){
    Productoservice productoService = new Productoservice();

while (running){


var selection = new SelectionPrompt <string>()
.Title("[green]indica la accion a realizar:[/]")
.HighlightStyle("blue")
.AddChoices(opciones);

var opcion = AnsiConsole.Prompt(selection);
List<Producto> productos = productoService.FindAll();


Console.WriteLine(opcion);

switch (opcion)
            {
                case "1. mostrar productos":
                Console.WriteLine("opcion 1");

                var table = new Table();
                table.AddColumn("id");
                table.AddColumn("nombre");
                table.AddColumn("detalles");

                foreach (Producto producto in productos)

                    {
                        table.AddRow(
                            producto.Id.ToString(),
                            producto.nombre,
                            producto.detalles
                        );
                    }
                    AnsiConsole.Write(table);
                break;
                case "2. eliminar un producto":
                   AnsiConsole.Clear();
          int id = AnsiConsole.Ask<int>("Indica el id que quieres eliminar: ");

          AnsiConsole.WriteLine("");
          var confirmed = AnsiConsole.Confirm("¿Estás seguro?");

          if (confirmed) {
            bool deleted = productoService.Delete(id);

            if (deleted) {
              AnsiConsole.MarkupLine("\n[DarkOliveGreen1_1]Libro eliminado![/]\n");
              break;
            }

            AnsiConsole.MarkupLine("\n[red]Libro no encontrado![/]\n");
          }
          else {
            AnsiConsole.MarkupLine("\n[yellow]Operación cancelada![/]\n");

          }
                break;

                case "3. agregar un producto":
                AnsiConsole.Clear();
          string nombre = AnsiConsole.Ask<string>("[Aquamarine1_1]Indica el nombre del prodcuto: [/]");
          string detalles = AnsiConsole.Ask<string>("[Aquamarine1_1]agrega los detalles del producto: [/]");

          var maxId = productos.Max((b) => b.Id);

          Producto newproducto = new() {
            Id = maxId + 1,
            nombre = nombre,
            detalles = detalles
              
          };
          productoService.Create(newproducto);
          AnsiConsole.MarkupLine("\n[DarkOliveGreen1_1]Libro agregado![/]\n");
          break;
                

                case "4. salir":
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[yellow]fin del programa[/]");
                running = false;
                break;
                        }          
                          }

}

}
