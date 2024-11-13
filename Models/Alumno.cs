using System;
using System.Collections.Generic;

namespace ProyectoArar.Models;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public int? IdDocente { get; set; }

    public int? Edad { get; set; }

    public string? InformacionAdicional { get; set; }

    public virtual ICollection<Asignacione> Asignaciones { get; set; } = new List<Asignacione>();

    public virtual Usuario IdAlumnoNavigation { get; set; } = null!;

    public virtual Usuario? IdDocenteNavigation { get; set; }
}
