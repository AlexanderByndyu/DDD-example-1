using System.Collections.Generic;
using Domain;
using Infrastucture;
using Moq;
using Xunit;

namespace UnitTests
{
    public class EnvironmentTests
    {
        private readonly Term _someTerm;
        private readonly Mock<ITermRepository> _termRepository;
        private readonly TermEnvironment _environment;

        public EnvironmentTests()
        {
            _someTerm = new Term(21);

            _termRepository = new Mock<ITermRepository>();
            _termRepository.Setup(x => x.GetPendingTerm())
                .Returns(_someTerm);

            _environment = new TermEnvironment(_termRepository.Object, new User());
        }

        [Fact]
        public void NewTermSholdStartIfCurrentTermContainsOperations()
        {
            _someTerm.AddOperation(new Operation());

            int oldTermId = _environment.CurrentTerm.Id;

            _environment.StartNewTerm();

            Assert.NotEqual(oldTermId, _environment.CurrentTerm.Id);
        }

        [Fact]
        public void IfTermNotContainsOperationsThenThrowsTermException()
        {
            Assert.Throws<TermException>(() => _environment.StartNewTerm());
        }
    }
}
