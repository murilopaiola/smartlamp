using System;
using SmartLamp.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace SmartLamp.EventHandlers
{
    public class WriteEventArgs : EventArgs
    {
        public byte[] Data { get; set; }
        public WriteEventArgs(byte[] message) => Data = message;
    }

    public class IOEventHandler
    {
        private SerialPort _serialPort;

        public IOEventHandler(MainViewModel viewModel, string serialPortNumber)
        {
            _serialPort = new SerialPort($"COM{serialPortNumber}");

            // Subscribe
            _serialPort.DataReceived += OnReadDataReceived;
            viewModel.WriteEvent += OnWriteDataReceived;
        }

        private void OnReadDataReceived(object s, SerialDataReceivedEventArgs e)
        {
            //Send to ViewModel
        }

        private void OnWriteDataReceived(object s, WriteEventArgs e)
        {
            //Write to COM port stream
        }
    }
}
