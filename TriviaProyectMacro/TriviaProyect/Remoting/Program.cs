using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Remoting; //tecnologia remoting

namespace Remoting
{
    class Program
    {
        static void Main(string[] args)
        {

            RemotingConfiguration.Configure("ConfiguracionRemoting.config", false);

            Console.WriteLine("Escuchando las peticiones via TCPChannel......");
            Console.WriteLine("Presione una tecla para finalizar el programa");

            Console.ReadLine();
        }
    }
}
