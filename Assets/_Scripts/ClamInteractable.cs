using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using FMODUnity;

public class ClamInteractable : InteractiveController
{
    [SerializeField] private TimelineManager TimelineManager;
    private StudioEventEmitter emit;

    public PlayableAsset timelineEvent;

    //References to FMOD events
    [Header("FMOD Events")]
    [EventRef] public string sfx;

    private bool isPlaying;

    public override void Awake() {

        base.Awake();
        emit = gameObject.AddComponent<StudioEventEmitter>();
    }


    public override void InteractWithObject() {

        TimelineManager = GameObject.FindWithTag("Timeline").GetComponent<TimelineManager>();

        TimelineManager.ChangePlayable(timelineEvent);
        TimelineManager.PlayTimeline();

        StartCoroutine(BeginCall());
    }

    IEnumerator BeginCall() {

        if (!isInteracted) {

            //Start Coroutine and disable phone receiver object.
            RuntimeManager.PlayOneShot(sfx, transform.position);
            isInteracted = true;

            //set and play poem
            emit.Event = sfx;
            emit.Play();

            //yield until the emitter stops playing.
            yield return new WaitUntil(() => !emit.IsPlaying());

            //After we have waited x seconds set interacted to false.
            isInteracted = false;
        }
    }
}
