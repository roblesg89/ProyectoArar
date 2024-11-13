using System;
using System.Collections.Generic;

namespace ProyectoArar.Models;

public partial class Asignacione
{
    public int IdAsignacion { get; set; }

    public int IdJuego { get; set; }

    public int IdAlumno { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public virtual Alumno IdAlumnoNavigation { get; set; } = null!;

    public virtual Juego IdJuegoNavigation { get; set; } = null!;

    public virtual ICollection<Progreso> Progresos { get; set; } = new List<Progreso>();
}
