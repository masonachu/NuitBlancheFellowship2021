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

    }

    public void BeginShaking() {

        myShakeInstance = Shaker.ShakeAll(EarthquakeShake);
        myShakeInstance.Start(0f);
    }
    
    public void EndShaking() {

        myShakeInstance.Stop(1f, false);
    }
}
