using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iterateur
{
    public struct Jeu
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
        private JeuCollection _collection; 
        private int _index;

        public JeuCoteIterator(JeuCollection collection)
        {
            _collection = new JeuCollection();
            _collection.AddRange(collection);
            _index = -1; // démarre avant le premier élément
        }

        public Jeu JeuCourant
        {
            get
            {
                if (_index >= 0 && _index < _copy.Count)
                {
                    return _collection[_index];
                }
                else
                {
                    return null; 
                }
            }
        }

        public bool MoveNext()
        {
            if (_collection.Count > _index + 1)
            {
                _index++;
                return true;
            }
            return false; // S'il  y a juste une personne cca renvoie false

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
