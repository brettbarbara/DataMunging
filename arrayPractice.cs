using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    public class Arrays
    {
        static void Main(string[] args)
        {
            //----problem1-----//
            //IsUnique isUnique = new IsUnique();
            

            //----problem2----//
            //OneAway oneAway = new OneAway();
            //bool value = oneAway.areStringOneEditAway("11222","112222222");

            //ReverseString reverseString = new ReverseString();
            
            //string value = reverseString.reverseStringMethod("word ");
            string something = ReverseString.ReverseWord2("bubble happy");
            Console.WriteLine(something);
        }
    }

    public class IsUnique
    {
        public bool arrayIsUnique(string word)
        {
            List<char> listOfLetters = word.ToList();
            if(listOfLetters.Count() != listOfLetters.Distinct().Count())
            {
                return false;
            }
            return true;
        }
    }

    public class OneAway 
    {
        public bool areStringOneEditAway(string word1, string word2)
        {
            //bool isACharacterInsertedOrDeleted = false;
            if (word1.Length != word2.Length)
            {
                return true;
            }

            char[] listOfLetters1 = word1.ToCharArray();
            char[] listOfLetters2 = word2.ToCharArray();

            for (int i = 0; i < word1.Length; i++)
            {
                if (listOfLetters1[i] != listOfLetters2[i])
                {
                    return true;
                }
            }

            return false;
        }
    }

    public static class ReverseString
    {

        // public string reverseStringMethod(string word)
        // {
        //     int lengthOfString = word.Length;
        //     //List<char> wordList = new List<char>();

        //     char[] wordArray = new char[lengthOfString];

        //     wordArray = word.ToCharArray();
            
        //     int currentWord = 0;

        //     for(int i = 0; i <lengthOfString; i++)
        //     {
        //         if(wordArray[i] != ' ')
        //         {
        //             currentWord++;
        //         }

        //         if(wordArray[i] == ' ')
        //         {
        //             for(int j = 0; j < (currentWord/2); j++)
        //             {
        //                 var beginningSwap = wordArray[j];
        //                 var endSwap = wordArray[currentWord - j];

        //                 wordArray[j] = endSwap;
        //                 wordArray [currentWord - j] = beginningSwap;
        //             }

        //             currentWord = 0;
        //         }
        //     }

        //     string reversedString = new string(wordArray);
        //     return reversedString;
        // }

        public static string ReverseWord(string word)
        {
            //ex 'bubble happy'
            //output: 'elbbub yppah'

            char[] wordArray = new char[word.Length];

            char[] reversedWords = new char[word.Length];

            wordArray = word.ToCharArray();

            int wordCounter = 0;

            for(int i = 0; i < word.Length; i++)
            {
                if(wordArray[i] == ' ')
                {
                    for(int j = 0; j < wordCounter; j++)
                    {
                        char lastLetter = wordArray[wordCounter - j];
                        reversedWords[j] = lastLetter;
                    }
                    wordCounter = 0;
                }

                if(wordArray[i] != ' ')
                {
                    wordCounter++;
                }
            }

            return reversedWords.ToString();
        }

        public static string ReverseWord2(string word)
        {
            string[] ourWords = word.Split(' ');
            string[] ourReversedWords = new string[ourWords.Length];
            string ourReversedString = "";

            for(int i = 0; i < ourWords.Length; i++)
            {
                char[] currentWord = ourWords[i].ToCharArray();
                List<char> reversedWordList = new List<char>();
                char[] reversedWord = new char[ourWords[i].Length];

                for(int j = currentWord.Length - 1; j >= 0; j--)
                {
                    reversedWordList.Add(currentWord[j]);
                }

                ourReversedWords[i] = string.Join("", reversedWordList);
            }

            return ourReversedString = string.Join(" ", ourReversedWords);

        }
    }
}

