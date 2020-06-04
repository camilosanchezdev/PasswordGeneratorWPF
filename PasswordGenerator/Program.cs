using System;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace PasswordGenerator
{
    class PassGenerator
    {


        // Questions
        public void Questions()
        {
            int passLength = 0;
            Console.WriteLine("\n\nPassword Length (1 - 36)");
            passLength = int.Parse(Console.ReadLine());
            while (passLength < 1 || passLength > 36)
            {
                Console.WriteLine("Out of range number");
                Console.WriteLine("\n\nPassword Length (1 - 36)");
                passLength = int.Parse(Console.ReadLine());
            }
            string allCharacters = "abcdefghijkmnopqrstuvwxyz";
            string capitalLetters = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string symbols = "!@$?_-";
            
            Console.WriteLine("Include Capitals Letters? Indicate y/n");
            char decUpp = char.Parse(Console.ReadLine());
            Console.WriteLine("Include Numbers? Indicate y/n");
            char decNum = char.Parse(Console.ReadLine());
            Console.WriteLine("Include Symbols? Indicate y/n");
            char decSim = char.Parse(Console.ReadLine());
            if (decUpp.Equals('y'))
            {
                allCharacters += capitalLetters;
            }
            if (decNum.Equals('y'))
            {
                allCharacters += numbers;
            }
            if (decSim.Equals('y'))
            {
                allCharacters += symbols;
            }
            Generator(allCharacters, passLength);

        }
        //Generator
        public void Generator(string x, int psw)
        {
            
            char ans;
            string result;
            Random rnd = new Random();
            
            char[] passChar = new char[psw];
            for (int i = 0; i < psw; i++)
            {
                passChar[i] = x[rnd.Next(0, x.Length)];
            }
            result = new string(passChar);
            Console.Write("Password generated: " + result);
            // Generate another passwords
            do
            {
                Console.WriteLine("\nIndicate 'y' to generate another password or 'n' to finish");
                ans = char.Parse(Console.ReadLine());
                if (ans == 'y')
                {
                    for (int i = 0; i < psw; i++)
                    {
                        passChar[i] = x[rnd.Next(0, x.Length)];
                    }
                    result = new string(passChar);
                    Console.Write("Password generated: " + result);
                }
            } while (ans == 'y');

        }

        static void Main(string[] args)
        { 
            Console.WriteLine("Password Generator");
            Console.WriteLine("==================");
            PassGenerator pw = new PassGenerator();
            pw.Questions();

            Console.ReadKey();
        }


    }
}
