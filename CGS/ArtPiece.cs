using System;

namespace CGS {
    /// <summary>
    /// Summary description for ArtPiece.
    /// </summary>
    public class ArtPiece {
        private string pieceID;
        public string PieceID { get { return pieceID; } set { pieceID = value; } }
        private string title;
        public string Title { get { return title; } set { title = value; } }
        private string year;
        public string Year { get { return year; } set { year = value; } }

        private double price;
        public double Price { get { return price; } set { price = value; } }
        private double estimate;
        public double Estimate { get { return estimate; } set { estimate = value; } }
        private string artistID;
        public string ArtistID { get { return artistID; } set { artistID = value; } }
        private string curatorID;
        public string CuratorID { get { return curatorID; } set { curatorID = value; } }
        private char status;
        public char Status { get { return status; } set { status = value; } }
        public ArtPiece (string PieceID, string Title, string Year, double Estimate, string ArtistID, string CuratorID) {
            this.pieceID = PieceID;
            this.title = Title;
            this.year = Year;
            this.estimate = Estimate;
            this.artistID = ArtistID;
            this.curatorID = CuratorID;
            this.status = 'D';
            this.price = 0;
        }
        public override string ToString () {
            return "PieceID: " + this.pieceID +
                "\nTitle: " + this.title +
                "\nYear: " + this.year +
                "\nPrice: " + this.price.ToString () +
                "\nEstimate: " + this.estimate.ToString () +
                "\nArtistID: " + this.artistID +
                "\nCuratorID: " + this.curatorID +
                "\nStatus: " + this.status;
        }
        public void ChangeStatus (char status) {
            this.status = status;
        }
        public void PricePaid (double price) {
            this.price = price;
        }
        public double CalculateComm (double newPrice) {
            return ((newPrice - this.estimate) * 0.25);
        }
    }
}