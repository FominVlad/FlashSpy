using FlashSpyCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlashSpyCore
{
    class AdminTools
    {
        FlashSpyDbContext db;

        public AdminTools(FlashSpyDbContext dbContext)
        {
            this.db = dbContext;
        }

        public void InitMenu()
        {
            while (true)
            {
                string inputed = Console.ReadLine();

                if (inputed[0].Equals('/'))
                {
                    SwitchActions(inputed);
                }
            }
        }

        public void SwitchActions(string command)
        {
            switch (command)
            {
                case "/help":
                    {
                        PrintHelp();
                        break;
                    }
                case "/hello":
                    {
                        Printer.PrintHelloWorld();
                        break;
                    }
                case "/levels":
                    {
                        PrintLevels();
                        break;
                    }
                default:
                    {
                        Printer.PrintDangerMessage("Invalid command! Try again.");
                        break;
                    }
            }
        }

        public void PrintHelp()
        {
            string helpMessage = "-------- HELP --------\n" +
                "/help - command list.\n" +
                "/hello - hello world.\n" +
                "/levels - get log level list.";

            Printer.PrintInfoMessage(helpMessage);
        }

        public List<Level> GetLevels()
        {
            return db.Levels.ToList();
        }

        public void PrintLevels()
        {
            Console.WriteLine("Levels in database:");

            foreach (Level level in this.GetLevels())
            {
                Console.WriteLine($"Id: {level.Id} | Name: {level.LevelName}");
            }
        }
    }
}
