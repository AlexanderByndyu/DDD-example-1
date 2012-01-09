using System;
using Domain;
using Infrastucture;

namespace Ddd
{
    internal class Program
    {
        internal static void Main()
        {
            var environment = new TermEnvironmentDecorator(new FakeRepository(), new User());

            environment.CurrentTerm.AddOperation(new Operation());
            environment.StartNewTerm();

            try
            {
                environment.StartNewTerm();
            }
            catch (TermException)
            {
                Console.WriteLine("CurrentTerm Must Contain Operations");
            }

            environment.CurrentTerm.AddOperation(new Operation());
            environment.StartNewTerm();
        }
    }
}
