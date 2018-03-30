using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Views;
using Android.Widget;
using Xamarin.TVScripts.Droid;
using Xamarin.TVScripts.Services;

[assembly: Xamarin.Forms.DependencyAttribute(typeof(Xamarin.TVScripts.Droid.TextToSpeech))]
namespace Xamarin.TVScripts.Droid
{
    public class TextToSpeech : Java.Lang.Object, ITextToSpeech, global::Android.Speech.Tts.TextToSpeech.IOnInitListener
    {
        global::Android.Speech.Tts.TextToSpeech speaker;
        string toSpeak;

        public void Speak(string text)
        {
            toSpeak = text;
            if (speaker == null)
            {
                speaker = new global::Android.Speech.Tts.TextToSpeech(Application.Context, this);
            }
            else
            {
                speaker.Speak(toSpeak, QueueMode.Add, null, null);
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                speaker.Speak(toSpeak, QueueMode.Add, null, null);
            }
        }
    }
}