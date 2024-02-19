using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class TProductoPersona
{
    public Guid Id { get; set; }

    public Guid TPersonaInfoExtraId { get; set; }

    public Guid TProductoId { get; set; }

    public virtual ICollection<TMovimiento> TMovimientos { get; set; } = new List<TMovimiento>();

    public virtual TPersonaInfoExtra TPersonaInfoExtra { get; set; } = null!;

    public virtual TProducto TProducto { get; set; } = null!;
}
