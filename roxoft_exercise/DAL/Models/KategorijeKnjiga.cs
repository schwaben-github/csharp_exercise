using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class KategorijeKnjiga
{
    public int KategorijaId { get; set; }

    public string? Naziv { get; set; }

    public virtual ICollection<Knjige> Knjige { get; set; } = new List<Knjige>();
}
