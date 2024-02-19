using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class TPersonaNatural
{
    public Guid Id { get; set; }

    public Guid TTipoIdentificacionId { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public Guid TMunicipioId { get; set; }

    public Guid TTipoPersonaId { get; set; }

    public virtual TMunicipio TMunicipio { get; set; } = null!;

    public virtual TTipoIdentificacion TTipoIdentificacion { get; set; } = null!;

    public virtual TTipoPersona TTipoPersona { get; set; } = null!;
}
