using System;
using System.IO;
using CGS;

namespace Terminal {
    class Program {
        public static Gallery gal = new Gallery (true);
        public static Curator curatorInstance = new Curator ();
        public static EventListener eventInstance = new EventListener (curatorInstance);

        public static void Main (string[] args) {
            int menu;
            do {
                Menu ();
                string input;
                input = Console.ReadLine ();
                if (Int32.TryParse (input, out menu)) {
                    switch (menu) {
                        case 1:
                            Console.WriteLine ("--- Adding Artist ---");
                            AddArtist ();
                            break;
                        case 2:
                            Console.WriteLine ("--- Adding Curator ---");
                            AddCurator ();
                            break;
                        case 3:
                            Console.WriteLine ("--- Adding Art Piece ---");
                            AddArtpiece ();
                            break;
                        case 4:
                            Console.WriteLine ("--- Selling Art Piece ---");
                            SellArtPiece ();
                            curatorInstance.ClearComm ();
                            eventInstance.Detach ();
                            break;
                        case 5:
                            Console.WriteLine ("--- List Artists ---");
                            ListArtists ();
                            break;
                        case 6:
                            Console.WriteLine ("--- List Curators ---");
                            ListCurators ();
                            break;
                        case 7:
                            Console.WriteLine ("--- List Pieces ---");
                            ListPieces ();
                            break;
                        case 9:
                            Console.WriteLine ("Quiting application...");
                            break;
                        default:
                            Console.WriteLine ("Choose a number between 1 to 9");
                            break;
                    }
                } else {
                    Console.WriteLine ("Enter integer not words");
                }
            } while (menu != 9);
        }
        public static void AddArtist () {
            Console.WriteLine ("Enter ID");
            string ID = Console.ReadLine ();
            Console.WriteLine ("Enter first name");
            string fname = Console.ReadLine ();
            Console.WriteLine ("Enter last name");
            string lname = Console.ReadLine ();
            gal.AddArtist (true, fname, lname, ID);
            string output = gal.ListArtists ();
            Console.WriteLine (output);
        }
        public static void AddCurator () {
            Console.WriteLine ("Enter ID");
            string ID = Console.ReadLine ();
            Console.WriteLine ("Enter first name");
            string fname = Console.ReadLine ();
            Console.WriteLine ("Enter last name");
            string lname = Console.ReadLine ();
            gal.AddCurator (true, fname, lname, ID);
            string output = gal.ListCurators ();
            Console.WriteLine (output);
        }
        public static void AddArtpiece () {
            Console.WriteLine ("Enter Piece ID");
            string ID = Console.ReadLine ();
            Console.WriteLine ("Enter Title");
            string Title = Console.ReadLine ();
            Console.WriteLine ("Enter Year");
            string Year = Console.ReadLine ();
            Console.WriteLine ("Enter Estimate");
            double Estimate = Convert.ToDouble (Console.ReadLine ());
            Console.WriteLine ("Enter ArtistID");
            string ArtistID = Console.ReadLine ();
            Console.WriteLine ("Enter CuratorID");
            string CuratorID = Console.ReadLine ();
            gal.AddPiece (true, ID, Title, Year, Estimate, ArtistID, CuratorID);
            string output = gal.ListPieces ();
            Console.WriteLine (output);
        }
        public static void SellArtPiece () {
            Console.WriteLine ("Enter Piece ID");
            string ID = Console.ReadLine ();
            Console.WriteLine ("Enter Price");
            double Price = Convert.ToDouble (Console.ReadLine ());
            bool status = gal.SellPiece (ID, Price);
            if (status) {
                Console.WriteLine ("Piece sold successfully!");
            } else {
                Console.WriteLine ("Sale failed!");
            }
            string output = gal.ListPieces ();
            Console.WriteLine (output);
            output = gal.ListCurators ();
            Console.WriteLine (output);
        }
        public static void ListPieces () {
            string output = gal.ListPieces ();
            Console.WriteLine (output);
        }
        public static void ListCurators () {
            string output = gal.ListCurators ();
            Console.WriteLine (output);
        }

        public static void ListArtists () {
            string output = gal.ListArtists ();
            Console.WriteLine (output);
        }
        public static void Menu () {
            Console.WriteLine ("---- SELECT MENU ----");
            Console.WriteLine ("1. Add an Artist");
            Console.WriteLine ("2. Add a Curator");
            Console.WriteLine ("3. Add an Art Piece");
            Console.WriteLine ("4. Sell Art Piece");
            Console.WriteLine ("5. List Artists");
            Console.WriteLine ("6. List Curatos");
            Console.WriteLine ("7. List Pieces");
            Console.WriteLine ("9. Quit the application");
            Console.WriteLine ("--------------------");
        }
    }
}