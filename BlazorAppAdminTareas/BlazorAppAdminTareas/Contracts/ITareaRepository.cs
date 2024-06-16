
using BlazorAppAdminTareas.Entities;

namespace BlazorAppAdminTareas.Contracts
{
    public interface ITareaRepository
    {

        Task<IEnumerable<LasTareas>> ObtenerTareasAsync(int numeroPagina, int tamanoPagina);
        Task<LasTareas> ObtenerTareaPorIdAsync(int id);
        Task AgregarTareaAsync(LasTareas tarea);
        Task ActualizarTareaAsync(LasTareas tarea);
        Task EliminarTareaAsync(int id);
        Task EliminarTareasAsync(IEnumerable<int> ids);
    }
}
