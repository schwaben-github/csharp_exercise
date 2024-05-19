namespace TestApp
{
    // Model Članovi!
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbMethods = new DbMethods();
            while (true)
            {
                Console.WriteLine("Management Članova knjižnice");
                Console.WriteLine("Odaberi jednu od opcija:");
                Console.WriteLine();
                Console.WriteLine("********************************");
                Console.WriteLine("*\t1. Dodaj člana         *");
                Console.WriteLine("*\t2. Pronadji člana      *");
                Console.WriteLine("*\t3. Izmijeni podatke    *");
                Console.WriteLine("*\t4. Obrisi člana        *");
                Console.WriteLine("*\t5. Ispisi sve clanove  *");
                Console.WriteLine("*\t6. Zatvori aplikaciju  *");
                Console.WriteLine("********************************");
                Console.Write("Unesi broj opcije: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddMember(dbMethods);
                        break;
                    case "2":
                        FindMember(dbMethods);
                        break;
                    case "3":
                        UpdateMember(dbMethods);
                        break;
                    case "4":
                        DeleteMember(dbMethods);
                        break;
                    case "5":
                        ListAllMembers(dbMethods);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Neispravan unos - pokušaj ponovno.");
                        break;
                }
            }
        }

        static void AddMember(DbMethods dbMethods)
        {
            Console.Write("Unesi ime člana: ");
            string ime = Console.ReadLine();
            Console.Write("Unesi prezime člana: ");
            string prezime = Console.ReadLine();
            Console.Write("Unesi ID adrese člana: ");
            int adresaId = int.Parse(Console.ReadLine());

            var member = new Member { Ime = ime, Prezime = prezime, AdresaId = adresaId };
            dbMethods.AddMember(member);
            Console.WriteLine("Član je uspješno dodan.\n");
        }

        static void FindMember(DbMethods dbMethods)
        {
            Console.Write("Unesi ID člana: ");
            int clanId = int.Parse(Console.ReadLine());
            var member = dbMethods.FindMember(clanId);
            if (member != null)
            {
                Console.WriteLine($"ID: {member.ClanId}, Ime: {member.Ime}, Prezime: {member.Prezime}, ID adrese: {member.AdresaId}\n");
            }
            else
            {
                Console.WriteLine("Član nije pronadjen.\n");
            }
        }

        static void UpdateMember(DbMethods dbMethods)
        {
            Console.Write("Unesi ID člana: ");
            int clanId = int.Parse(Console.ReadLine());
            var member = dbMethods.FindMember(clanId);
            if (member != null)
            {
                Console.Write("Unesi novo ime: ");
                member.Ime = Console.ReadLine();
                Console.Write("Unesi novo prezime: ");
                member.Prezime = Console.ReadLine();
                Console.Write("Unesi novi ID adrese: ");
                member.AdresaId = int.Parse(Console.ReadLine());

                dbMethods.UpdateMember(member);
                Console.WriteLine("Podatci su uspješno pohranjeni.\n");
            }
            else
            {
                Console.WriteLine("Član čije podatke treba izmijeniti nije pronađen.\n");
            }
        }

        static void DeleteMember(DbMethods dbMethods)
        {
            Console.Write("Unesi ID člana: ");
            int clanId = int.Parse(Console.ReadLine());
            dbMethods.DeleteMember(clanId);
            Console.WriteLine("Član je uspješno obrisan.\n");
        }

        static void ListAllMembers(DbMethods dbMethods)
        {
            var members = dbMethods.ListAllMembers();
            foreach (var member in members)
            {
                Console.WriteLine($"ID: {member.ClanId}, Ime: {member.Ime}, Prezime: {member.Prezime}, ID adresse: {member.AdresaId}\n");
            }
        }
    }
}