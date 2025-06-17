
using Tareas.services;
using Tareas.models;



/* obtener las tareas de la api */
List<Tarea> tareas = await TareaService.GetTareas();


/* Filtrar las tareas */
List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasCompletadas = new List<Tarea>();

foreach (Tarea tarea in tareas)
{
  if (tarea.completed)
  {
    tareasCompletadas.Add(tarea);

  }
  else
  {
    tareasPendientes.Add(tarea);

  }
}

foreach (Tarea tarea in tareasPendientes)
{
  Console.WriteLine($"Tarea: {tarea.title} - Estado: Pendiente");
}

foreach (Tarea tarea in tareasCompletadas)
{
  Console.WriteLine($"Tarea: {tarea.title} - Estado: Completada");
}



/* guardar las tareas en un json */

TareaService.SaveTareas(tareas);