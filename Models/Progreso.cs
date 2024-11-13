using System;
using System.Collections.Generic;

namespace ProyectoArar.Models;

public partial class Progreso
{
    public int IdProgreso { get; set; }

    public int IdAsignacion { get; set; }

    public DateTime FechaJuego { get; set; }

    public int? Puntaje { get; set; }

    public int? TiempoJuego { get; set; }

    public string? NivelAlcanzado { get; set; }

    public virtual Asignacione IdAsignacionNavigation { get; set; } = null!;
}
