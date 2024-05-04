using ETHTPS.WSB.Services;

namespace ETHTPS.Grabber
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sweeper = new L2Sweeper(new HttpClient());
            Task.Run(async () =>
            {
                var networkDescriptors = await sweeper.SweepAsync();
                var proxy = new L2Proxy(networkDescriptors, new HttpClient());
                foreach (var network in networkDescriptors)
                {

                }
            });
        }
    }
}
