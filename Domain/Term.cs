using System;
using System.Collections.Generic;

namespace Domain
{
    public class Term
    {
        public int Id { get; private set; }

        public decimal Sum { get; set; }

        public DateTime Date { get; set; }

        public bool IsPending { get; set; }

        private readonly IList<Operation> _operations = new List<Operation>();

        public Term(int id)
        {
            Id = id;
        }

        public IEnumerable<Operation> Operations 
        { 
            get { return _operations; }
        }

        public bool CanBeClosed()
        {
            return _operations.Count > 0;
        }

        public void AddOperation(Operation operation)
        {
            _operations.Add(operation);
        }
    }
}