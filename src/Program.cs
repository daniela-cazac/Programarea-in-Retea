﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Enter - Download data", ConsoleColor.White);

                var key = Console.ReadKey(false);

                    Raport raport = new Raport();

                    switch (key.Key)
                    {
                        case ConsoleKey.Enter:
                            raport.Download();
                            break;
                        default:
                            continue;
                    }

                raport.Afisare();
                Console.ReadKey(true);
            }
            while (true);
        }
    }
}
