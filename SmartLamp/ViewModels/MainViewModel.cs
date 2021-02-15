using Microsoft.Extensions.Configuration;
using SmartLamp.EventHandlers;
using SmartLamp.Extensions;
using SmartLamp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLamp.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly IOEventHandler _ioEventHandler;

        public SLBuffer Buffer = new SLBuffer(11);

        #region Properties
        public string Net
        { 
            get
            {
                return Convert.ToString(Buffer.bytes[0]);
            }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                Buffer.Net = value;
                OnPropertyChanged(nameof(Net));
                OnPropertyChanged(nameof(Buffer));
                OnBufferChanged(new WriteEventArgs(Buffer.bytes));
            }
        }

        public string Group
        {
            get
            {
                return Convert.ToString(Buffer.bytes[1]);
            }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                Buffer.Group = value;
                OnPropertyChanged(nameof(Group));
                OnPropertyChanged(nameof(Buffer));
                OnBufferChanged(new WriteEventArgs(Buffer.bytes));
            }
        }

        public string Id
        {
            get
            {
                return Convert.ToString(BitConverter.ToUInt16(new byte[2] { Buffer.Idh, Buffer.Idl }, 0));
            }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                ushort intValue = Convert.ToUInt16(value);
                var bytes = BitConverter.GetBytes(intValue);
                Buffer.Idh = bytes[0];
                Buffer.Idl = bytes[1];
                OnPropertyChanged(nameof(Id));
                OnPropertyChanged(nameof(Buffer));
                OnBufferChanged(new WriteEventArgs(Buffer.bytes));
            }
        }

        public string Endi
        {
            get
            {
                return Convert.ToString(Buffer.bytes[5]);
            }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                Buffer.Endih = value;
                OnPropertyChanged(nameof(Endi));
                OnPropertyChanged(nameof(Buffer));
                OnBufferChanged(new WriteEventArgs(Buffer.bytes));
            }
        }

        public string Endf
        {
            get
            {
                return Convert.ToString(Buffer.bytes[7]);
            }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                Buffer.Endfh = value;
                OnPropertyChanged(nameof(Endf));
                OnPropertyChanged(nameof(Buffer));
                OnBufferChanged(new WriteEventArgs(Buffer.bytes));
            }
        }

        public string Param
        {
            get
            {
                return Convert.ToString(Buffer.bytes[9]);
            }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                Buffer.Param = value;
                OnPropertyChanged(nameof(Param));
                OnPropertyChanged(nameof(Buffer));
                OnBufferChanged(new WriteEventArgs(Buffer.bytes));
            }
        }

        public string Funcao
        {
            get
            {
                return Convert.ToString(Buffer.bytes[4]);
            }
            set
            {
                Buffer.Funcao = value;
                OnPropertyChanged(nameof(Funcao));
                OnPropertyChanged(nameof(Buffer));
                OnBufferChanged(new WriteEventArgs(Buffer.bytes));
            }
        }

        public string[] IdRange;

        private string _outputRange { get; set; }

        public string OutputRange
        {
            get
            {
                return _outputRange;
            }
            set
            {
                _outputRange = value;

                var split = value.Split(new char[] { ',', '-' });

                foreach (var id in split)
                    if (!int.TryParse(id, out int _))
                        throw new ArithmeticException("Output Range value is invalid.");

                IdRange = split;

                OnPropertyChanged(nameof(OutputRange));
            }
        }

        #endregion

        public MainViewModel(IConfiguration config)
        {
            _ioEventHandler = new IOEventHandler(this, config["ComPort"]);
        }

        public event EventHandler<WriteEventArgs> WriteEvent;

        protected void OnBufferChanged(WriteEventArgs e) => WriteEvent?.Invoke(this, e);

    }
}
