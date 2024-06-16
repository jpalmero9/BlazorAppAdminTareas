using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppAdminTareas.Entities
{
    [Table("Tareas")]
    public class LasTareas
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public EstadoTarea Estado { get; set; }
        public bool EstaBloqueada { get; set; }
    }

    public enum EstadoTarea
    {
        Planificada,
        Iniciada,
        EnCurso,
        Completada
    }
}
