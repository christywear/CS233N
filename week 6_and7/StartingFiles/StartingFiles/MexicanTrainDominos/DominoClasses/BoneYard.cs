using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClasses
{
    public class BoneYard
    {
        private List<Domino> listOfDominos = new List<Domino>();
        

        #region BoneYard Properties
        public int DominosRemaining
        {
            get
            {
                return listOfDominos.Count;
            }
        }
        public Domino this[int index]
        {
            get
            {
                return listOfDominos[index];
            }
            
            set
            {
                listOfDominos.Add(value);
            }
        }
        #endregion
        #region BoneYard methods
        public BoneYard(int maxDots)
        {
            for (int sideone = 0; sideone <= maxDots; sideone++)
                // in each side
                for (int sidetwo = sideone; sidetwo <= maxDots; sidetwo++)
                    // create the card and add it to the list
                    listOfDominos.Add(new Domino(sideone, sidetwo));
        }

        public Domino Draw()
        {
            // if the deck still has cards
            if (!IsEmpty)
            {
                // get a refernce to the first domino
                Domino d = listOfDominos[0];
                // remove the domino from the list
                listOfDominos.Remove(d);
                // return the first domino
                return d;
            }
            // when the deck is empty, return null or throw an exception
            return null;
        }

        public bool IsEmpty
        {
            get
            {
                return (listOfDominos.Count == 0);
            }
        }

        public void Shuffle()
        {
            Random gen = new Random();
            // go through all of the dominos in the boneyard
            for (int i = 0; i < DominosRemaining; i++)
            {
                // generate a random index
                int rnd = gen.Next(0, DominosRemaining);
                // swap the domino at the random index with the domino at the current index
                Domino d = listOfDominos[rnd];
                listOfDominos[rnd] = listOfDominos[i];
                listOfDominos[i] = d;
            }
        }

        public override string ToString()
        {
            string output = "";
            // go through every domino in the boneyard
            foreach (Domino d in listOfDominos)
                // ask the domino to convert itself to a string
                output += (d.ToString() + "\n");
            return output;
        }
        #endregion
    }
}
