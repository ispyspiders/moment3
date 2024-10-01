// Inlämningsuppgift i kursen Programmering i C#.NET (DT071G) vid Mittuniveristetet
// Skapad av Kajsa Classon, HT24
// Moment 3 - Objektorienterad programmering
// En konsollapplikation som fungerar som en gästbok.

using System;

namespace guestbook
{
    class Program
    {
        static void Main(string[] args)
        {
            Guestbook guestbook = new Guestbook(); //Ny instans av Guestbook
            int i = 0;

            while (true)
            {
                // Skriv ut meny
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("KAJSAS GÄSTBOK\n\n");

                Console.WriteLine("1. Skriv i gästboken");
                Console.WriteLine("2. Ta bort inlägg\n");

                Console.WriteLine("X. Avsluta\n");

                i = 0;
                // Skriv ut alla inlägg
                foreach (Post post in guestbook.GetPosts())
                {
                    Console.WriteLine($"[{i++}] {post.Name} - {post.Message}");
                }

                int input = (int)Console.ReadKey(true).Key;
                switch (input)
                {
                    case '1': //Skriv i gästboken
                        Console.CursorVisible = true;
                        Console.Write("Namn: ");
                        string? name = Console.ReadLine();
                        Console.Write("Meddelande: ");
                        string? msg = Console.ReadLine();
                        if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(msg)) guestbook.AddPost(name, msg);
                        break;
                    case '2':
                        Console.CursorVisible = true;
                        Console.Write("case 2");
                        break;
                    case 88:
                        Environment.Exit(0);
                        break;
                }


            }



        }
    }
}