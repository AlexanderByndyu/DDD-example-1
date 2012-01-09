using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Ddd
{
    public class FakeRepository : ITermRepository
    {
        private readonly IList<Term> _terms = new List<Term>();

        public Term GetPendingTerm()
        {
            return _terms.Where(x => x.IsPending).FirstOrDefault();
        }

        public void Save(Term term)
        {
            _terms.Add(term);
        }
    }
}
