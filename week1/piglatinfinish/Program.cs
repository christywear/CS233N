﻿using System;

public class Program
{
	/*  1.==============================================================================================
		Design and implement a program that processes a string entered from the keyboard.  The application will
		- convert the string to upper and lowercase
		- reverse the string
		- count the number punctuation characters in the string
		- find the index of the first vowel in the string
		- divide the string up into "words"
		
		Visual Studio Solution:  https://drive.google.com/open?id=1ygPPxjQF1L6FMODLoCxn_C7KFxnQKKR7
		
		MAC Visual Studio Solution:  https://drive.google.com/open?id=1dK_YsJ_ZgWSdKalFoNm8eENYW6VIaRJv
		
		2.==============================================================================================
		Design and implement a program that converts a sentence entered by the user into pig latin.
		- version 1 - 	moves the first character to the end and adds ay
		- version 2 - 	words that start with vowels - add way to the end
						words that start with consonants - same as version 1
		- version 3 - 	words that start with multiple consonants should 
						move all consonants to the end and add ay
		- version 4 - 	words that start with a capital letter should capitalize 
						only the first letter of the pig latin word
		- version 5 -	words that end with punctuation should put the punctuation
						at the end of the pig latin word
		- version 6 - 	process a whole sentence.  Whitespace removed from the
						original input should be replaced with a single space.
						
    */
	public static void Main()
	{
		Console.WriteLine("Please enter a word or phrase.  Press the ENTER key when you're done.");
		string input = Console.ReadLine();

		string lower = input.ToLower();
		Console.WriteLine("Converted to lowercase: " + lower);
		string upper = input.ToUpper();
		Console.WriteLine("Converted to uppercase: " + upper);

		string reverse = "";
		foreach (char c in input)
			reverse = c + reverse;
		Console.WriteLine("In reverse: " + reverse);

		int pCount = 0;
		foreach (char c in input)
			if (Char.IsPunctuation(c))
				pCount++;
		Console.WriteLine("Puncutation count: " + pCount);

		int vIndex = -1;
		for (int i = 0; i < input.Length && vIndex == -1; i++)
		{
			char c = input[i];
			if (IsVowel(c))
				vIndex = i;
		}
		Console.WriteLine("The index of the first vowel is: " + vIndex);

		string[] words = input.Split();
		foreach (string word in words)
			Console.WriteLine(word);

		string[] pigwords = new string[words.Length];
		for (int i = 0; i < words.Length; i++)
		{
			pigwords[i] = PigLatin(words[i]);
			Console.WriteLine("The word {0} in pig latin is: {1}", words[i], pigwords[i]);
		}


		string pigSentence = "";
		foreach (String word in pigwords)
			pigSentence = pigSentence + " " + word;
		Console.WriteLine("All together now! " + pigSentence);

	}

	static bool IsVowel(char c)
	{
		bool IsItVowel;
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

	static int IndexOfFirstVowel(string s)
	{
		int vIndex = -1;
		return vIndex;
	}

	static string PigLatin(string s)
	{
		const string AddAy = "ay";
		const string AddWay = "way";
		char TestingFirstLetter = s[0];
		bool TestVowel = IsVowel(TestingFirstLetter);
		// preparing for piglatin convert
		s = s.TrimStart(TestingFirstLetter);
		s = s + TestingFirstLetter;
		if (TestVowel == true)
		{
			s += AddWay;
		}
		else { s += AddAy; }

		return s;
	}

}