using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace TextConversionPigOrShift
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();

		}
		

		public void RedOrBlue(string input)
		{
				if (Input_Accaptable(input))
				{
					OkRunTheRest(input);
				}
				else
				{
					Display("Bad input yuck, try again");
					
				}
			Input = "";
		}
		
		/*=====================================================================================================================*/
		/* METHODS START!
		 * 
		 * 
		 * Lookout Below! Timber!!!!
		 */
		/*=====================================================================================================================*/

		/*=====================================================================================================================*/
		// Helper Methods : Methods that live to help other methods.														   //
		//																													   //
		/*=====================================================================================================================*/

		static public void OkRunTheRest(string input)
		{
			const string Case_Out_Lower = ("Converted to lowercase: ");
			const string Case_Out_Upper = ("Converted to uppercase: ");
			const string Reverse_Willy_Wonka = ("In reverse: ");
			const string Punk_Search_Count = ("Puncutation count: ");
			const string IsVowel_Index_Out = ("The index of the first vowel is: ");
			const char If_Its_This_Dont_Use = 'a';
			const string The_Final_Frontier = (" ");
			const string Cap_Check_Together = ("All together now! ");
			const string Caps_Anykey_Go = ("Press Enter Key to Continue");




			//case conversion -- Step 2
			Show_Off_Fancy_Letters(input, Case_Out_Lower, Case_Out_Upper);

			//reverse -- Step 3
			Strike_That_Reverse_It(input, Reverse_Willy_Wonka);

			//check for punctuation -- Step 4
			Count_Punk_In_Band(input, Punk_Search_Count);

			//is it really the captain!? -- Step 5
			bool Steve_Rogers = Test_Begins_With_Cap(input[0]);

			// Ohh no! It's too early in the movie to know this quick hide it!
			// (trim first char after making it lowercase) -- Step 6
			input = Hide_The_Captain(input);

			// use IsVowel method to check for vowels, Find the index and spit it out. -- Step 7
			Gimme_A_Vowel_Index(input, IsVowel_Index_Out);

			//split input into seporate words and spit it out. -- Step 8
			string[] words = Do_The_Splits(input);

			//clean punctuation, and remove all and save it in a list. -- Step 9
			List<char> punc = new List<char>();
			punc = Do_Dishes(punc, words, If_Its_This_Dont_Use);
			char[] really_annoying_conversion = punc.ToArray();

			//write out the word in piglatin using the piglatin method -- Step 10
			string[] pigwords = Onvertcay_Otay_Iglatinpay(words);

			// combine the seporate words into one sentance and output. -- Step 11
			string pigSentence = PigLatin_complete_Sentance(really_annoying_conversion, pigwords, If_Its_This_Dont_Use, The_Final_Frontier);

			// fixing wierd blankspace 
			pigSentence = pigSentence.Remove(0, 1); // now there's a leading space?
													//check for Cap'n if it's him use the Captial. -- step 12
			if (Steve_Rogers)
			{
				Display(Cap_Check_Together + Yeah_Thats_Cap(pigSentence));
			}
			else
			{
				Display(Cap_Check_Together + pigSentence);
			}
			Display(Caps_Anykey_Go);
		}


		// prep to make cleaner easier Console.WriteLine

		static void Display(string s)
		{
			// Make a new source in the binding
			DisplayBuffer sendmessage = new DisplayBuffer();
			sendmessage.Message = "";
			sendmessage.Message = s;
		}

		// hopefully stop program from breaking so easily 
		static bool Input_Accaptable(string s)
		{
			// No info!
			if (string.IsNullOrEmpty(s))
			{
				return false;
			}
			//spaces at the beginning, or punctuation?

			if (s[0] == ' ' || Char.IsPunctuation(s[0]))
			{
				Display("Spaces, or punctuation at the beginning of sentance is not allowed, please re-enter");
				return false;
			}

			//is it real input?
			if (String.IsNullOrWhiteSpace(s) || String.IsNullOrEmpty(s)) //really.. nothing?
			{
				return false;
			}

			//are there numbers?
			foreach (Char c in s)
			{
				if (Char.IsDigit(c))
				{
					Display("Why did we enter numbers?? Try again..");
					return false;
				}
			}

			//is there random non alpha?
			foreach (Char c in s)
			{
				if (Char.IsSymbol(c))
				{
					return false;
				}
				if (Char.IsSurrogate(c))
				{
					return false;
				}
			}

			//reapeated punctuation?
			for (int i = 0; i < s.Length; i++)
			{
				for (int j = i + 1; j < s.Length; j++)
				{
					if ((s[i] == s[j] && Char.IsPunctuation(s[i])) || ((s[i] == s[j]) && (s[i] == ' ')))
					{
						Display("No repeating punctuation, or spaces try again");
						return false;
					}
				}
			}
			return true; // if you made it this far it's good.
		}

		//checking for vowels.
		static bool IsVowel(char c)
		{
			bool IsItVowel = false;
			c = Char.ToLower(c);
			switch (c)
			{
				case 'a':
				case 'e':
				case 'i':
				case 'o':
				case 'u':
				case 'y':
					IsItVowel = true;
					break;
				default:
					IsItVowel = false;
					break;
			}
			return IsItVowel;
		}


		//lets count the vowels at the start and return.
		static int Starting_Consonant_Count(string loc_string)
		{
			int local_c_count = 0;
			for (int i = 0; i < loc_string.Length; i++)
			{
				if (!(IsVowel(loc_string[i]))) // if it's not a vowel
				{
					local_c_count++; // add to count
				}
			}
			return local_c_count;
		}


		//converting word into piglatin
		static string PigLatin(string s)
		{
			const string AddAy = ("ay");
			const string AddWay = ("way");
			if (s == "") //correction for testcase space after sentance before punctuation, creates blank word.
			{ return s; }

			char TestingFirstLetter = s[0];
			bool TestConsenents = IsVowel(TestingFirstLetter);
			int Num_Consenents = 0;
			if (!(TestConsenents)) //if false count how many
			{
				Num_Consenents = Starting_Consonant_Count(s);
			}
			// preparing for piglatin convert
			s = s.TrimStart(TestingFirstLetter);
			s = s + TestingFirstLetter;
			// lets do this
			if (!(TestConsenents))
			{
				if (Num_Consenents > 1)
				{
					Display("More than one starting Conscenent! There are " + Num_Consenents + " starting Consenents!");

					for (int i = 1; i < Num_Consenents; i++)
					{
						TestingFirstLetter = s[0];
						s = s.TrimStart(TestingFirstLetter);
						s = s + TestingFirstLetter;
					}
				}
				s += AddAy;
			}
			else { s += AddWay; }
			return s;
		}


		/*=====================================================================================================================*/
		// Normal Methods for everyday work:)																				   //
		//																													   //
		/*=====================================================================================================================*/




		//case conversion Step 2
		static void Show_Off_Fancy_Letters(string s, string Case_Lower, string Case_Upper)
		{
			string lower = s.ToLower();
			Display(Case_Lower + lower);
			string upper = s.ToUpper();
			Display(Case_Upper + upper);
		}


		//reverse -- Step 3
		static void Strike_That_Reverse_It(string input, string Reverse_Willy_Wonka)
		{
			string reverse = "";
			foreach (char c in input)
				reverse = c + reverse;
			Display(Reverse_Willy_Wonka + reverse);
		}


		//check for punctuation -- Step 4
		static void Count_Punk_In_Band(string input, string Punk_Search_Count)
		{
			int pCount = 0;
			foreach (char c in input)
				if (Char.IsPunctuation(c))
					pCount++;
			Display(Punk_Search_Count + pCount);
		}


		//is it really the captain!? -- Step 5
		//lets find out if it has a capital.
		static bool Test_Begins_With_Cap(char c)
		{
			if (c == char.ToUpper(c))
			{
				return true;
			}
			return false;
		}


		// Ohh no! It's too early in the movie to know this quick hide it!
		// (trim first char after making it lowercase) -- Step 6
		static string Hide_The_Captain(string input)
		{
			char Fourth_Wall = input[0];
			input = input.TrimStart(Fourth_Wall);
			Fourth_Wall = char.ToLower(Fourth_Wall);
			input = Fourth_Wall + input;
			return input;
		}


		// use IsVowel method to check for vowels, Find the index and spit it out. -- Step 7
		static void Gimme_A_Vowel_Index(string input, string IsVowel_Index_Out)
		{
			int vIndex = -1;
			for (int i = 0; i < input.Length && vIndex == -1; i++)
			{
				char c = input[i];
				if (IsVowel(c))
				{
					vIndex = i;
				}
			}
			Display(IsVowel_Index_Out + vIndex);
		}


		//split input into seporate words and spit it out. -- Step 8
		static string[] Do_The_Splits(string input)
		{
			string[] words = input.Split();
			foreach (string word in words)
				Display(word);
			return words;
		}


		//clean punctuation, and remove all and save it in a list. -- Step 9
		static List<Char> Do_Dishes(List<Char> punc, string[] words, in char If_Its_This_Dont_Use)
		{
			string[] temp_words = new string[words.Length];
			words.CopyTo(temp_words, 0);
			foreach (string word in temp_words)
			{
				for (int i = 0; i < word.Length; i++)
				{
					if (i == word.Length - 1) // if it's last char save it
					{
						if (char.IsPunctuation(word[i]))
						{
							punc.Add(word[i]);
							words[Array.IndexOf(words, word)] = word.Remove(i, 1);
						}
						else
						{
							punc.Add(If_Its_This_Dont_Use);
						}
					}
					else
					{
						if (char.IsPunctuation(word[i])) //if this letter of this word is punctuation
							words[Array.IndexOf(words, word)] = word.Remove(i, 1); //destroy it.
					}
				}
			}

			return punc;
		}


		//write out the word in piglatin using the piglatin method -- Step 10
		static string[] Onvertcay_Otay_Iglatinpay(string[] words)
		{
			string[] pigwords = new string[words.Length];
			for (int i = 0; i < words.Length; i++)
			{
				pigwords[i] = PigLatin(words[i]);
				Display("The word " + words[i] + "in pig latin is: " + pigwords[i]);
			}
			return pigwords;
		}


		// combine the seporate words into one sentance and output. -- Step 11
		static string PigLatin_complete_Sentance(char[] really_annoying_conversion, string[] pigwords, in char If_Its_This_Dont_Use, string The_Final_Frontier)
		{
			string pigSentence = "";
			for (int i = 0; i < pigwords.Length; i++)
			{
				if (really_annoying_conversion[i] == If_Its_This_Dont_Use)
				{
					pigSentence = pigSentence + The_Final_Frontier + pigwords[i];
				}
				else
				{
					pigSentence = pigSentence + The_Final_Frontier + pigwords[i];
					pigSentence += really_annoying_conversion[i];
				}
			}
			return pigSentence;
		}


		//check for Cap'n if it's him use the Captial. -- step 12
		// Tribute, and y'know making first letter capital for sentance.
		static string Yeah_Thats_Cap(string Big_Star)
		{
			char[] chars = Big_Star.ToCharArray();
			char no_you_move = chars[1];
			char I_Can_Do_This_All_Day = char.ToUpper(no_you_move);
			Big_Star = Big_Star.Remove(0, 1); //not sure where extra space came from but.. lets nuke it so it's nice and pretty.
			Big_Star = Big_Star.Insert(0, I_Can_Do_This_All_Day.ToString());
			return Big_Star;
		}


		public class DisplayBuffer : INotifyPropertyChanged
		{
			private string message;
			// Declare the event
			public event PropertyChangedEventHandler PropertyChanged;

			public DisplayBuffer() { }
			public DisplayBuffer(string value) { this.message = value; }

			public string Message
			{
				get { return message; }
				set
				{
					message = value;               // Call OnPropertyChanged whenever the property is updated
					OnPropertyChanged(message);
				}
			}

			// Create the OnPropertyChanged method to raise the event
			// The calling member's name will be used as the parameter.
			protected void OnPropertyChanged([CallerMemberName] string name = null)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
			}
		}
	

		//input Step 1
		// Wouldn't you like to be a pepper too? -- gets input
		public string Input { get; set; }
		private void InputTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			TextBox textBox = sender as TextBox;

			if (textBox != null)
			{
				Input = textBox.Text;
			}
			Display(Input);
		}

		private void MainWindowOnKeyDown(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Enter)
				RedOrBlue(Input);
			
		}


		private void TextOutMainDisplay_SourceUpdated(object sender, DataTransferEventArgs e)
		{
			TextBox textBox = sender as TextBox;
			DisplayBuffer getMessage = new DisplayBuffer();
			textBox.Text = getMessage.Message;
		}
	}
}
