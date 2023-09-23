# Godot 4 Speech Recognition with VOSK
 This is an example of using the VOSK open source speech recognition library in Godot.
 see https://github.com/alphacep/vosk-api (Apache 2.0 license) .
 SpeechRecognizer.cs contains the logic to talk to VOSK to perform voice recognition.
 Press the start recognition button and talk to get the text back.
 The recognition is done in an async task periodically to not interfere with the game logic.
 
 Tested this successfully in Windows 11 and Steamdeck (Linux) with no issues. 


## Steps to re-create this in your project

 - Add this to your project's .csproj file
 ```
 <ItemGroup>
    <PackageReference Include="Vosk" Version="0.3.38" />
  </ItemGroup>
  ``` 
 - You can copy over the SpeechRecognizer.cs script to your project.
 - You will need a model folder from https://alphacephei.com/vosk/models
 - Add a audio bus with a Record effect and add a AudioStreamPlayer node
 (follow https://docs.godotengine.org/en/stable/tutorials/audio/recording_with_microphone.html)
 - SpeechRecognizer should contain two signals you can attach to - one for partial result and one for final result
 - Exporting this project requires additional steps for now 
  - The model folder has to be manually copied over. If the folder is in a .pck, it won't work
  - The native library for OSX and linux have to be manually copied over to the export data folder(data_ folder).
 
 
## Common Issues and Fixes
 1. Model folder is not exported and will not work if exported in a .pck.
	
	Model folder needs to be copied to the exported build folder. The vosk lib needs the file externally. 
	I might add code to automatically export the model folder from .pck/.zip to the directory when the game launches.
	This is likely the only solution to make this work in android.
	
 2. Native Library for certain OS (libvosk.dylib, libvosk.so) don't seem to be properly imported from nuget
   
    These have to copied manually to the lib folder (this can be found in the data_<your project> folder. These can be grabbed from nuget and are also availabe in the vosklibs
	folder in this repo.

 
