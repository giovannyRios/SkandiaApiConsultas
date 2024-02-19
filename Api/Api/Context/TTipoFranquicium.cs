using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class TTipoFranquicium
{
    public Guid Id { get; set; }

    public string TipoFranquicia { get; set; } = null!;

    public virtual ICollection<TTarjetaCredito> TTarjetaCreditos { get; set; } = new List<TTarjetaCredito>();
}
