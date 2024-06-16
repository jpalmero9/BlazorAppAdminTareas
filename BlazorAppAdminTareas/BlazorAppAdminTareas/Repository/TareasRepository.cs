using BlazorAppAdminTareas.Contracts;
using BlazorAppAdminTareas.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlazorAppAdminTareas.Repository
{
    public class TareasRepository : ITareaRepository
    {
        private readonly  TareasContext _context;

        public TareasRepository(TareasContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<LasTareas>> ObtenerTareasAsync(int numeroPagina, int tamanoPagina)
        {
            return await _context.LasTareas
                                  .Skip((numeroPagina - 1) * tamanoPagina)
                                  .Take(tamanoPagina)
                                  .ToListAsync();
        }

        public async Task<LasTareas> ObtenerTareaPorIdAsync(int id)
        {
            return await _context.LasTareas.FindAsync(id);
        }

        public async Task AgregarTareaAsync(LasTareas tarea)
        {
            _context.LasTareas.Add(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarTareaAsync(LasTareas tarea)
        {
            _context.LasTareas.Update(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarTareaAsync(int id)
        {
            var tarea = await _context.LasTareas.FindAsync(id);
            if (tarea != null)
            {
                _context.LasTareas.Remove(tarea);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EliminarTareasAsync(IEnumerable<int> ids)
        {
            var tareas = _context.LasTareas.Where(t => ids.Contains(t.Id));
            _context.LasTareas.RemoveRange(tareas);
            await _context.SaveChangesAsync();
        }
    }
}
