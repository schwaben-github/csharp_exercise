using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbMethods
    {
        public static void AddClan(string ime, string prezime, int adresaId)
        {
            try
            {
                using (var context = new KnjiznicaContext())
                {
                    var clan = new Članovi
                    {
                        Ime = ime,
                        Prezime = prezime,
                        AdresaId = adresaId
                    };
                    context.Članovi.Add(clan);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Greška: " + e.Message);
            }
        }

        public static List<Članovi> GetClanovi()
        {
            try
            {
                using (var context = new KnjiznicaContext())
                {
                    return context.Članovi.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Greška: " + e.Message);
                return new List<Članovi>();
            }
        }
    }
}
