using System;
using System.Collections.Generic;
using System.IO;

namespace CGS {
    /// <summary>
    /// Summary description for Gallery.
    /// </summary>
    /// 
    public class Gallery {
        public List<Artist> artists = new List<Artist> ();
        public List<Curator> curators = new List<Curator> ();
        public List<ArtPiece> pieces = new List<ArtPiece> ();
        public bool withFile = false;
        private string filePath = "./";
        private string curatorsPath, artistsPath, piecesPath;
        StreamWriter swArtists, swCurators, swPieces;
        StreamReader srArtists, srCurators, srPieces;

        public Gallery (bool withFile = false, string filePath = "./") {
            if (withFile) {
                this.withFile = true;
                // init file paths in the same directory
                this.filePath = filePath;
                this.artistsPath = filePath + "artists.txt";
                this.curatorsPath = filePath + "curators.txt";
                this.piecesPath = filePath + "pieces.txt";
                // Artists
                swArtists = new StreamWriter (this.artistsPath, true);
                srArtists = new StreamReader (this.artistsPath);
                this.ReadAllArtists ();
                // Curators
                swCurators = new StreamWriter (this.curatorsPath, true);
                srCurators = new StreamReader (this.curatorsPath);
                this.ReadAllCurators ();
                // Pieces
                swPieces = new StreamWriter (this.piecesPath, true);
                srPieces = new StreamReader (this.piecesPath);
                this.ReadAllPieces ();
            }
        }
        public bool ReadAllArtists () {
            string line;
            string[] parts;
            while ((line = srArtists.ReadLine ()) != null) {
                parts = line.Split (",");
                this.AddArtist (false, parts[0], parts[1], parts[2]);
            }
            return true;
        }
        public bool WriteArtist (bool withWrite, string FName, string LName, string ID) {
            if (this.withFile && withWrite) {
                try {
                    swArtists.WriteLine (ID + ',' + FName + ',' + LName);
                    swArtists.Flush ();
                } catch {
                    return false;
                }
                return true;
            }
            return false;
        }
        public void AddArtist (bool withWrite, string FName, string LName, string ID) {
            // write to memory
            artists.Add (new Artist (FName, LName, ID));
            // write to file
            this.WriteArtist (withWrite, FName, LName, ID);
        }
        public string ListArtists () {
            string output = "";
            foreach (var item in artists) {
                output += item.ToString ();
                output += "\n";
            }
            return output;
        }
        public bool ReadAllCurators () {
            string line;
            string[] parts;
            while ((line = srCurators.ReadLine ()) != null) {
                parts = line.Split (",");
                this.AddCurator (false, parts[0], parts[1], parts[2]);
            }
            return true;
        }
        public bool WriteCurator (bool withWrite, string FName, string LName, string ID) {
            if (this.withFile && withWrite) {
                try {
                    swCurators.WriteLine (ID + ',' + FName + ',' + LName);
                    swCurators.Flush ();
                } catch {
                    return false;
                }
                return true;
            }
            return false;
        }
        public void AddCurator (bool withWrite, string FName, string LName, string ID) {
            // add to memory
            curators.Add (new Curator (FName, LName, ID));
            // add to file
            this.WriteCurator (withWrite, FName, LName, ID);
        }
        public string ListCurators () {
            string output = "";
            foreach (var item in curators) {
                output += item.ToString ();
                output += "\n";
            }
            return output;
        }
        public bool ReadAllPieces () {
            string line;
            string[] parts;
            while ((line = srPieces.ReadLine ()) != null) {
                parts = line.Split (",");
                this.AddPiece (false, parts[0], parts[1], parts[2], Convert.ToDouble (parts[3]), parts[4], parts[5]);
            }
            return true;
        }
        public bool WritePiece (bool withWrite, string PieceID, string Title, string Year, double Estimate, string ArtistID, string CuratorID) {
            if (this.withFile && withWrite) {
                try {
                    swPieces.WriteLine (PieceID + ',' + Title + ',' + Year + ',' + Estimate.ToString () + ',' + ArtistID + ',' + CuratorID);
                    swPieces.Flush ();
                } catch {
                    return false;
                }
                return true;
            }
            return false;
        }
        public void AddPiece (bool withWrite, string PieceID, string Title, string Year, double Estimate, string ArtistID, string CuratorID) {
            // add to memory
            pieces.Add (new ArtPiece (PieceID, Title, Year, Estimate, ArtistID, CuratorID));
            // add to file
            this.WritePiece (withWrite, PieceID, Title, Year, Estimate, ArtistID, CuratorID);
        }
        public string ListPieces () {
            string output = "";
            foreach (var item in this.pieces) {
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