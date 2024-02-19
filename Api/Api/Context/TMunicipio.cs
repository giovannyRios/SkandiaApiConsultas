using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class TMunicipio
{
    public Guid Id { get; set; }

    public string Municipio { get; set; } = null!;

    public Guid TDepartamentoId { get; set; }

    public virtual TDepartamento TDepartamento { get; set; } = null!;

    public virtual ICollection<TPersonaNatural> TPersonaNaturals { get; set; } = new List<TPersonaNatural>();
}
