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
        public static List<ArtPiece> pieces = new List<ArtPiece> ();

        public void AddArtist (string FName, string LName, string ID) {
            artists.Add (new Artist (FName, LName, ID));
        }
        public string ListArtists () {
            string output = "";
            foreach (var item in artists) {
                output += item.ToString ();
                output += "\n";
            }
            return output;
        }
        public void AddCurator (string FName, string LName, string ID) {
            curators.Add (new Curator (FName, LName, ID));
        }
        public string ListCurators () {
            string output = "";
            foreach (var item in curators) {
                output += item.ToString ();
                output += "\n";
            }
            return output;
        }
        public void AddPiece (string PieceID, string Title, string Year, double Estimate, string ArtistID, string CuratorID) {
            pieces.Add (new ArtPiece (PieceID, Title, Year, Estimate, ArtistID, CuratorID));
        }
        public string ListPieces () {
            string output = "";
            foreach (var item in pieces) {
                output += item.ToString ();
                output += "\n";
            }
            return output;
        }
        public bool SellPiece (string ID, double Price) {
            bool sw = false;
            foreach (var item in pieces) {
                Console.WriteLine (item.PieceID);
                if (item.PieceID == ID) {
                    if (item.Status == 'S') {
                        sw = false;
                    } else {
                        string curatorID = item.CuratorID;
                        item.ChangeStatus ('S');
                        item.PricePaid (Price);
                        double comm = item.CalculateComm (Price);
                        foreach (var c in curators) {
                            if (c.CuratorID == curatorID) {
                                c.Commission = comm;
                            }
                        }
                        sw = true;
                    }

                }
            }
            return sw;
        }
    }
}