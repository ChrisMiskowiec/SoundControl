using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundControl.Service
{
    public static class SystemActors
    {
        public static IActorRef SystemSoundActor = ActorRefs.Nobody;
    }
}
