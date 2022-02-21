using ITHelper.Application.Models.NetworkModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Features.NetworkFeatures
{
    public class PingNetwork
    {

        public List<Host> Hosts { get; set; }
        public int NetworkMax { get; set; }
        public int NetworkMin { get; set; }
        public string Subnet { get; set; }
        private readonly Ping _ping;
        private string localhost = Dns.GetHostName();

        private IPHostEntry ipEntry;

        public PingNetwork()
        {

            ipEntry = Dns.GetHostEntry(localhost);

            var ip = ipEntry.AddressList;

            Subnet = ip[1].ToString().Substring(0, 11);

            _ping = new Ping();
            Hosts = new List<Host>();
        }

        public void InitiateSubnetScan(int NetworkMax = 254, int NetworkMin = 1)
        {
            for (int i = NetworkMin; i < NetworkMax + 1; i++)
            {
                PingIp($"{Subnet}.{i}");
            }
        }

        public void PingIp(string ip)
        {
            Console.WriteLine($"Pinging {ip} ...");
            var reply = _ping.Send(ip, 100);
            if (reply.Status == IPStatus.Success)
            {

                try
                {
                    var host = Dns.GetHostEntry(IPAddress.Parse(ip));
                    Hosts.Add(new Host { Name = host.HostName, IPAddress = ip, IsActive = true });
                }
                catch
                {
                    Hosts.Add(new Host { IPAddress = ip, IsActive = true });
                }

            }

        }
    }
}

