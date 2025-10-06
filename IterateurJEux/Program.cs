namespace AppplicationIterateurPrison
{
    internal class Program
    {

        static void Main(string[] args)
        {
            PrisonnierCollection prison = new Prison
            {
                new Jeu { Nom = "marcus", CoteDanger = 8 },
                new Jeu { Nom = "Martin Matte", CoteDanger = 9 },
                new Jeu { Nom = "Simon le Prof", CoteDanger = 7 },
                new Jeu { Nom = "Roblox", CoteDanger = 16 }
            };

            IPrissonierIterator iterateur = prison.GetIterator();

            while (iterateur.MoveNext())
            {
                Console.WriteLine($"{iterateur.PrisonnierCourant.Nom} - Cote: {iterateur.PrisonnierCourant.CoteDanger}");
            }
        }
    }
}
