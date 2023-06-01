    This is from an example project provided by the team at Vosk, modified and packaged by a 3rd party. Please visit the Vosk website for more information. 
https://alphacephei.com/vosk/

**IMPORTANT**
You MUST move the StreamingAssets folder to the Assets folder 
 
	
I needed voice recognition for a project of mine, but I didn’t want to use cortana or spend money, so VOSK was the answer. I couldn’t find much information on using VOSK in Unity, all I could find is a few examples that VOSK has on their sites. I put together this package to help. 

Import this package, move the StreamingAssets file directly to “Assets,” and make sure the DLLs in ThirdParty/Vosk are set up for your platform. This package comes with an example project, including a really buggy typewriter display. The focus is voice recognition, let's ignore the buggy typewriter for now. 

For your own project drag the VoskVoiceRecognition prefab into your scene.
You will also need your own VoiceRecognitionHandler script. Your VoiceRecognitionHandler will need a VoskSpeechToText variable, assign the prefab in your scene to that variable. 

Make a CheckTranscriptionResult method that takes a string, 

in awake do 
[Your VoskSpeechToText variable].OnTranscriptionResult += CheckTranscriptionResult;

OnTranscriptionResult can handle more than one method if you want it to. 

In the CheckTranscriptionResult, convert the string to RecognitionResult, and then check each phrase of that result in a forloop. In that forloop is where your code will go, compare it to your key phrase or word however you want, I prefer checking a list of strings if it contains “r.Text” and running a prefab, altho in this example project I just set a bool to true if it matches. 

Check out the Vosk Website for more models and projects 
