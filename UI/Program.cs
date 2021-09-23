using System;
using Models;
using StoreBL;
using DL;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Case Sensitive!");
            new MainMenu(new BL(new ExampleRepo())).Start();
        }
    }
}
