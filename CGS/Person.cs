using System;

namespace CGS
    {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public abstract class Person
        {
        private string FName = "";
        private string LName = "";

        public string FirstName
            {
            get
                {
                return FName;
                }
            set
                {
                FName = value;
                }
            }

        public string LastName
            {
            get
                {
                return LName;
                }
            set
                {
                LName = value;
                }
            }

        public Person()
            {
            }

        public Person(string First, string Last)
            {
            FName = First;
            LName = Last;
            }

        public override string ToString()
            {
            return FName + " " + LName;
            }
        }
    }
