using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nationalratswahlen
{
    public class Partei
    {

        // Constructor taking name and number of votes.
        public Partei(string name, int votes) { }

        // Read-Only property Name.
        public string Name { get; }

        // Read-Only property Number of votes.
        public int Votes { get; }

        // Read-Only property Number of seats.
        public int Seats { get; }

        // Method AddSeats(int seats) to add seats to the party.
        public void AddSeats(int seats) { }

        // Method ClearSeats() to clear the seats of the party.
        public void ClearSeats() { }

        // Method ToString() to return a string representation of the party.
        // The string representation should be in the format:
        // "Partei: {Name}, Stimmen: {Votes}, Sitze: {Seats}"
        public override string ToString() { return ""; }

        // Interface method IComparable.CompareTo() to compare two parties based on their number of seats.
        // Return 1 if this party has more seats than the other party.
        // Return -1 if this party has less seats than the other party.
        // Return 0 if both parties have the same number of seats.
        public int CompareTo(object obj) { return 0; }

        // Class-Method BerechneDHondt(Partei[] parteien, int anzahlSitze) to calculate the number of seats for each party.
        public static void BerechneDHondt(Partei[] parteien, int anzahlSitze) { }

        // Class-Method ReadPartyVotesFromFile(string filename) to read the party votes from a file.
        // If the file does not exist or the format is not correct, throw a FileNotFoundException.
        // The file has the following format:
        // 183              (number of mandates / seats)
        // 5                (number of parties)
        // ÖVP 1789417      (party name and number of votes)
        // SPÖ 1011868      (party name and number of votes)
        // FPÖ 772666       (party name and number of votes)
        // NEOS 387124      (party name and number of votes)
        // GRÜNE 664055     (party name and number of votes)
        public static Partei[] ReadPartyVotesFromFile(string filename) { return null; }

        // Class-Method SortBySeats(Partei[] parteien) to sort the parties descending based on their number of seats.
        public static void SortBySeats(Partei[] parteien) { }
    }
}
