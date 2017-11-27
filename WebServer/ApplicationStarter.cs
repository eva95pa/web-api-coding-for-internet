using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    class ApplicationStarter
    {
        static void Main(string[] args)
        {
            WebServer server = new WebServer(8080);
            server.Start();
            Console.WriteLine("Press any key to shut down the application");
            Console.ReadKey();
        }
    }
}
