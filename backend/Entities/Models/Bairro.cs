using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Bairro
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int MunicipioId { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual ICollection<FilialLastMile> FilialLastMiles { get; } = new List<FilialLastMile>();
}
