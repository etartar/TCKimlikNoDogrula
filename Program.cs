using System;
using System.Threading.Tasks;
using TCKimlikNoDogrula.Models;
using TCKimlikNoDogrula.PersonService;

namespace TCKimlikNoDogrula
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonServiceManager personServiceManager = new PersonServiceManager();

            Console.WriteLine("TC Kimlik Numaranizi giriniz : ");
            long citizenId = Convert.ToInt64(Console.ReadLine().Trim());

            Console.WriteLine("Adinizi giriniz : ");
            string name = Console.ReadLine().Trim();

            Console.WriteLine("Soyadinizi giriniz : ");
            string surname = Console.ReadLine().Trim();

            Console.WriteLine("Dogum yilinizi giriniz : ");
            int birthyear = Convert.ToInt32(Console.ReadLine().Trim());

            var citizen = new Citizen
            {
                CitizenId = citizenId,
                Name = name,
                Surname = surname,
                BirthYear = birthyear
            };

            var runTask = Task.Run(() => personServiceManager.VerifyCid(citizen));

            if (runTask.Result)
                ColoredWriteLine(ConsoleColor.Green, "TC Kimlik no dogrulama basarili.");
            else
                ColoredWriteLine(ConsoleColor.Red, "TC Kimlik no dogrulama basarisiz.");
        }

        static void ColoredWriteLine(ConsoleColor consoleColor, string message)
        {
            Console.BackgroundColor = consoleColor;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
