using DAL;

DbMethods.AddClan("Pero", "Perić", 1);
var clanovi = DbMethods.GetClanovi();

foreach (var clan in clanovi)
{
    Console.WriteLine(clan.Ime + " " + clan.Prezime);
}