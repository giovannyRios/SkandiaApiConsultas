using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class CuentaAhorrosMasCliente
{
    public Guid CuentaAhorros { get; set; }

    public int? CantidadClientes { get; set; }
}
