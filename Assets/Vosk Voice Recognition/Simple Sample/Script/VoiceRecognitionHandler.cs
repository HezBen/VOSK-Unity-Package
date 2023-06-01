using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceRecognitionHandler : MonoBehaviour
{
    [SerializeField] private Text _textDisplay;
    [SerializeField] private VoskSpeechToText _speechToText;

    [SerializeField] private List<string> codePhraseList;
    [SerializeField] private List<string> failedGuessList;
    [TextArea(3, 6)]
    [SerializeField] private string hintPhrase;
    [TextArea(3, 6)]
    [SerializeField] private string rightGuess;

    bool isLissening = true;
    private void Awake()
    {
        _speechToText.OnTranscriptionResult += CheckTranscriptionResult;
    }

    private void Start()
    {        
        StartTyping(hintPhrase);        
    }

    private void CheckTranscriptionResult(string obj)
    {
        RecognitionResult result = new RecognitionResult(obj);
               
        if (result.Phrases[0].Text == "" || !isLissening) { return; }

        bool right = false;
        foreach (RecognizedPhrase r in result.Phrases)
        {
            if (codePhraseList.Contains(r.Text)) { right = true; }
        }
        
        if (right) {
            StartTyping(rightGuess);
            isLissening = false;
        }
        else { StartTyping("I am so sorry! I heard " + result.Phrases[0].Text + " \n" + failedGuessList[Random.Range(0, failedGuessList.Count)] + "\n\n" + hintPhrase  ); }

    }


    public float typingSpeed = 0.01f;
    private string targetString;

    public void StartTyping(string text)
    {
        targetString = text;
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        _textDisplay.text = "";
        foreach (char c in targetString)
        {
            _textDisplay.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

}


/* 
    The key phrases can not have a space at the end, and they must 
be lowercase. 

    Also, I recommend having a list of things that sound like what you 
are trying to hear, or variations on the way it is said, to improve recognition. 

*/
