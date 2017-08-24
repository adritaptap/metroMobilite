using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroMobiliteUI.Model
{

    public class StopModel : INotifyPropertyChanged
    {
        private string _name;
        private List<LineModel> _lines;

        public StopModel(string name)
        {
            this.Name = name;
            this.Lines = new List<LineModel>();
        }

        public string Name {
            get
            {
                return _name;
            }

            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public List<LineModel> Lines
        {
            get
            {
                return _lines;
            }

            set
            {
                if (_lines != value)
                {
                    _lines = value;
                    RaisePropertyChanged("Lines");
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
