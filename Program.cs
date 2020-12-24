using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Diagnostics;

namespace Dollista
{
    class Program
    {
        public static string API = "https://dollista.eu/register/";


        public static async Task Checker()
        {
            while (true)
            {
                Random rand = new Random();
                Thread.Sleep(rand.Next(1000, 5000));
                Process[] workers = Process.GetProcessesByName("Dollista");
                if (workers.Length >= 2)
                {
                    foreach(Process proc in workers)
                    {
                        proc.Kill();
                    }
                   
                }
                else
                {
               
               
                }
            }
        }

        static void Main(string[] args)
        {
            Task.Run(() => Checker());
            Console.Title = "🖤";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@" _____     ______     __         __         __     ______     ______   ______     __  __    ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"/\  __-.  /\  __ \   /\ \       /\ \       /\ \   /\  ___\   /\__  _\ /\  __ \   /\_\_\_\   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"\ \ \/\ \ \ \ \/\ \  \ \ \____  \ \ \____  \ \ \  \ \___  \  \/_/\ \/ \ \ \/\ \  \/_/\_\/_  ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@" \ \____-  \ \_____\  \ \_____\  \ \_____\  \ \_\  \/\_____\    \ \_\  \ \_____\   /\_\/\_\ ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"  \/____/   \/_____/   \/_____/   \/_____/   \/_/   \/_____/     \/_/   \/_____/   \/_/\/_/ ");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                       FREE Version | Created by deko from skdv \n\n");
            Console.WriteLine("NOTICE: U cant open more than 1 tool, so dont even try\n");
            Console.WriteLine("[$] Select module:");
            Console.WriteLine("[1] Exclusive Coins Farmer");
            ConsoleKeyInfo Info = Console.ReadKey();
            switch (Info.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("");
                    Console.WriteLine("Your UserId (Check with Charles or other shit im too lazy to make grabber by name):");

                    string UserId = Console.ReadLine();
                    Console.WriteLine("Generating...");
                    for (int i = 0; i < int.MaxValue; i++){
                        Task.Delay(500).Wait();
                        Console.Title = $"❤ - Gifts: {i}";
                        Task.Run(() => Refresh("2", UserId));
                    }                 
                    break;
            }

            
            Console.ReadKey();

        }


        public static async Task GiftMoney(string PHPSESSID, string UserId)
        {
            Uri uri = new Uri("https://dollista.eu/on/service/friendgift/");
            CookieContainer Cont = new CookieContainer();
            HttpClientHandler Handler = new HttpClientHandler { CookieContainer = Cont };
            HttpClient Client = new HttpClient(Handler);
            Cont.Add(uri, new Cookie("PHPSESSID", PHPSESSID));
            StringContent Content = new StringContent($"userid={UserId}&type=1");
            Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            Client.DefaultRequestHeaders.Add("referer", "https://dollista.eu/on/home/");
            Client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36");
            await Client.PostAsync("https://dollista.eu/on/service/friendgift/", Content);
        }
        public static async Task Refresh(string Type, string UserId)
        {
           

                    CookieContainer Cookie1 = new CookieContainer();
                    HttpClientHandler Handler1 = new HttpClientHandler { CookieContainer = Cookie1 };
                    HttpClient Client1 = new HttpClient(Handler1);
                    await Client1.GetAsync("https://dollista.eu/");
                    Uri uri1 = new Uri("https://dollista.eu/");
                    IEnumerable<Cookie> cookies1 = Cookie1.GetCookies(uri1).Cast<Cookie>();
                    foreach (var cookie in cookies1)
                    {
                        string Pusia = cookie.Value;
     
                        Task.Run(() => Generator(Pusia));
                        Task.Run(() => GiftMoney(Pusia, UserId));
                    }
            
        }
 
        public static async Task Generator(string PHPSESSID)    
        {
            Uri uri = new Uri(API);
            CookieContainer Cont = new CookieContainer();
            HttpClientHandler Handler = new HttpClientHandler { CookieContainer = Cont };
            HttpClient Client = new HttpClient(Handler);
                Random rand = new Random();

                Cont.Add(uri, new Cookie("PHPSESSID", PHPSESSID));
                string Username = $"{rand.Next(0, int.MaxValue)}{rand.Next(0, int.MaxValue)}";
                StringContent Content = new StringContent($"username={Username}&password_1=lol123&password_2=lol123&hash=e04e73f6f1b32d1ef017b1b77c9700d2&skin=3&face=2&hair=16&top=9&pants=19&shoes=106&reg_user=finished");
                Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                Client.DefaultRequestHeaders.Add("referer", "https://dollista.eu/register/");
                Client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36");
                Client.DefaultRequestHeaders.Add("origin", "https://dollista.eu");
                await Client.PostAsync(API, Content);                    



        }
    }
}
