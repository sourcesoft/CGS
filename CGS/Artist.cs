using System;

namespace CGS {
    /// <summary>
    /// Summary description for Artist.
    /// </summary>
    public class Artist : Person {
        private string artistID;
        public string ArtistID {
            get {
                return artistID;
            }
            set {
                artistID = value;
            }
        }
        public Artist () { }
        public override string ToString () {
            return ArtistID + ". " + base.FirstName + base.LastName;
        }
    }
}