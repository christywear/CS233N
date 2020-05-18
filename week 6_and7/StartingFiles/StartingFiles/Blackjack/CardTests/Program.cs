using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardClasses;

namespace CardTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test everything
            TestCardConstructors();
            TestCardToString();
            TestCardPropertyGetters();
            TestCardPropertySetters();
            TestHasMatchingSuit();
            TestHasMatchingValue();
            TestIsAce();
            TestIsBlack();
            TestIsClub();
            TestIsDiamond();
            TestIsFaceCard();
            IsHeart();
            TestIsRed();
            TestIsSpade();
            TestCardPropertySettersWithExceptions();
            TestDeckConstructor();
            TestDeckShuffle();
            TestDeckDeal();
            Console.ReadLine();
        }
        
        // test our constructors
        static void TestCardConstructors() 
        {
            // create new card objects
            Card c1 = new Card(); // default constructor
            Card c2 = new Card(10, 4); // override constructor

            // interactive testing
            Console.WriteLine("Testing both constructors");
            Console.WriteLine("Default constructor. Expecting Defualt values ( of ). \n" + c1.ToString());
            Console.WriteLine("Overloaded constructor. Expecting (Ten of Spades). \n" + c2.ToString());
            Console.WriteLine();
        }

        // test our ToString
        static void TestCardToString() 
        {
            Card c1 = new Card(1, 3); // card obj using override constructor

            // interactive testing
            Console.WriteLine("Testing ToString");
            Console.WriteLine("Expecting: Ace of Hearts \n" + c1.ToString());
            Console.WriteLine("Expecting: Ace of Hearts \n" + c1);
            Console.WriteLine();
        }

        static void TestCardPropertyGetters() 
        {
            Card c1 = new Card(); // default card obj creation
            Card c2 = new Card(11, 2); // override constructor, creating obj value of 11, suit 2 Diamonds

            //interactive testing
            Console.WriteLine("Testing Getters");
            Console.WriteLine("Expecting default ( of ) \n" + c1);
            Console.WriteLine("Expecting (Jack of Diamonds) \n" + c2);
            Console.WriteLine();
        }

        static void TestCardPropertySetters() 
        {
            Card c1 = new Card(12, 3); // override card obj creation

            //interactive testing
            Console.WriteLine("Testing setters");
            Console.WriteLine("Current card expected is (Queen of Heart) \n" + c1);
            Console.WriteLine("Changing to King of Spades");
            c1.Suit = 4;
            c1.Value = 13;
            Console.WriteLine("Expecting King of Spaces: \n" + c1);
            Console.WriteLine();
        }

        static void TestHasMatchingSuit() 
        {
            Card c1 = new Card(12, 1); // new c1 override obj
            Card c2 = new Card(3, 1); // new c2 override obj

            //interactive testing
            Console.WriteLine("Testing has matching suit");
            Console.WriteLine("Card one, expecting (King of Clubs) \n" + c1);
            Console.WriteLine("Card two, expecting (3 of Clubs) \n" + c2);
            Console.WriteLine("Now running test if suit matching: expecting (True)");
            Console.WriteLine(c1.HasMatchingSuit(c2));
            Console.WriteLine();
        }

        static void TestHasMatchingValue() 
        {
            Card c1 = new Card(12, 3); // new c1 override obj 
            Card c2 = new Card(12, 4); // new c2 override obj

            // interactive testing
            Console.WriteLine("Testing has matching value");
            Console.WriteLine("Card one, Expecting (Queen of Hearts \n" + c1);
            Console.WriteLine("Card two, Expecting (Queen of Spades \n" + c2);
            Console.WriteLine("Testing if matching value, expecting (True)\n" + c1.HasMatchingValue(c2));
            Console.WriteLine();
        }

        static void TestIsAce() 
        {
            Card c1 = new Card(1, 4); // new c1 obj using override constructor
            Card c2 = new Card(4, 2); // new c2 obj using override constructor

            // intereactive testing
            Console.WriteLine("Testing if is an Ace");
            Console.WriteLine("Card one, Expecting (Ace of Spades)\n" + c1);
            Console.WriteLine("Card two, Expecting (4 of Diamonds)\n" + c2);
            Console.WriteLine("Expecting (True) for first card\n" + c1.IsAce());
            Console.WriteLine("Expecting (False) for Second card\n" + c2.IsAce());
            Console.WriteLine();
        }

        static void TestIsBlack() 
        {
            Card c1 = new Card(5, 1); // new c1 obj using override constructor
            Card c2 = new Card(7, 2); // new c2 obj using override constructor

            //interactive  testing
            Console.WriteLine("Now testing if it's a black card");
            Console.WriteLine("Card one, expecting (5 of Clubs)\n" + c1);
            Console.WriteLine("Card two, expecting (7 of Diamonds\n" + c2);
            Console.WriteLine("Expecting True for first card\n" + c1.IsBlack());
            Console.WriteLine("Expecting False for second card\n" + c2.IsBlack());
            Console.WriteLine();

        }

        static void TestIsClub() 
        {
            Card c1 = new Card(6, 1); // new c1 obj using override constructor
            Card c2 = new Card(8, 3); // new c2 obj using override constructor

            //Interactive testing
            Console.WriteLine("Now Testing if card is a club");
            Console.WriteLine("First card, Expecting (6 of Clubs)\n" + c1);
            Console.WriteLine("Second card, expecting (8 of Hearts)\n" + c2);
            Console.WriteLine("Expecting (True) for first card :\n" + c1.IsClub());
            Console.WriteLine("Expecting (False) for Second card:\n" + c2.IsClub());
            Console.WriteLine();
        }

        static void TestIsDiamond() 
        {
            Card c1 = new Card(2, 2); // new c1 obj using override constructor
            Card c2 = new Card(10, 4); // new c2 obj using override constructor

            // interactive testing
            Console.WriteLine("Testing if the card is a diamond.");
            Console.WriteLine("First card, Expecting (2 of Diamonds)\n" + c1);
            Console.WriteLine("Second Card, Expecting (Ten of spades)\n" + c2);
            Console.WriteLine("Expecting (True) for first card\n" + c1.IsDiamond());
            Console.WriteLine("Expecting (False) for second card\n" + c2.IsDiamond());
            Console.WriteLine();
        }

        static void TestIsFaceCard() 
        {
            // creating four test cards, one for each case, one non
            Card c1 = new Card(13, 4); // king obj for testing
            Card c2 = new Card(12, 4); // queen obj for testing
            Card c3 = new Card(11, 4);// jack for testing
            Card c4 = new Card(10, 3);// ten for testing

            // interactive testing
            Console.WriteLine("Testing if it's a facecard (jack,queen,king)");
            Console.WriteLine("First card, Expecting (King of Spades)\n" + c1);
            Console.WriteLine("Second card, Expecting (Queen of Spades)\n" + c2);
            Console.WriteLine("Third card, Expecting (Jack of Spades)\n" + c3);
            Console.WriteLine("fourth card, Expecting (Ten of Hearts)\n" + c4);
            Console.WriteLine("Testing if first card is a face card, Expecting (True)\n" + c1.IsFaceCard());
            Console.WriteLine("Testing if second card is a face card, Expecting (True)\n" + c2.IsFaceCard());
            Console.WriteLine("Testing if Third card is a face card, Expecting (True)\n" + c3.IsFaceCard());
            Console.WriteLine("Testing if fourth card is a face card, Expecting (False)\n" + c4.IsFaceCard());
            Console.WriteLine();
        }

        static void IsHeart() 
        {
            Card c1 = new Card(3, 3); // heart for testing
            Card c2 = new Card(1, 4); // spade for testing

            //interactive testing
            Console.WriteLine("Testing if suit is Heart");
            Console.WriteLine("First card, Expecting (3 of Hearts)\n" + c1);
            Console.WriteLine("Second card, expecting (Ace of Spades)\n" + c2);
            Console.WriteLine("For first card, expecting (True)\n" + c1.IsHeart());
            Console.WriteLine("for Second Card, Expecting (False)\n" + c2.IsHeart());
            Console.WriteLine();
        }

        static void TestIsRed() 
        {
            Card c1 = new Card(1, 1); // ace of clubs
            Card c2 = new Card(2, 2); // 2 of diamonds aka red
            Card c3 = new Card(3, 3); // 3 of hearts aka red
            Card c4 = new Card(4, 4); // four of spades

            // interactive testing
            Console.WriteLine("Testing if The colour of the card is Red");
            Console.WriteLine("First card, expecting (Ace of Clubs)\n" + c1);
            Console.WriteLine("Second card, expecting (2 of Diamonds)\n" + c2);
            Console.WriteLine("Third card, expecting (3 of Hearts)\n" + c3);
            Console.WriteLine("Fourth card, expecting (4 of Spades)\n" + c4);
            Console.WriteLine("For First card, expecting (False)\n" + c1.IsRed());
            Console.WriteLine("For Second card, expecting (True)\n" + c2.IsRed());
            Console.WriteLine("For Third card, expecting (True)\n" + c3.IsRed());
            Console.WriteLine("For Fourth card, expecting (False)\n" + c4.IsRed());
            Console.WriteLine();
        }

        static void TestIsSpade() 
        {
            Card c1 = new Card(1, 1); // ace of clubs
            Card c2 = new Card(2, 2); // 2 of diamonds
            Card c3 = new Card(3, 3); // 3 of hearts
            Card c4 = new Card(4, 4); // four of spades

            // intereactive tests
            Console.WriteLine("Testing if This card is a Spade");
            Console.WriteLine("First card, expecting (Ace of Clubs)\n" + c1);
            Console.WriteLine("Second card, expecting (2 of Diamonds)\n" + c2);
            Console.WriteLine("Third card, expecting (3 of Hearts)\n" + c3);
            Console.WriteLine("Fourth card, expecting (4 of Spades)\n" + c4);
            Console.WriteLine("For First card, expecting (False)\n" + c1.IsSpade());
            Console.WriteLine("For Second card, expecting (False)\n" + c2.IsSpade());
            Console.WriteLine("For Third card, expecting (False)\n" + c3.IsSpade());
            Console.WriteLine("For Fourth card, expecting (True)\n" + c4.IsSpade());
            Console.WriteLine();
        }

        static void TestCardPropertySettersWithExceptions() 
        {
            Card c1 = new Card(1, 1); // c1 = ace of clubs obj

            Console.WriteLine("Testing invalid setter values");
            try
            {
                c1.Suit = -1; // Give negative value to test that we properly set our if statement in our properties
            }
            catch
            {
                Console.WriteLine("Threw exception when suit is negative"); // tell us we set it correctly to protect our values
                Console.WriteLine("Card should still be (Ace of Clubs)\n" + c1); // verifying it didnt write it
            }
            try
            {
                c1.Suit = 5; // try to make it a non existant suit
            }
            catch
            {
                Console.WriteLine("Threw exception when suit is more than 4"); // check for greater than 4 is working proerply
                Console.WriteLine("Card should still be (Ace of Clubs)\n" + c1); // verify didnt write
            }
            try
            {
                c1.Value = -1; // try to make value neg 
            }
            catch
            {
                Console.WriteLine("Threw exception when value of card is negative"); // caught it trying to give a negative non existant card value
                Console.WriteLine("Card should still be (Ace of Clubs)\n" + c1); // verify it didnt write it
            }
            try
            {
                c1.Value = 14; // hah yeah nothing beyond king(except ace sometimes), but not in our values. 13 should be highest, lets see what happens
            }
            catch
            {
                Console.WriteLine("Threw Exception when value of card is greater than 13"); // caught it trying to give higher value
                Console.WriteLine("Card should still be (Ace of Clubs)\n" + c1); // check everything is ok!
            }
            try
            {
                c1 = new Card(-1, 16); // try both same time, with override constructor
            }
            catch
            {
                Console.WriteLine("Constructor should also throw an exception when values are invalid"); // Yay we set our constructor up correctly!
                Console.WriteLine("c1 is now\n" + c1); // make sure..
            }

        }
        

        static void TestDeckConstructor()
        {
            Deck d = new Deck();

            Console.WriteLine("Testing deck of cards default constructor");
            Console.WriteLine("NumCards.  Expecting 52. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
            Console.WriteLine("ToString.  Expect a ton of cards in order.\n" + d.ToString());
            Console.WriteLine();
        }

        static void TestDeckShuffle()
        {
            Deck d = new Deck();
            d.Shuffle();
            Console.WriteLine("Testing deck of cards shuffle");
            Console.WriteLine("NumCards.  Expecting 52. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
            Console.WriteLine("First Card will rarely be the Ace of Clubs. " + d[0]);
            Console.WriteLine("ToString.  Expect a ton of cards in shuffled order.\n" + d.ToString());
            Console.WriteLine();
        }

        static void TestDeckDeal()
        {
            Deck d = new Deck();
            Card c = d.Deal();

            Console.WriteLine("Testing deck of cards deal");
            Console.WriteLine("NumCards.  Expecting 51. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
            Console.WriteLine("Dealt Card should be Ace of Clubs. " + c);

            // now let's deal them all and see what happens at the end
            for (int i = 1; i <= 51; i++)
                c = d.Deal();
            Console.WriteLine("Dealt all 52 cards");
            Console.WriteLine("NumCards.  Expecting 0. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting true. " + d.IsEmpty);
            Console.WriteLine("Last Card should be King of Spades. " + c);
            Console.WriteLine("Dealing again should return null. Expecting true. " + (d.Deal() == null));

            Console.WriteLine();
        }
    }
}
