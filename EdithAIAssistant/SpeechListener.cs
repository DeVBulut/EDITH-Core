using System;
using System.Globalization;
using System.Speech.Recognition;

namespace EdithAIAssistant
{
    public sealed class SpeechListener
    {
        private readonly SpeechRecognitionEngine _recognitionEngine;

        public SpeechListener()
        {
            // Use the default recognizer for the current culture
            var culture = CultureInfo.CurrentCulture;
            _recognitionEngine = new SpeechRecognitionEngine(culture);

            _recognitionEngine.SpeechRecognized += OnSpeechRecognized;
            _recognitionEngine.SetInputToDefaultAudioDevice();

            // Load dictation grammar for free-form speech
            var dictation = new DictationGrammar();
            _recognitionEngine.LoadGrammar(dictation);
        }

        public void Start()
        {
            try
            {
                _recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Speech recognition start failed: {ex.Message}");
            }
        }

        public void Stop()
        {
            try
            {
                _recognitionEngine.RecognizeAsyncStop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Speech recognition stop failed: {ex.Message}");
            }
        }

        private static void OnSpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result == null)
                return;

            if (e.Result.Confidence >= 0.6)
            {
                Console.WriteLine(e.Result.Text);
            }
        }
    }
}


