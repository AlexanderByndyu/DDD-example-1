using System;
using Domain;
using Infrastucture;

namespace Ddd
{
    public class TermEnvironmentDecorator : TermEnvironment
    {
        public TermEnvironmentDecorator(ITermRepository termRepository, User user)
            : base(termRepository, user)
        {
        }

        public new void StartNewTerm()
        {
            Console.WriteLine("CurrentTerm.Id = {0}", CurrentTerm.Id);
            base.StartNewTerm();
            Console.WriteLine("CurrentTerm.Id = {0}", CurrentTerm.Id);
        }
    }
}
