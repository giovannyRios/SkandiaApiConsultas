using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class TPersonaJuridica
{
    public Guid Id { get; set; }

    public string Nit { get; set; } = null!;

    public string RazonSocial { get; set; } = null!;

    public Guid TTipoEmpresaId { get; set; }

    public Guid TTipoPersonaId { get; set; }

    public virtual TTipoEmpresa TTipoEmpresa { get; set; } = null!;

    public virtual TTipoPersona TTipoPersona { get; set; } = null!;
}
