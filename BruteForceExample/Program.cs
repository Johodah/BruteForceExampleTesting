using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace BruteForceExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.Write("Password (max 6 characters, recommended 4): ");
            String password = Console.ReadLine();

            Thread.Sleep(1000);
            Console.WriteLine("Brute-Force hacking starts...");

            String current = "";

            int[] pos = { 0, 0, 0, 0, 0, 0 };

            String[] alphabet = { "", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "å", "ä", "ö" };

            int count = 0;
            int captchaCount = 0;

            while (!current.Equals(password))
            {   

                for (int i = 0; i < pos.Length; i++)
                {
                    if (pos[i] == alphabet.Length)
                    {
                        pos[i] = 0;
                        pos[i + 1]++;
                    }
                }

                current = (alphabet[pos[5]] + alphabet[pos[4]] + alphabet[pos[3]] + alphabet[pos[2]] + alphabet[pos[1]] + alphabet[pos[0]]).ToString();

                Console.WriteLine($"\nLetter sequence: {current}");

                pos[0]++;
            
                count++;
                
                byte[] captchaBytes = new byte[4];
                RandomNumberGenerator rnd = RandomNumberGenerator.Create();
                rnd.GetBytes(captchaBytes);
                string captchaString = Convert.ToBase64String(captchaBytes);

                if (count >= 3)
                {
                    Console.Write($"\nToo many password attempts!\nWrite captcha \"{captchaString}\" to proceed....: ");
                   
                    string attemptForCaptcha = Console.ReadLine();
                    
                    if (!captchaString.Equals(attemptForCaptcha))
                    {
                        Console.WriteLine("Captcha incorrect!\n" +
                            "Our system will block the incoming IP now.");
                        Environment.Exit(1);
                    }
                    else
                    {
                        captchaCount++;
                        count = 0;
                        Console.WriteLine("Captcha correct");
                        if (captchaCount >= 3)
                        {
                            Console.WriteLine("\n\nToo many captcha attempts!\n\n" +
                                "Our system will block the incoming IP now.");
                            Environment.Exit(1);
                        }
                        continue;
                    }
                }

                if (password.Equals(current))
                {
                    Console.WriteLine("Password found");
                }
                else
                {
                    Console.WriteLine("Password not found");
                }
            }

        }
    }
}