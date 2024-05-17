using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class MjestaStanovanja
{
    public int AdresaId { get; set; }

    public string? Grad { get; set; }

    public string? Država { get; set; }

    public virtual ICollection<Članovi> Članovi { get; set; } = new List<Članovi>();
}
