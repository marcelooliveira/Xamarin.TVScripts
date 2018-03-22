using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.TVScripts.Services
{
    public interface ITextToSpeech
    {
        void Speak(string text);
    }
}
