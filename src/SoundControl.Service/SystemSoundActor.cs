using Akka.Actor;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundControl.Service
{
    public class SystemSoundActor : 
        TypedActor, 
        IHandle<SystemSoundActor.MuteMessage>,
        IHandle<SystemSoundActor.UnmuteMessage>
    {
        public class MuteMessage { }
        public class UnmuteMessage { }

        public void Handle(MuteMessage message)
        {
            SetMute(true);
        }

        public void Handle(UnmuteMessage message)
        {
            SetMute(false);
        }

        private void SetMute(bool mute)
        {
            var mmde = new MMDeviceEnumerator();
            var devices = mmde.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            foreach (var device in devices)
            {
                try
                {
                    device.AudioEndpointVolume.Mute = mute;
                }
                catch
                {
                }
            }
        }
    }
}
