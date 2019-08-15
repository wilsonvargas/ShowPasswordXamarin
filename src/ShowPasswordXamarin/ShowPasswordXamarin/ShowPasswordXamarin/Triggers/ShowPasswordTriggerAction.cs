using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Xamarin.Forms;

namespace ShowPasswordXamarin.Triggers
{
    public class ShowPasswordTriggerAction : TriggerAction<Button>
    {
        public string IconImageName { get; set; }

        public string EntryPasswordName { get; set; }

        protected override void Invoke(Button sender)
        {
            Image imageIconView = ((Grid)sender.Parent).FindByName<Image>(IconImageName);
            Entry entryPasswordView = ((Grid)((Grid)sender.Parent).Parent).FindByName<Entry>(EntryPasswordName);
            string imageFile = string.Empty;

            if (entryPasswordView.IsPassword)
            {
                imageFile = (Device.RuntimePlatform == Device.UWP) ? "Assets/hideicon.png" : "hideicon.png";               
            }
            else
            {
                imageFile = (Device.RuntimePlatform == Device.UWP) ? "Assets/showicon.png" : "showicon.png";
            }
            imageIconView.Source = ImageSource.FromFile(imageFile);
            entryPasswordView.IsPassword = !entryPasswordView.IsPassword;
            entryPasswordView.CursorPosition = (entryPasswordView.Text != null) ? entryPasswordView.Text.Length : 0;            
        }
    }
}
