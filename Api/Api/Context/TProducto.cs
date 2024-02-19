using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class TProducto
{
    public Guid Id { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime FechaActualizacion { get; set; }

    public virtual ICollection<TCuentaAhorro> TCuentaAhorros { get; set; } = new List<TCuentaAhorro>();

    public virtual ICollection<TProductoPersona> TProductoPersonas { get; set; } = new List<TProductoPersona>();

    public virtual ICollection<TTarjetaCredito> TTarjetaCreditos { get; set; } = new List<TTarjetaCredito>();
}
