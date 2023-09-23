using Godot;
using System;

public partial class SpeechUIManager : Node
{
    [Export] Button startButton;
    [Export] Label partialResultText;
    [Export] Label finalResultText;
    [Export] SpeechRecognizer speechRecognizer;

    private string partialResult;
    private string finalResult;

    public override void _Ready()
    {
        startButton.Pressed += () =>
        {
            if (!speechRecognizer.isCurrentlyListening())
            {
                partialResultText.Text = "";
                finalResultText.Text = "";
                OnStartSpeechRecognition();
                speechRecognizer.StartSpeechRecognition();
            }
            else
            {
                OnStopSpeechRecognition();
                finalResult = speechRecognizer.StopSpeechRecoginition();
            }
        };
        speechRecognizer.OnPartialResult += (partialResult) =>
        {
            partialResultText.Text = partialResult;
        };
        speechRecognizer.OnFinalResult += (finalResult) =>
        {
            finalResultText.Text = finalResult;
            OnStopSpeechRecognition();
        };
    }

    public override void _Process(double delta)
    {
    }

    private void OnStopSpeechRecognition()
    {
        startButton.Text = "Start Recognition";
        startButton.Modulate = new Color(1, 1, 1, 1f);
    }


    private void OnStartSpeechRecognition()
    {
        startButton.Text = "Stop Recognition";
        startButton.Modulate = new Color(1f, 0.5f, 0.5f, 1f);
    }
}
