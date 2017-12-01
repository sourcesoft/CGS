using System;

namespace CGS {
    /// <summary>
    /// Summary description for EventListener.
    /// </summary>
    public class EventListener {
        private Curator curator;

        public EventListener (Curator strCurator) {
            curator = strCurator;
            curator.Changed += new CommissionPaidHandler (CommissionChanged);
        }

        private void CommissionChanged (object sender, EventArgs e) {
            Console.WriteLine ("The curator was paid commission.\n");
        }

        public void Detach () {
            // Detach the event
            curator.Changed -= new CommissionPaidHandler (CommissionChanged);
            curator = null;
        }

    }
}