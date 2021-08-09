using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.Playables;

public class LanternInteractable : InteractiveController {

    public TimelineManager TimelineManager;
    public PlayableAsset SurfacingSequence;

    private StudioEventEmitter emit;

    [Header("FMOD Events")]
    [EventRef] public string sfx;


    public override void Awake() {

        base.Awake();
        emit = gameObject.AddComponent<StudioEventEmitter>();
    }

    public override void InteractWithObject() {

        RuntimeManager.PlayOneShot(sfx, transform.position);
        TriggerTimelineEvent();
    }

    public void TriggerTimelineEvent() {

        TimelineManager.ChangePlayable(SurfacingSequence);
        TimelineManager.PlayTimeline();
    }


    IEnumerator BeginPoem() {

        if (!isInteracted) {

            //Start Coroutine.
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
