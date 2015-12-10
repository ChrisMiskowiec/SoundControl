using Akka.Actor;
using Microsoft.Owin.Hosting;
using System;

namespace SoundControl.Service
{
    public class SoundControlService
    {
        private IDisposable _webApp = null;
        private ActorSystem _actorSystem = null;

        public void Start()
        {
            _actorSystem = ActorSystem.Create("my-actor-server");
            _webApp = WebApp.Start<OwinStartup>("http://+:8080/");
        }

        public void Stop()
        {
            _webApp.Dispose();
            _actorSystem.Shutdown();
            _actorSystem.Dispose();
        }
    }
}
