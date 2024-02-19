using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class AccionistasTcSaldoTotalDeudum
{
    public string NumeroDocumento { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public decimal? SaldoTotalDeuda { get; set; }
}
