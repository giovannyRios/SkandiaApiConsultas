using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class TRol
{
    public Guid Id { get; set; }

    public string Rol { get; set; } = null!;

    public virtual ICollection<TPersonaInfoExtra> TPersonaInfoExtras { get; set; } = new List<TPersonaInfoExtra>();
}
