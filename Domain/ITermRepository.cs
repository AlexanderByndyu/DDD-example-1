using System.Collections.Generic;

namespace Domain
{
    public interface ITermRepository
    {
        Term GetPendingTerm();
        void Save(Term term);
    }
}