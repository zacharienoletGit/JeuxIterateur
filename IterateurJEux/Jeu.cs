using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppplicationIterateurPrison
{
    public class Prisonnier
    {
        public string Nom { get; set; }
        public int CoteDanger { get; set; }
    }

    public interface IPrisonIterator
    {
        Prisonnier PrisonierCourant { get; }
        bool MoveNext();
    }

    public class PrisonIterator : IPrisonIterator
    {
        private JeuCollection _collection; // on veut une copie pour pas altérer la collection initiale
        private int _index;

        public PrisonIterator(Prison collection)
        {
            _collection = new Prison();
            _collection.AddRange(collection);             // copie des éléments
            _collection = -1; // démarre avant le premier élément
        }

        public Prisonnier PrisonnierCourant
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
            if (_copy.Count > _index + 1)
            {
                _index++;
                return true;
            }
            return false; // S'il  y a juste une personne cca rernvoie false

        }

    }

    public class Prison : List<Prisonnier>
    {
        public IJeuCoteIterator GetIterator()
        {
            return new PrisonIterator(this);
        }
    }
}
