using System.Collections.Generic;
using System.Linq;

namespace LedgerSpike
{
    public class Ledger
    {
        private readonly List<LedgerEntry> _entries = new List<LedgerEntry>();

        public Ledger() : this(0){}
        public Ledger(decimal openingBalance)
        {
            Transfer(null, openingBalance);
        }

        public decimal Balance
        {
            get { return _entries.Sum(entry => entry.Amount); }
        }

        public IEnumerable<LedgerEntry> Entries
        {
            get { return _entries; }
        }

        public void AssumeLiability(Ledger other)
        {
            TransferIn(other);
            other.TransferOut(this);
        }

        private void TransferIn(Ledger other)
        {
            Transfer(other, other.Balance);
        }

        private void TransferOut(Ledger other)
        {
            Transfer(other, -Balance);
        }

        private void Transfer(Ledger other, decimal amount)
        {
            _entries.Add(new LedgerEntry(other, amount));
        }
    }
}