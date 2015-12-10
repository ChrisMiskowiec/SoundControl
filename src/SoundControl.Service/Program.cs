using Topshelf;

namespace SoundControl.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<SoundControlService>(s =>
                {
                    s.ConstructUsing(n => new SoundControlService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsNetworkService();

                x.SetDescription("System Sound Control");
                x.SetDisplayName("Sound Control");
                x.SetServiceName("SoundControl");
            });
            System.Console.ReadLine();
        }
    }
}
