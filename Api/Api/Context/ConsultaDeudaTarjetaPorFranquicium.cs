using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class ConsultaDeudaTarjetaPorFranquicium
{
    public decimal? Deuda { get; set; }

    public string TipoFranquicia { get; set; } = null!;
}
