using Akka.Actor;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundControl.Service
{
    public class WebModule : NancyModule
    {
        public WebModule()
        {
            Get["/"] =
                parameters => @"
<html>
    <head>
        <style type='text/css'>
            input {
                display: block; 
                margin: 50px auto; 
                width: 80%; 
                height: 200px; 
                font-size: 50px
            }
        </style>
    </head>
    <body>
            <form action='/mute' method='POST'>
                <input name='mute' value='mute' type='submit' />
            </form>
            <form action='/unmute' method='POST'>
                <input name='unmute' value='unmute' type='submit' />
            </form>
    </body>
</html>";

            Post["/mute"] =
                parameters =>
                {
                    SystemActors.SystemSoundActor.Tell(new SystemSoundActor.MuteMessage(), ActorRefs.NoSender);
                    return Response.AsRedirect("/");
                };

            Post["/unmute"] =
                parameters =>
                {
                    SystemActors.SystemSoundActor.Tell(new SystemSoundActor.UnmuteMessage(), ActorRefs.NoSender);
                    return Response.AsRedirect("/");
                };
        }
    }
}
