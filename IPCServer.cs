using System;
using System.IO;
using System.IO.Pipes;
using Newtonsoft.Json;

namespace IPCLocal
{
    public class IPCServer
    {
        private NamedPipeServerStream pipeServer;
        private bool isRunning = false;

        public event EventHandler<IPCMessage> MessageReceived;

        public IPCServer(string pipeName)
        {
            pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
        }

        public void Start()
        {
            isRunning = true;
            pipeServer.BeginWaitForConnection(HandleClientConnection, null);
        }

        public void Stop()
        {
            isRunning = false;
            pipeServer.Close();
        }

        private void HandleClientConnection(IAsyncResult result)
        {
            if (isRunning)
            {
                pipeServer.EndWaitForConnection(result);

                using (StreamReader reader = new StreamReader(pipeServer))
                {
                    string jsonMessage = reader.ReadToEnd();
                    IPCMessage message = JsonConvert.DeserializeObject<IPCMessage>(jsonMessage);
                    MessageReceived?.Invoke(this, message);
                }

                pipeServer.Disconnect();
                pipeServer.BeginWaitForConnection(HandleClientConnection, null);
            }
        }
    }
}
