using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class TTipoIdentificacion
{
    public Guid Id { get; set; }

    public string TipoIdentificacion { get; set; } = null!;

    public virtual ICollection<TPersonaNatural> TPersonaNaturals { get; set; } = new List<TPersonaNatural>();
}
