using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;

namespace RecNetImageDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "RecNet Image Downloader by fchb1239";

            try
            {
                Console.Write("Input account: ");
                string player = Console.ReadLine();
                Console.Write("Input the amount of images you want downloaded: ");
                int amount = Int32.Parse(Console.ReadLine());

                if (!new DirectoryInfo($"Output/{player}").Exists)
                    Directory.CreateDirectory($"Output/{player}");

                WebClient wc = new WebClient();
                Player jsonPlayer = JsonConvert.DeserializeObject<Player>(Encoding.UTF8.GetString(wc.DownloadData($"https://accounts.rec.net/account?username={player}")));
                Console.WriteLine($"The account {jsonPlayer.username} has been found");
                List<Image> images = JsonConvert.DeserializeObject<List<Image>>(Encoding.UTF8.GetString(wc.DownloadData($"https://api.rec.net/api/images/v4/player/{jsonPlayer.accountId}?skip=0&take={amount}&sort=0")));
                Console.WriteLine("Got the images");
                foreach (Image i in images)
                {
                    Console.WriteLine(i.ImageName);
                    File.WriteAllBytes($"Output/{jsonPlayer.username}/{i.ImageName}", wc.DownloadData($"https://img.rec.net/{i.ImageName}"));
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (e.ToString().Contains("(404) Not Found"))
                    Console.WriteLine("Could not find player");
                else if (e.ToString().Contains("Input string was not in a correct format"))
                    Console.WriteLine("Inputted amount was not a number");
                else
                    Console.WriteLine(e);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
