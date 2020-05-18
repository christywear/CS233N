using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Card
    {
        // Fields
        private static string[] values = { "", "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "Ten", "Jack", "Queen", "King" };
        private static string[] suits = { "", "Clubs", "Diamonds", "Hearts", "Spades" };
        private static Random generator = new Random();

        private int value;
        private int suit;

        // Properties
        public int Suit 
        { 
            get  // getter
            { 
                return suit; 
            } 
            set // setter
            { 
                if (value < 5 && value > 0) 
                    suit = value; 
                
                else 
                    throw new ArgumentException("error card is not in suit range"); 
            } 
        }

        public int Value 
        { 
            get // getter
            { 
                return value; 
            } 
            set // setter
            { 
                if (value > 0 && value < 14) 
                    this.value = value; 
                
                else 
                    throw new ArgumentException("Error: Card not in value range"); 
            } 
        }

        // Starting methods
        
        
        public Card() { } // default constructor

        public Card(int v, int s) // Override Constructor
        { 
            Value = v; 
            Suit = s; 
        }

        //checks for matching suit
        public bool HasMatchingSuit(Card other) // return bull 
        { 
            return suit == other.suit ? true : false; // ternary operatory same as
            // this
            /*
             * if(suit = other.suit)
             * {
             *      return true;
             * }
             * 
             * else
             * {
             *      return false;
             * }
             */
        }

        // checks for matching value
        public bool HasMatchingValue(Card other) 
        { 
            return value == other.value ? true : false;  // ternary 
        }

        // checks for ace
        public bool IsAce() 
        { 
            return value == 1 ? true : false; // turnary
        }

        // checks color of suit
        public bool IsBlack() 
        { 
            return suit == 1 ? true : suit == 4 ? true : false; // compound ternary
            /*
             * same as
             * if(suit == 1)
             * {
             *      return true;
             * }
             * else if(suit == 1)
             *  {
             *      return true;
             *  }
             * else
             *  return false;
             */
        }

        // checks for club
        public bool IsClub() 
        { 
            return suit == 1 ? true : false; // ternary
        }

        // checks for Diamonds <3
        public bool IsDiamond() 
        { 
            return suit == 2 ? true : false; // ternary
        }

        // checks for face card
        public bool IsFaceCard() 
        { 
            return value >= 11 ? true : false; //ternary
        }

        // checks for heart
        public bool IsHeart() 
        { 
            return suit == 3 ? true : false; //ternary
        }

        // checks if color is red
        public bool IsRed() 
        { 
            return suit == 2 ? true : suit == 3 ? true : false; // compound ternary 
        }

        // checks for spade
        public bool IsSpade() 
        { 
            return suit == 4 ? true : false;  // ternary
        }

        // our tostring override
        public override string ToString()
        {
            return values[value] + " of " + suits[suit];
        }

    }
}
