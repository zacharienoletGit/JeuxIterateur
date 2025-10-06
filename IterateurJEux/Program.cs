namespace AppplicationIterateurPrison
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Prison prison = new Prison
            {
                new Prisonnier { Nom = "marcus", CoteDanger = 8 },
                new Prisonnier { Nom = "Martin Matte", CoteDanger = 9 },
                new Prisonnier { Nom = "Simon le Prof", CoteDanger = 7 },
                new Prisonnier { Nom = "Roblox", CoteDanger = 16 }
            };

            IPrissonierIterator iterateur = prison.GetIterator();

            while (iterateur.MoveNext())
            {
                Console.WriteLine($"{iterateur.PrisonnierCourant.Nom} - Cote: {iterateur.PrisonnierCourant.CoteDanger}");
            }
        }
    }
}
