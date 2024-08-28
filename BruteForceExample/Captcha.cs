using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceExample
{
    public class Captcha
    {
        string current = "";

        int[] pos = { 0, 0, 0, 0, 0, 0 };

        string[] alphabet = { "", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "å", "ä", "ö" };

        int count = 0;
        int captchaCount = 0;
        public bool CaptchaCheck(string password)
        {
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

                if (count % 1 == 0) Console.WriteLine($"\nLetter sequence: {current}");

                pos[0]++;

                count++;

                //byte[] captchaBytes = new byte[4];
                //RandomNumberGenerator rnd = RandomNumberGenerator.Create();
                //rnd.GetBytes(captchaBytes);
                //string captchaString = Convert.ToBase64String(captchaBytes);
                string captchaString = "captchatest";

                if (count >= 3)
                {
                    Console.Write($"\nToo many password attempts!\nWrite captcha \"{captchaString}\" to proceed....: ");

                    string attemptForCaptcha = Console.ReadLine();

                    if (!captchaString.Equals(attemptForCaptcha))
                    {
                        Console.WriteLine("Captcha incorrect!\n" +
                            "Our system will block the incoming IP now.");
                        //Environment.Exit(1);
                        return false;
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
                            //Environment.Exit(1);
                            return false;
                        }
                        continue;
                    }
                }

            }
            if (password.Equals(current))
            {   
                Console.WriteLine("Password found");
                return true;
            }
            else
            {
                Console.WriteLine("Password not found");
                return false;
            }
        }

    }
}
