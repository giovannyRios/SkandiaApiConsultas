using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class TPersonaInfoExtra
{
    public Guid Id { get; set; }

    public string IdentificacionPersona { get; set; } = null!;

    public Guid TTipoPersonaId { get; set; }

    public Guid TRolId { get; set; }

    public virtual ICollection<TProductoPersona> TProductoPersonas { get; set; } = new List<TProductoPersona>();

    public virtual TRol TRol { get; set; } = null!;

    public virtual TTipoPersona TTipoPersona { get; set; } = null!;
}
