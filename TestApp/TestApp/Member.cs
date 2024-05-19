using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClanId { get; set; }  // clan_id

        public string Ime { get; set; }  // ime
        public string Prezime { get; set; }  // prezime
        public int AdresaId { get; set; }  // adresa_id
    }
}
