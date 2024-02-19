using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class TTipoEmpresa
{
    public Guid Id { get; set; }

    public string TipoEmpresa { get; set; } = null!;

    public virtual ICollection<TPersonaJuridica> TPersonaJuridicas { get; set; } = new List<TPersonaJuridica>();
}
