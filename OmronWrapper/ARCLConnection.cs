using PrimS.Telnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OmronWrapper
{
    public class ARCLConnection
    {
        internal readonly int timeOutInSeconds = 2;
        private Client client;

        public IPAddress serverAdress { get; set; }
        public int port { get; set; }
        public SecureString password { private get; set; }

        public bool isConnected { get; set; } = false;

        public ARCLConnection(IPAddress _serverAdress, int _port, SecureString _password)
        {
            serverAdress = _serverAdress;
            port = _port;
            password = _password;
        }

        public async Task<bool> connect()
        {
            try
            {
                client = new Client(serverAdress.ToString(), port, new System.Threading.CancellationToken());
                await client.Write(password.ToString());
                Thread.Sleep(TimeSpan.FromSeconds(timeOutInSeconds));
                var response = await client.ReadAsync();
                if(!String.IsNullOrEmpty(response))
                {
                    return true;
                }
                return false;
            }
            catch(Exception exc)
            { 
                //Log exc
                return false;
            }
        }

        public async Task<string> sendCommand(string commandText)
        {
            if(!isConnected)
            {
                await this.connect();
            }

            await client.Write(password.ToString());
            Thread.Sleep(TimeSpan.FromSeconds(timeOutInSeconds));
            return await client.ReadAsync();
        }
    }
}
