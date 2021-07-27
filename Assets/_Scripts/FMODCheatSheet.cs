using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//if ever confused, reference the FMOD Unity API
//https://www.fmod.com/resources/documentation-unity?version=2.02&page=welcome.html

//1. add the FMODUnity namespace
using FMODUnity;

public class FMODCheatSheet : MonoBehaviour
{
    //2. Reference the FMOD Studio Event Emitter and event, which is a string
    [EventRef] public string audioEvent;
    public StudioEventEmitter audioEmit;
    //3. Set reference inside of component for audio event and emitter inside of Unity Inspector

    //4. create a void class to use to activate a sound or directly reference sound

    public void PlayEvent() {

        //Play event as is, but keeps it in memory
        audioEmit.Play();

        //Play event and release it from memory 
        RuntimeManager.PlayOneShot(audioEvent);
    }
}
