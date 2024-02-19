using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class TCuentaAhorro
{
    public Guid Id { get; set; }

    public decimal SaldoTotal { get; set; }

    public decimal SaldoCanje { get; set; }

    public decimal SaldoDisponible { get; set; }

    public Guid TProductoId { get; set; }

    public virtual TProducto TProducto { get; set; } = null!;
}
