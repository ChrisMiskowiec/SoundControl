using Akka.Actor;
using Owin;

namespace SoundControl.Service
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();

            ActorSystemRefs.ActorSystem = ActorSystem.Create("sound-control");

            SystemActors.SystemSoundActor = ActorSystemRefs.ActorSystem.ActorOf<SystemSoundActor>();
        }
    }
}
