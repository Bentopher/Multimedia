using Nationalratswahlen;
using System.Collections.Immutable;

namespace TestNationalratswahlen
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        // Test-Method to check for invalid file name.
        [Test]
        public void TestInvalidFileName()
        {
            Assert.Throws<FileNotFoundException>(() => Partei.ReadPartyVotesFromFile("invalid.txt"));
        }

        // Test-Method to check for single party file.
        [Test]
        public void TestSinglePartyFile()
        {
            Partei[] parteien = Partei.ReadPartyVotesFromFile("singleparty.txt");
            Assert.AreEqual(1, parteien.Length);
            Assert.AreEqual("ÖVP", parteien[0].Name);
            Assert.AreEqual(1789417, parteien[0].Votes);
        }

        // Test-Method to check for multiple parties file.
        [Test]
        public void TestMultiplePartiesFile()
        {
            Partei[] parteien = Partei.ReadPartyVotesFromFile("multipleparties.txt");
            Assert.AreEqual(5, parteien.Length);
            Assert.AreEqual("ÖVP", parteien[0].Name);
            Assert.AreEqual(1789417, parteien[0].Votes);
            Assert.AreEqual("SPÖ", parteien[1].Name);
            Assert.AreEqual(1011868, parteien[1].Votes);
            Assert.AreEqual("FPÖ", parteien[2].Name);
            Assert.AreEqual(772666, parteien[2].Votes);
            Assert.AreEqual("NEOS", parteien[3].Name);
            Assert.AreEqual(387124, parteien[3].Votes);
            Assert.AreEqual("GRÜNE", parteien[4].Name);
            Assert.AreEqual(664055, parteien[4].Votes);
        }

        // Test-Method to check if Partei object is created correctly.
        [Test]
        public void TestParteiObject()
        {
            Partei partei = new Partei("ÖVP", 1789417);
            Assert.AreEqual("ÖVP", partei.Name);
            Assert.AreEqual(1789417, partei.Votes);
            Assert.AreEqual(0, partei.Seats);
        }

        // Test-Method to check if Partei.AddSeats() works correctly.
        [Test]
        public void TestParteiAddSeats()
        {
            Partei partei = new Partei("ÖVP", 1789417);
            partei.AddSeats(71);
            Assert.AreEqual(71, partei.Seats);
        }

        // Test-Method to check if Partei.ClearSeats() works correctly.
        [Test]
        public void TestParteiClearSeats()
        {
            Partei partei = new Partei("ÖVP", 1789417);
            partei.AddSeats(71);
            partei.ClearSeats();
            Assert.AreEqual(0, partei.Seats);
        }

        // Test-Method to check if Partei.ToString() works correctly.
        [Test]
        public void TestParteiToString()
        {
            Partei partei = new Partei("ÖVP", 1789417);
            partei.AddSeats(71);
            Assert.AreEqual("Partei: ÖVP, Stimmen: 1789417, Sitze: 71", partei.ToString());
        }

        // Test-Method to check if Partei.SortBySeats() works correctly.
        [Test]
        public void TestParteiSortBySeats()
        {
            Partei[] parteien = new Partei[5];
            parteien[0] = new Partei("ÖVP", 1789417);
            parteien[1] = new Partei("SPÖ", 1011868);
            parteien[2] = new Partei("FPÖ", 772666);
            parteien[3] = new Partei("NEOS", 387124);
            parteien[4] = new Partei("GRÜNE", 664055);

            // Add seats to the parties.
            parteien[0].AddSeats(71);
            parteien[1].AddSeats(40);
            parteien[2].AddSeats(31);
            parteien[3].AddSeats(15);
            parteien[4].AddSeats(26);

            Partei.SortBySeats(parteien);
            Assert.AreEqual("ÖVP", parteien[0].Name);
            Assert.AreEqual("SPÖ", parteien[1].Name);
            Assert.AreEqual("FPÖ", parteien[2].Name);
            Assert.AreEqual("GRÜNE", parteien[3].Name);
            Assert.AreEqual("NEOS", parteien[4].Name);
        }

        // Test-Method to check if Partei.BerechneDHondt() works correctly.
        [Test]
        public void TestParteiBerechneDHondt()
        {
            Partei[] parteien = new Partei[5];
            parteien[0] = new Partei("ÖVP", 1789417);
            parteien[1] = new Partei("SPÖ", 1011868);
            parteien[2] = new Partei("FPÖ", 772666);
            parteien[3] = new Partei("NEOS", 387124);
            parteien[4] = new Partei("GRÜNE", 664055);
            Partei.BerechneDHondt(parteien, 183);
            Assert.AreEqual("ÖVP", parteien[0].Name);
            Assert.AreEqual(71, parteien[0].Seats);
            Assert.AreEqual("SPÖ", parteien[1].Name);
            Assert.AreEqual(40, parteien[1].Seats);
            Assert.AreEqual("FPÖ", parteien[2].Name);
            Assert.AreEqual(31, parteien[2].Seats);
            Assert.AreEqual("NEOS", parteien[3].Name);
            Assert.AreEqual(15, parteien[3].Seats);
            Assert.AreEqual("GRÜNE", parteien[4].Name);
            Assert.AreEqual(26, parteien[4].Seats);
        }
    }
    
}