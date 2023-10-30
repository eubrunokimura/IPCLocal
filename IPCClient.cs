using System;
using System.IO;
using System.IO.Pipes;
using Newtonsoft.Json;

namespace IPCLocal
{
    // IPCServer class remains the same, just use IPCMessage instead of string

    public class IPCClient
    {
        private NamedPipeClientStream pipeClient;

        public IPCClient(string pipeName)
        {
            pipeClient = new NamedPipeClientStream(".", pipeName, PipeDirection.InOut);
        }

        public void Connect()
        {
            pipeClient.Connect();
        }

        public void Send(IPCMessage message)
        {
            using (StreamWriter writer = new StreamWriter(pipeClient))
            {
                string jsonMessage = JsonConvert.SerializeObject(message);
                writer.Write(jsonMessage);
                writer.Flush();
            }
        }

        public void Disconnect()
        {
            pipeClient.Close();
        }
    }
}
