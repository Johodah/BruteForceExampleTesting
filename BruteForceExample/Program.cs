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

            Thread.Sleep(5000);
            Console.WriteLine("\nBrute-Force hacking starts...");
            Captcha captcha = new Captcha();
            
            Console.WriteLine(captcha.CaptchaCheck(password));

        }
    }
}