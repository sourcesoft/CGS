using System;

namespace CGS {
    /// <summary>
    /// Summary description for ArtPiece.
    /// </summary>
    public class ArtPiece {
        private string pieceID;
        public string PieceID { get; set; }
        private string title;
        public string Title { get; set; }
        private string year;
        public string Year { get; set; }

        private double price;
        public double Price { get; set; }
        private double estimate;
        public double Estimate { get; set; }
        private string artistID;
        public string ArtistID { get; set; }
        private string curatorID;
        public string CuratorID { get; set; }
        private char status;
        public char Status { get; set; }
        public ArtPiece () {
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