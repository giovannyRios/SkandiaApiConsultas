using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class TTipoPersona
{
    public Guid Id { get; set; }

    public string TipoPersona { get; set; } = null!;

    public virtual ICollection<TPersonaInfoExtra> TPersonaInfoExtras { get; set; } = new List<TPersonaInfoExtra>();

    public virtual ICollection<TPersonaJuridica> TPersonaJuridicas { get; set; } = new List<TPersonaJuridica>();

    public virtual ICollection<TPersonaNatural> TPersonaNaturals { get; set; } = new List<TPersonaNatural>();
}
