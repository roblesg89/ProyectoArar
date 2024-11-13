using System;
using System.Collections.Generic;

namespace ProyectoArar.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public virtual Alumno? AlumnoIdAlumnoNavigation { get; set; }

    public virtual ICollection<Alumno> AlumnoIdDocenteNavigations { get; set; } = new List<Alumno>();
}
