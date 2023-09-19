using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Config
{
    public int Id { get; set; }

    public string? Banco { get; set; }

    public string? PastaTenant { get; set; }

    public string? PastaXml { get; set; }

    public string? PastaXmlProcessados { get; set; }
}
