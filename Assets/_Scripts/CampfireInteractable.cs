using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using FMODUnity;

public class CampfireInteractable : InteractiveController {

    public TimelineManager TimelineManager;
    public PlayableAsset EndingTransition;

    private StudioEventEmitter emit;
    public GameObject flame;

    //References to FMOD events
    [Header("FMOD Events")]
    [EventRef] public string poem;

    private bool isPlaying;

    public override void Awake() {

        base.Awake();
        emit = gameObject.AddComponent<StudioEventEmitter>();
    }


    public override void InteractWithObject() {

        TimelineManager = GameObject.FindWithTag("Timeline").GetComponent<TimelineManager>();
        //emit.Play();
        TriggerTimelineEvent();
    }

    public override void Update() {
        base.Update();
        flame.transform.LookAt(Camera.main.transform.position, Vector3.up);
    }

    public void TriggerTimelineEvent() {

        TimelineManager.ChangePlayable(EndingTransition);
        TimelineManager.PlayTimeline();
    }

    IEnumerator BeginCall() {

        if (!isInteracted) {

            //Start Coroutine and disable phone receiver object.
            isInteracted = true;

            //set and play poem
            emit.Event = poem;
            emit.Play();

            //yield until the emitter stops playing.
            yield return new WaitUntil(() => !emit.IsPlaying());

            //After we have waited x seconds set interacted to false.
            isInteracted = false;
        }
    }
}
