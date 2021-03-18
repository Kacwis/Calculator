using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calulator
{
    public class MainResult : INotifyPropertyChanged
    {
        public double result;
        public bool IfInserting = true;
        public bool IfAfterComma = false;

        public string MainResultString
        {
            get
            {
                return result.ToString();
            }
        } 

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public static int returningCorrectMultiplier(string value)
        {
            if(value == "0")
            {
                return 1;
            }
            return (int)Math.Pow(10, (value.Length));
        }
    }

    public class MainResultViewModel
    {
        private MainResult main = new MainResult();
        public MainResult resultModel
        {
            get
            {
                return this.main;
            }
        }     
    }
}
