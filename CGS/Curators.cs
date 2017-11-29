using System;
using System.Collections;

namespace CGS
    {
    /// <summary>
    /// Summary description for Curators.
    /// </summary>
    public class Curators : CollectionBase
        {
        public void Add(Curator newCurator)
            {
            List.Add(newCurator);
            }

        public Curators()
            {
            //
            // TODO: Add constructor logic here
            //
            }

        public Curator this[int curatorIndex]
            {
            get
                {
                return (Curator)List[curatorIndex];
                }
            set
                {
                List[curatorIndex] = value;
                }
            }
        }
    }
