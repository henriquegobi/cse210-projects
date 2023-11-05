using System;

class Program
{
    static void Main(string[] args)
    {

        Random randomGenerator = new Random();
        int magic_number = randomGenerator.Next(1, 11);

        int number_guess;
        do
        {
            Console.WriteLine("What is your guess?");

            number_guess = int.Parse(Console.ReadLine());

            if (magic_number == number_guess)
            {
                Console.WriteLine("You guessed it!");
            }
            else if (number_guess > magic_number)
            {
                Console.WriteLine("Lower");
            }
            else if (number_guess < magic_number)
            {
                Console.WriteLine("Higher");
            }
        }while (magic_number != number_guess);
    }
}