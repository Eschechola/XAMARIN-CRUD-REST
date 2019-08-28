using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinRest.VoiceReader
{
    public class VoiceReader
    {
        public async void Falar(string texto)
        {
            await TextToSpeech.SpeakAsync(texto.ToLower());
        }
    }
}
