using System;
using System.Collections.Generic;

namespace ProyectoArar.Models;

public partial class Juego
{
    public int IdJuego { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? NivelDificultad { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<Asignacione> Asignaciones { get; set; } = new List<Asignacione>();
}
