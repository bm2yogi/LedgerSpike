namespace LedgerSpike
{
    public class TestClassBase
    {
        protected const decimal Liability = -500m;
        protected Ledger LedgerA;
        protected Ledger LedgerB;

        protected void Given_the_other_shows_a_zero_balance()
        {
            LedgerB = new Ledger();
        }

        protected void When_assuming_a_liability()
        {
            LedgerB.AssumeLiability(LedgerA);
        }

        protected void Given_one_ledger_shows_a_liability()
        {
            LedgerA = new Ledger(Liability);
        }

        protected void Given_two_ledgers()
        {
            LedgerA = new Ledger();
            LedgerB = new Ledger();
        }
    }
}