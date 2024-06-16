using BlazorAppAdminTareas.Contracts;
using BlazorAppAdminTareas.Entities;

namespace BlazorAppAdminTareas.Repository
{
    public class TareasService : ITareasService
    {
        private readonly ITareaRepository _repositorio;

        public TareasService(ITareaRepository repository)
        {
            _repositorio = repository;
        }

        public async Task<IEnumerable<LasTareas>> ObtenerTareasAsync(int numeroPagina, int tamanoPagina)
        {
            return await _repositorio.ObtenerTareasAsync(numeroPagina, tamanoPagina);
        }

        public async Task<LasTareas> ObtenerTareaPorIdAsync(int id)
        {
            return await _repositorio.ObtenerTareaPorIdAsync(id);
        }

        public async Task AgregarTareaAsync(LasTareas tarea)
        {
            await _repositorio.AgregarTareaAsync(tarea);
        }

        public async Task ActualizarTareaAsync(LasTareas tarea)
        {
            await _repositorio.ActualizarTareaAsync(tarea);
        }

        public async Task EliminarTareaAsync(int id)
        {
            await _repositorio.EliminarTareaAsync(id);
        }

        public async Task EliminarTareasAsync(IEnumerable<int> ids)
        {
            await _repositorio.EliminarTareasAsync(ids);
        }

        public async Task ActualizarEstadoTareaAsync(int id, EstadoTarea nuevoEstado)
        {
            var tarea = await _repositorio.ObtenerTareaPorIdAsync(id);
            if (tarea != null)
            {
                if ((int)nuevoEstado > (int)tarea.Estado)
                {
                    tarea.Estado = nuevoEstado;
                    await _repositorio.ActualizarTareaAsync(tarea);
                }
                else
                {
                    throw new InvalidOperationException("No se puede mover la tarea a un estado anterior.");
                }
            }
        }
    }
}
