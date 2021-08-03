using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.Playables;

public class BottleInteractable : InteractiveController
{
    public TimelineManager TimelineManager;
    public PlayableAsset UnderwaterTransition;

    [SerializeField] private GameObject cork;
    private Animator islandAnimator;
    
    private StudioEventEmitter emit;

    //References to FMOD events
    [Header("FMOD Events")]
    [EventRef] public string bottleOpen;
    [EventRef] public string poem;

    private bool isPlaying;

    public override void Awake() {

        base.Awake();
        emit = gameObject.AddComponent<StudioEventEmitter>();
    }


    public override void InteractWithObject() {

        cork.SetActive(false);
        RuntimeManager.PlayOneShot(bottleOpen, transform.position);
        TimelineManager = GameObject.FindWithTag("Timeline").GetComponent<TimelineManager>();
        TriggerTimelineEvent();
    }

    public void TriggerTimelineEvent() {

        TimelineManager.ChangePlayable(UnderwaterTransition);
        TimelineManager.PlayTimeline();
    }

    IEnumerator BeginCall() {

        if (!isInteracted) {

            //Start Coroutine and disable phone receiver object.
            cork.SetActive(false);
            RuntimeManager.PlayOneShot(bottleOpen, transform.position);
            isInteracted = true;

            //set and play poem
            emit.Event = poem;
            emit.Play();

            //yield until the emitter stops playing.
            yield return new WaitUntil(() => !emit.IsPlaying());
            islandAnimator.SetBool("isSinking", true);

            //After we have waited x seconds set interacted to false.
            isInteracted = false;
        }
    }
}
