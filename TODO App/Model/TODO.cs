using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;

namespace TODO_App.Model
{
    class TODO : INotifyPropertyChanged
    {
        [JsonProperty(PropertyName = "creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        private bool isDone;
        private string text;

        public event PropertyChangedEventHandler PropertyChanged;

        protected  void OnPropertyChanged (string propertyName = "")
        {
            PropertyChanged ? .Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [JsonProperty(PropertyName = "isDone")]
        public bool IsDone
        {
            get { return isDone; }
            set {
                if (isDone == value) return;
                isDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        [JsonProperty(PropertyName = "text")]
        public string Text
        {
            get { return text; }
            set {
                if (text == value) return;
                text = value;
                OnPropertyChanged("Text");
            }
        }
    }
}
