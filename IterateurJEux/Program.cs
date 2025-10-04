namespace AppplicationIterateurJeux
{
    internal class Program
    {

        static void Main(string[] args)
        {
            JeuCollection jeux = new JeuCollection
            {
                new Jeu { Nom = "RS6", Cote = 8 },
                new Jeu { Nom = "Skyrim", Cote = 9 },
                new Jeu { Nom = "PubG", Cote = 7 },
                new Jeu { Nom = "Roblox", Cote = -2 }
            };

            IJeuCoteIterator iterateurCote = jeux.GetIterator();

            while (iterateurCote.MoveNext())
            {
                Console.WriteLine($"{iterateurCote.JeuCourant.Nom} - Cote: {iterateurCote.JeuCourant.Nom}");
            }
        }
    }
}