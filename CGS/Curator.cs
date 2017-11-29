using System;

namespace CGS
    {
    /// <summary>
    /// Summary description for Curator.
    /// </summary>

    public delegate void CommissionPaidHandler(object sender, EventArgs e);

    public class Curator : Person
        {
        public event CommissionPaidHandler Changed;

        private string ID = "";
        private double commission;
        const double commRate = 0.10;

        public string CuratorID
            {
            get
                {
                return ID;
                }
            set
                {
                ID = value;
                }
            }

        public double Commission
            {
            get
                {
                return commission;
                }
            set
                {
                commission = value;
                }
            }

        public Curator()
            {
            }

        public Curator(string First, string Last, string curID) : base(First, Last)
            {
            ID = curID;
            commission = 0;
            }

        public override string ToString()
            {
            string curatorInformation = "\nName: " + base.FirstName + " " +
            base.LastName + "\nCurator ID: " + ID + "\nCommissions paid: " +
                commission;

            return curatorInformation;
            }

        public void GetComm(double pieceCommission)
            {
            double earnedComm;

            if (pieceCommission > 0)
                {
                earnedComm = pieceCommission * commRate;
                commission = commission + earnedComm;
                //      OnChangeCommission(EventArgs.Empty );
                }
            }

        // get the current EventArgs        
        //  protected virtual void OnChangeCommission (EventArgs e)
        //  {
        //      if (Changed != null)
        //          Changed(this, e);
        //  }

        //  public void ClearComm()
        //  {
        //      commission = 0;
        //clear any eventargs remaining
        //      OnChangeCommission(EventArgs.Empty );
        //  }


        }
    }
