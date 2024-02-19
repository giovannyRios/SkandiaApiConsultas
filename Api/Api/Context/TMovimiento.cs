using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class TMovimiento
{
    public Guid Id { get; set; }

    public decimal Movimiento { get; set; }

    public Guid TTipoMovimientoId { get; set; }

    public DateTime FechaMovimiento { get; set; }

    public Guid TProductoPersonaId { get; set; }

    public virtual TProductoPersona TProductoPersona { get; set; } = null!;

    public virtual TTipoMovimiento TTipoMovimiento { get; set; } = null!;
}
