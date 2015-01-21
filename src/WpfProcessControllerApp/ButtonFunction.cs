using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WpfProcessControllerApp
{
    [DataContract]
    public class ButtonFunction : INotifyPropertyChanged
    {
        [DataMember]
        public bool StartNewInstanceIfAlreadyRunning
        {
            get { return startNewInstanceIfAlreadyRunning; }
            set
            {
                if (startNewInstanceIfAlreadyRunning != value)
                {
                    startNewInstanceIfAlreadyRunning = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool startNewInstanceIfAlreadyRunning;

        [DataMember]
        public int KeyID
        {
            get { return keyid; }
            set
            {
                if(keyid != value)
                {
                    keyid = value;
                    OnPropertyChanged();
                }
            }
        }
        private int keyid;

        [DataMember]
        public string ProgramName
        {
            get { return programName; }
            set
            {
                if(programName != value)
                {
                    programName = value;
                    OnPropertyChanged();
                }
            }
        }
        private string programName;

        [DataMember]
        public string ProgramArguments
        {
            get { return programArguments; }
            set
            {
                if(programArguments != value)
                {
                    programArguments = value;
                    OnPropertyChanged();
                }
            }
        }
        private string programArguments;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
