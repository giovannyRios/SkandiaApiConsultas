using System;
using System.Collections.Generic;

namespace Api.Context;

public partial class TDepartamento
{
    public Guid Id { get; set; }

    public string Departamento { get; set; } = null!;

    public virtual ICollection<TMunicipio> TMunicipios { get; set; } = new List<TMunicipio>();
}
