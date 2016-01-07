using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Data;
using Turismo.Objects;

namespace Turismo.Library
{
    class ErrorHandler
    {
        public static async void HandleError(string ErrorCode)
        {
            var dialog = new Windows.UI.Popups.MessageDialog("");

            switch (ErrorCode)
            {
                case "010":
                    if (AppGlobal.Instance._CurrentSession.CurrentLanguage == Language.NL)
                    {
                        dialog.Content = "Er zijn geen GPS sensoren gevonden. Deze kunnen mogelijk uitgeschakeld zijn.";
                    }
                    else if (AppGlobal.Instance._CurrentSession.CurrentLanguage == Language.EN)
                    {
                        dialog.Content = "There are no GPS sensors found. These might be turned off.";
                    }
                    break;
                case "011":
                    if (AppGlobal.Instance._CurrentSession.CurrentLanguage == Language.NL)
                    {
                        dialog.Content = "Deze App heeft geen toegang tot u locatie!";
                    }
                    else if (AppGlobal.Instance._CurrentSession.CurrentLanguage == Language.EN)
                    {
                        dialog.Content = "This Application has no access to your location!";
                    }
                    break;
                case "100":
                    if (AppGlobal.Instance._CurrentSession.CurrentLanguage == Language.NL)
                    {
                        dialog.Content = "De GPS connectie is zeer slecht"; 
                    }
                    else if (AppGlobal.Instance._CurrentSession.CurrentLanguage == Language.EN)
                    {
                        dialog.Content = "Bad GPS Connection!";
                    }
                    dialog.Commands.Add(new Windows.UI.Popups.UICommand("Oke") { Id = 0 });
                    await dialog.ShowAsync();                    
                    break;

            }
        }
    }
}
