using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relaydingtian.ViewModel
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler LoadEventHandler = (sender, e) => { };
        protected void LoadEvent(string name)
        {
            if (LoadEventHandler != null)
            {
                LoadEventHandler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
