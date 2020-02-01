using System.Threading;

namespace FlashSpyCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FlashSpyDbContext dbContext = new FlashSpyDbContext())
            {
                Printer.PrintSuccessMessage("Listening start successful.");
                Printer.PrintInfoMessage("\nInput '/help' to get help.");

                DirectoryAdmin directoryAdmin = new DirectoryAdmin(dbContext);

                TimerCallback tc = new TimerCallback(directoryAdmin.FlashRendering);

                Timer timer = new Timer(tc, null, 0, 1000);

                AdminTools tools = new AdminTools(dbContext);

                tools.InitMenu();
            }
        }
    }
}
