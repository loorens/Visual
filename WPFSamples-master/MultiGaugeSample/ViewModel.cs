﻿using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace MultiGaugeSample
{
    public class ViewModel : INotifyPropertyChanged
    {
        private double _value;
        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                NotifyPropertyChange("Value");
            }
        }

        private int _speed = 25;
        public int Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                NotifyPropertyChange("Speed");
                Timer.Change(0, value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private System.Threading.Timer Timer;

        public ViewModel()
        {
            Timer = new Timer(x => Timer_Tick(), null, 0, Speed);
        }

        private void Timer_Tick()
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(NewValue));
        }

        private static Random Rnd = new Random();
        private void NewValue()
        {
            Value = Value + (Rnd.Next(20) - 10);
        }
    }
}