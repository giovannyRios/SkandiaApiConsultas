using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class TTarjetaCredito
{
    public Guid Id { get; set; }

    public decimal CupoAprobado { get; set; }

    public decimal CupoDisponible { get; set; }

    public Guid TProductoId { get; set; }

    public Guid TTipoFranquicia { get; set; }

    public virtual TProducto TProducto { get; set; } = null!;

    public virtual TTipoFranquicium TTipoFranquiciaNavigation { get; set; } = null!;
}
