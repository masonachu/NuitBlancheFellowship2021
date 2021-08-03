using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;

public class CameraShaker : MonoBehaviour
{

    public Shaker PlayerShaker;
    public ShakePreset EarthquakeShake;
    private ShakeInstance myShakeInstance;

    private void Start() {

        myShakeInstance = Shaker.ShakeAll(EarthquakeShake);
        myShakeInstance.Stop(1f, false);
    }

    public void BeginShaking() {

        myShakeInstance.Start(0f);
    }
    
    public void EndShaking() {

        myShakeInstance.Stop(1f, false);
    }
}
