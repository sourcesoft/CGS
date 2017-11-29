using System;

namespace Terminal
    {
    class Program
        {
        public struct Artist
            {
            public string ID;
            public string fname;
            public string lname;
            }

        public struct Curator
            {
            public string ID;
            public string fname;
            public string lname;
            }

        public struct Artpiece
            {
            public string ID;
            public string title;
            public string date;
            public string IDArtist;
            public string IDCcurator;
            public double estimed;
            public double price;
            public char status;
            }

        public static Artist[] MyArtists = new Artist[5];
        public static Curator[] MyCurators = new Curator[3];
        public static Artpiece[] MyArtpieces = new Artpiece[10];
        public static int ArtistIndex = 0;
        public static int CuratorIndex = 0;
        public static int ArtpieceIndex = 0;

        public static void Main(string[] args)
            {
            int menu;
            do
                {
                Menu();
                string input;
                input = Console.ReadLine();
                if (Int32.TryParse(input, out menu))
                    {
                    switch (menu)
                        {
                        case 1:
                            Console.WriteLine("--- Adding Artist ---");
                            AddArtist();
                            break;
                        case 2:
                            Console.WriteLine("--- Adding Curator ---");
                            AddCurator();
                            break;
                        case 3:
                            Console.WriteLine("--- Adding Art Piece ---");
                            AddArtpiece();
                            break;
                        case 4:
                            DisplayAllArtPieces();
                            break;
                        case 5:
                            Console.WriteLine("--- Finding Art Piece ---");
                            FindArtPiece();
                            break;
                        case 6:
                            Console.WriteLine("--- Deleting Art Piece ---");
                            DeleteArtPiece();
                            break;
                        case 7:
                            Console.WriteLine("Quiting application...");
                            break;
                        default:
                            Console.WriteLine("Choose a number between 1 to 7");
                            break;
                        }
                    }
                else
                    {
                    Console.WriteLine("Enter integer not words");
                    }
                } while (menu != 7);
            }
        public static void AddArtist()
            {
            // check if Artist ID already exists
            bool err;
            string ID;
            do
                {
                err = false;
                Console.WriteLine("Enter ID");
                ID = Console.ReadLine();
                for (int i = 0; i < ArtistIndex; i++)
                    {
                    if (MyArtists[i].ID == ID)
                        {
                        Console.WriteLine("ID already exists.");
                        err = true;
                        }
                    }
                } while (err == true);
            Console.WriteLine("Enter first name");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lname = Console.ReadLine();
            MyArtists[ArtistIndex].ID = ID;
            MyArtists[ArtistIndex].fname = fname;
            MyArtists[ArtistIndex].lname = lname;
            ArtistIndex++;
            }
        public static void AddCurator()
            {
            // check if Curator ID already exists
            bool err;
            string ID;
            do
                {
                err = false;
                Console.WriteLine("Enter ID");
                ID = Console.ReadLine();
                for (int i = 0; i < CuratorIndex; i++)
                    {
                    if (MyCurators[i].ID == ID)
                        {
                        Console.WriteLine("ID already exists.");
                        err = true;
                        }
                    }
                } while (err == true);
            Console.WriteLine("Enter first name");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lname = Console.ReadLine();
            MyCurators[CuratorIndex].ID = ID;
            MyCurators[CuratorIndex].fname = fname;
            MyCurators[CuratorIndex].lname = lname;
            CuratorIndex++;
            }
        public static void AddArtpiece()
            {
            // check if Artpiece ID already exists
            bool err;
            string ID;
            do
                {
                err = false;
                Console.WriteLine("Enter ID");
                ID = Console.ReadLine();
                for (int i = 0; i < ArtpieceIndex; i++)
                    {
                    if (MyArtpieces[i].ID == ID)
                        {
                        Console.WriteLine("ID already exists.");
                        err = true;
                        }
                    }
                } while (err == true);
            Console.WriteLine("Enter title");
            string title = Console.ReadLine();
            Console.WriteLine("Enter date");
            string date = Console.ReadLine();

            // check if Artist actually exists
            bool err2;
            string IDArtist;
            do
                {
                err2 = true;
                Console.WriteLine("Enter Artist ID");
                IDArtist = Console.ReadLine();
                for (int i = 0; i < ArtistIndex; i++)
                    {
                    if (MyArtists[i].ID == IDArtist)
                        {
                        Console.WriteLine("Found Artist " + MyArtists[i].fname);
                        err2 = false;
                        }
                    }
                if (err2)
                    {
                    Console.WriteLine("Artist not found, try again!");
                    }
                } while (err2 == true);


            // check if Artist actually exists
            bool err3;
            string IDCurator;
            do
                {
                err3 = true;
                Console.WriteLine("Enter Curator ID");
                IDCurator = Console.ReadLine();
                for (int i = 0; i < CuratorIndex; i++)
                    {
                    if (MyCurators[i].ID == IDCurator)
                        {
                        Console.WriteLine("Found Curator " + MyCurators[i].fname);
                        err3 = false;
                        }
                    }
                if (err3)
                    {
                    Console.WriteLine("Curator not found, try again!");
                    }
                } while (err3 == true);

            Console.WriteLine("Enter Estimed");
            double estimed = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Price");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter status (should be one character)");
            char status = Console.ReadLine()[0];
            MyArtpieces[ArtpieceIndex].ID = ID;
            MyArtpieces[ArtpieceIndex].title = title;
            MyArtpieces[ArtpieceIndex].date = date;
            MyArtpieces[ArtpieceIndex].IDArtist = IDArtist;
            MyArtpieces[ArtpieceIndex].IDCcurator = IDCurator;
            MyArtpieces[ArtpieceIndex].estimed = estimed;
            MyArtpieces[ArtpieceIndex].price = price;
            MyArtpieces[ArtpieceIndex].status = status;
            ArtpieceIndex++;
            }
        public static void DisplayAllArtPieces()
            {
            for (int i = 0; i < ArtpieceIndex; i++)
                {
                Console.WriteLine(" ---- Displaying Artpiece #" + i + " ----");
                Console.WriteLine("ID: " + MyArtpieces[i].ID);
                Console.WriteLine("Title: " + MyArtpieces[i].title);
                Console.WriteLine("Date: " + MyArtpieces[i].date);
                Console.WriteLine("ID of Artist: " + MyArtpieces[i].IDArtist);
                Console.WriteLine("ID of Curator: " + MyArtpieces[i].IDCcurator);
                Console.WriteLine("estimed: " + MyArtpieces[i].estimed);
                Console.WriteLine("price: " + MyArtpieces[i].price);
                Console.WriteLine("status: " + MyArtpieces[i].status);
                }
            }
        public static void FindArtPiece()
            {
            Console.WriteLine("Enter ArtPiece Code to find");
            string ID = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < ArtpieceIndex; i++)
                {
                if (MyArtpieces[i].ID == ID)
                    {
                    found = true;
                    Console.WriteLine("----- Found one! ----");
                    Console.WriteLine(" ---- Displaying Artpiece #" + i + " ----");
                    Console.WriteLine("ID: " + MyArtpieces[i].ID);
                    Console.WriteLine("Title: " + MyArtpieces[i].title);
                    Console.WriteLine("Date: " + MyArtpieces[i].date);
                    Console.WriteLine("ID of Artist: " + MyArtpieces[i].IDArtist);
                    Console.WriteLine("ID of Curator: " + MyArtpieces[i].IDCcurator);
                    Console.WriteLine("estimed: " + MyArtpieces[i].estimed);
                    Console.WriteLine("price: " + MyArtpieces[i].price);
                    Console.WriteLine("status: " + MyArtpieces[i].status);
                    break;
                    }
                }
            if (!found)
                {
                Console.WriteLine("Could not find art piece");
                }
            }
        public static void DeleteArtPiece()
            {
            Console.WriteLine("Enter ArtPiece Code to delete");
            string ID = Console.ReadLine();
            for (int i = 0; i < ArtpieceIndex; i++)
                {
                if (MyArtpieces[i].ID == ID)
                    {
                    Console.WriteLine("----- Found one to delete! ----");
                    for (int a = i; a < MyArtpieces.Length - 1; a++)
                        {
                        // moving elements downwards, to fill the gap at [index]
                        MyArtpieces[a] = MyArtpieces[a + 1];
                        }
                    // finally, let's decrement Array's size by one
                    Array.Resize(ref MyArtpieces, MyArtpieces.Length - 1);

                    ArtpieceIndex--;
                    break;
                    }
                }
            }
        public static void Menu()
            {
            Console.WriteLine("---- SELECT MENU ----");
            Console.WriteLine("1. Add an artist");
            Console.WriteLine("2. Add a curator");
            Console.WriteLine("3. Add an Art pieces");
            Console.WriteLine("4. Display all art pieces");
            Console.WriteLine("5. Find an art piece by code");
            Console.WriteLine("6. Delete an art piece");
            Console.WriteLine("7. Quit the application");
            Console.WriteLine("--------------------");
            }
        }
    }