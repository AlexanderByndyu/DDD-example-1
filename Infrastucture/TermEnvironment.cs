using System;
using Domain;

namespace Infrastucture
{
    public class TermEnvironment
    {
        private readonly ITermRepository _termRepository;
        private readonly User _user;

        public Term CurrentTerm { get; private set; }

        public TermEnvironment(ITermRepository termRepository, User user)
        {
            _termRepository = termRepository;
            _user = user;

            var pendingTerm = _termRepository.GetPendingTerm();

            CurrentTerm = pendingTerm ?? new Term(1);
        }

        public void StartNewTerm()
        {
            if (!CurrentTerm.CanBeClosed())
                throw new TermException();

            CloseCurrentTerm();
            _termRepository.Save(CurrentTerm);

            CurrentTerm = new Term(CurrentTerm.Id + 1) {Sum = _user.Sum};
        }

        private void CloseCurrentTerm()
        {
            CurrentTerm.Date = DateTime.Today;
            CurrentTerm.Sum = _user.Sum;
        }
    }
}