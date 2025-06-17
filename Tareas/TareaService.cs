using System.Text.Json;
using Tareas.models;


namespace Tareas.services;

public class TareaService
{
  /* https://jsonplaceholder.typicode.com/todos/ */

  public static HttpClient client = new HttpClient();
  public static string url = "https://jsonplaceholder.typicode.com/todos";

  public static async Task<List<Tarea>> GetTareas()
  {

    HttpResponseMessage response = await client.GetAsync(url);
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();
    List<Tarea> tareas = JsonSerializer.Deserialize<List<Tarea>>(responseBody);
    return tareas;
  }

  /* A la lista completa de tareas y serialízala nuevamente a formato JSON y guarda el
resultado en un archivo llamado tareas.json en el directorio de ejecución de la
aplicación. */

  public static void SaveTareas(List<Tarea> tareas)
  {
    string json = JsonSerializer.Serialize(tareas);
    File.WriteAllText("tareas.json", json);
  }

}