using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MetroMobiliteUI.Model
{
    public class LineModel : INotifyPropertyChanged
    {
        private string shortName;
        private string longName;
        private string color;
        private string textColor;
        private string mode;
        private string type;

        public string ShortName
        {
            get
            {
                return shortName;
            }
            set
            {
                if (shortName != value)
                {
                    shortName = value;
                    RaisePropertyChanged("ShortName");
                }
            }
        }
        public string LongName
        {
            get
            {
                return longName;
            }
            set
            {
                if (longName != value)
                {
                    longName = value;
                    RaisePropertyChanged("LongName");
                }
            }
        }
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                if (color != value)
                {
                    color = "#" + value;
                    RaisePropertyChanged("Color");
                }
            }
        }
        public string TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                if (textColor != value)
                {
                    textColor = "#" + value;
                    RaisePropertyChanged("TextColor");
                }
            }
        }
        public string Mode
        {
            get
            {
                return mode;
            }
            set
            {
                if (mode != value)
                {
                    mode = value;
                    RaisePropertyChanged("Mode");
                }
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (type != value)
                {
                    type = value;
                    RaisePropertyChanged("Type");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}

