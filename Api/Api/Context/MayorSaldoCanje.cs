using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class MayorSaldoCanje
{
    public string IdentificacionPersona { get; set; } = null!;

    public string? NombreCliente { get; set; }

    public decimal? SaldoCanjeTotal { get; set; }
}
