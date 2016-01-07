using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turismo.Data.Objects
{
    public class MultipleLanguageString : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyname)
        {
            var eventhandler = PropertyChanged;

            if (eventhandler != null)
            {
                //System.Diagnostics.Debug.WriteLine($"Property is verandert: {propertyname}");
                eventhandler(this, new PropertyChangedEventArgs(propertyname));
            }
        }


        private string NL_String;
        private string EN_String;

        //public string Text { get { return GetText(); } }
        private string _text;

        public string Text
        {
            get { return _text; }
            private set { _text = value; OnPropertyChanged(nameof(Text)); }
        }

        public MultipleLanguageString(string nl_string, string en_string)
        {
            NL_String = nl_string;
            EN_String = en_string;
            SetText();
            CurrentSession.LanguageChanged += CurrentSession_LanguageChanged;
        }

        private void CurrentSession_LanguageChanged(object sender, EventArgs e)
        {
            SetText();
        }

        public void SetText()
        {
            switch (AppGlobal.Instance._CurrentSession.CurrentLanguage)
            {
                case Turismo.Objects.Language.NL:
                    Text = NL_String;
                    break;
                case Turismo.Objects.Language.EN:
                    Text = EN_String;
                    break;
                default:
                    Text = "<---Error--->";
                    break;
            }
        }
    }
}
