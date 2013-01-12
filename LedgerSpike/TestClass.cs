using System.Linq;
using NUnit.Framework;
using Sahara;

namespace LedgerSpike
{
    [TestFixture]
    public class TestClass : TestClassBase
    {
        [TestFixtureSetUp]
        public void BeforeAll()
        {
            Given_two_ledgers();
            Given_one_ledger_shows_a_liability();
            Given_the_other_shows_a_zero_balance();
            When_assuming_a_liability();
           
        }

        [Test]
        public void the_first_ledger_should_show_a_zero_balance()
        {
            LedgerA.Balance.ShouldEqual(0);
        }

        [Test]
        public void the_second_ledger_should_show_the_new_liability()
        {
            LedgerB.Balance.ShouldEqual(Liability);
        }

        [Test]
        public void each_ledger_should_contain_two_entries()
        {
            LedgerA.Entries.Count().ShouldEqual(2);
            LedgerB.Entries.Count().ShouldEqual(2);
        }
    }


    [TestFixture]
    public class AnotherTestClass : TestClassBase
    {
        private const decimal OtherLiability = -300m;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            Given_two_ledgers();
            Given_one_ledger_shows_a_liability();
            Given_the_other_shows_a_liability();
            When_assuming_a_liability();

        }

        private void Given_the_other_shows_a_liability()
        {
            LedgerB = new Ledger(OtherLiability);
        }

        [Test]
        public void the_first_ledger_should_show_a_zero_balance()
        {
            LedgerA.Balance.ShouldEqual(0);
        }

        [Test]
        public void the_second_ledger_should_show_the_new_liability()
        {
            LedgerB.Balance.ShouldEqual(Liability+OtherLiability);
        }

        [Test]
        public void each_ledger_should_contain_two_entries()
        {
            LedgerA.Entries.Count().ShouldEqual(2);
            LedgerB.Entries.Count().ShouldEqual(2);
        }
    }
}