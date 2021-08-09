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
        PlayerShaker.enabled = false;
    }

    public void BeginShaking() {

        PlayerShaker.enabled = true;
        myShakeInstance.Start(0f);
    }
    
    public void EndShaking() {

        myShakeInstance.Stop(1f, false);
        StartCoroutine(WaitForSeconds(1f));
        PlayerShaker.enabled = false;
    }

    IEnumerator WaitForSeconds(float time) {

        yield return new WaitForSeconds(time);
    }
}
