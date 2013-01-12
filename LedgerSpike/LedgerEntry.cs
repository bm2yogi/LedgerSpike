namespace LedgerSpike
{
    public struct LedgerEntry
    {
        public readonly Ledger Source;
        public readonly decimal Amount;

        public LedgerEntry(Ledger other, decimal balance)
        {
            Source = other;
            Amount = balance;
        }
    }
}