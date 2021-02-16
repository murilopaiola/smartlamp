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

        public SLBuffer Buffer = new SLBuffer();

        #region Properties
        public string Net
        { 
            get
            {
                return Convert.ToString(Buffer.Net);
            }
            set
            {
                if (string.IsNullOrEmpty(value) || int.Parse(value) > 255) return;
                Buffer.Net = value.GetByteFromString();
                OnPropertyChanged(nameof(Buffer));
                OnBufferChanged(new WriteEventArgs(Buffer));
            }
        }

        public string Group
        {
            get
            {
                return Convert.ToString(Buffer.Group);
            }
            set
            {
                if (string.IsNullOrEmpty(value) || int.Parse(value) > 255) return;
                Buffer.Group = value.GetByteFromString();
                OnPropertyChanged(nameof(Buffer));
                OnBufferChanged(new WriteEventArgs(Buffer));
            }
        }

        public string Id
        {
            get
            {
                // this has to be reverted
                var bytes = new byte[2] { Buffer.Idl, Buffer.Idh };
                return Convert.ToString(BitConverter.ToUInt16(bytes));
            }
            set
            {
                if (string.IsNullOrEmpty(value) || int.Parse(value) > 65535) return;
                var val = value.GetBytesFromString();
                Buffer.Idh = val[0];
                Buffer.Idl = val[1];
                OnPropertyChanged(nameof(Buffer));
                OnBufferChanged(new WriteEventArgs(Buffer));
            }
        }

        public string Endi
        {
            get
            {
                var bytes = new byte[2] { Buffer.Endil, Buffer.Endih };
                return Convert.ToString(BitConverter.ToUInt16(bytes));
            }
            set
            {
                if (string.IsNullOrEmpty(value) || int.Parse(value) > 65535) return;
                var val = value.GetBytesFromString();
                Buffer.Endih = val[0];
                Buffer.Endil = val[1];
            }
        }

        public string Endf
        {
            get
            {
                var bytes = new byte[2] { Buffer.Endfl, Buffer.Endfh };
                return Convert.ToString(BitConverter.ToUInt16(bytes));
            }
            set
            {
                if (string.IsNullOrEmpty(value) || int.Parse(value) > 65535) return;
                var val = value.GetBytesFromString();
                Buffer.Endfh = val[0];
                Buffer.Endfl = val[1];
                OnPropertyChanged(nameof(Buffer));
                OnBufferChanged(new WriteEventArgs(Buffer));
            }
        }

        public string Param
        {
            get
            {
                return Convert.ToString(Buffer.Param);
            }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                Buffer.Param = value.GetByteFromString();
                OnPropertyChanged(nameof(Param));
                OnPropertyChanged(nameof(Buffer));
                OnBufferChanged(new WriteEventArgs(Buffer));
            }
        }

        public string Funcao
        {
            get
            {
                return Convert.ToString(Buffer.Funcao);
            }
            set
            {
                Buffer.Funcao = value.GetByteFromString();
                OnPropertyChanged(nameof(Funcao));
                OnPropertyChanged(nameof(Buffer));
                OnBufferChanged(new WriteEventArgs(Buffer));
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

                var sorted = split.OrderBy(x => int.Parse(x)).ToArray();

                if (split.Length == 2 && value.Contains('-'))
                {
                    Endi = sorted[0];
                    Endf = sorted[1];
                }

                IdRange = sorted;
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
