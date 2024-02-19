using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class TTipoMovimiento
{
    public Guid Id { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public virtual ICollection<TMovimiento> TMovimientos { get; set; } = new List<TMovimiento>();
}
