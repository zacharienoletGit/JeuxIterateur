using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppplicationIterateurJeux
{
    public class Jeu
    {
        public string Nom { get; set; }
        public int Cote { get; set; }
    }

    public interface IJeuCoteIterator
    {
        Jeu JeuCourant { get; }
        bool MoveNext();
    }

    public class JeuCoteIterator : IJeuCoteIterator
    {
        private JeuCollection _copy; // on veut une copie pour pas altérer la collection initiale
        private int _index;

        public JeuCoteIterator(JeuCollection collection)
        {
            _copy = new JeuCollection();
            _copy.AddRange(collection);             // copie des éléments
            _copy.Sort((j2, j1) => j1.Cote.CompareTo(j2.Cote)); // tri par cote (j2 à j1 pour avoir du meilleur au moin bon)
            _index = -1; // démarre avant le premier élément
        }

        public Jeu JeuCourant
        {
            get
            {
                if (_index >= 0 && _index < _copy.Count)
                {
                    return _copy[_index];
                }
                else
                {
                    return null; // peux lever une exception si tu préfères
                }
            }
        }

        public bool MoveNext()
        {
            if (_copy.Count > _index + 1)
            {
                _index++;
                return true;
            }
            return false; // S'il  y a juste une personne cca rernvoie false

        }

    }

    public class JeuCollection : List<Jeu>
    {
        public IJeuCoteIterator GetIterator()
        {
            return new JeuCoteIterator(this);
        }
    }
}