using Akka.Actor;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundControl.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<OwinStartup>("http://+:8080"))
            using (var system = ActorSystem.Create("my-actor-server"))
            {
                var soundActor = system.ActorOf<SystemSoundActor>();

                Console.ReadLine();

                system.Shutdown();
            }
        }
    }
}
