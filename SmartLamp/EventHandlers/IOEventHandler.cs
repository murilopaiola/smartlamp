using System;
using SmartLamp.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using SmartLamp.Models;
using System.Diagnostics;

namespace SmartLamp.EventHandlers
{
    public class WriteEventArgs : EventArgs
    {
        public SLBuffer Data { get; set; }
        public WriteEventArgs(SLBuffer message) => Data = message;
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
            e.Data.UpdateBufferCrc();
            Trace.WriteLine(BitConverter.ToString(e.Data.bytes));
            //Write to COM port stream
        }
    }
}
