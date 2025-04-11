using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string secretWord = "dog";
        int maxAttempts = 6;
        int remainingAttempts = maxAttempts;
        char[] maskedWord = new string('_', secretWord.Length).ToCharArray();
        HashSet<char> guessedLetters = new HashSet<char>();

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Congratulations! Try to guess the encrypted word!");
        Console.WriteLine($"Number of letters in the word: {secretWord.Length}");
        Console.WriteLine($"Number of possible incorrect attempts: {maxAttempts}\n");

        while (remainingAttempts > 0 && new string(maskedWord) != secretWord)
        {
            Console.Write("Enter your letter:");
            string input = Console.ReadLine().ToLower();

            if (string.IsNullOrWhiteSpace(input) || input.Length != 1 || !char.IsLetter(input[0]))
            {
                Console.WriteLine("Please enter one letter.");
                continue;
            }

            char letter = input[0];

            if (guessedLetters.Contains(letter))
            {
                Console.WriteLine("This letter has already been entered. Try another one.");
                continue;
            }

            guessedLetters.Add(letter);

            if (secretWord.Contains(letter))
            {
                Console.Write($"This letter is in the word! Letter position: ");
                List<int> positions = new List<int>();

                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == letter)
                    {
                        maskedWord[i] = letter;
                        positions.Add(i + 1);
                    }
                }

                Console.WriteLine(string.Join(",", positions));
            }
            else
            {
                remainingAttempts--;
                Console.WriteLine($"There is no such letter! Remaining attempts: {remainingAttempts}");
            }
        }

        if (new string(maskedWord) == secretWord)
        {
            Console.WriteLine($"\nCongratulations, you guessed the word! Encrypted word: {secretWord}.");
        }
        else
        {
            Console.WriteLine($"\nUnfortunately, you lost. The guessed word was: {secretWord}.");
        }

        Console.WriteLine("Thanks for the game.");
    }
}
