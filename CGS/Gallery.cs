using System;
using System.Collections.Generic;

namespace CGS {
    /// <summary>
    /// Summary description for Gallery.
    /// </summary>
    /// 

    public class Gallery {
        public static List<Artist> artists = new List<Artist> ();
        public static List<Curator> curators = new List<Curator> ();
        public static List<ArtPiece> artPieces = new List<ArtPiece> ();

        public void AddArtist (string ID, string FName, string LName) {
            artists.Add (new Artist { ArtistID = ID, FirstName = FName, LastName = LName });
        }
        public string ListArtists () {
            string output = "";
            foreach (var item in artists) {
                output += item.ToString ();
            }
            return output;
        }
    }
}