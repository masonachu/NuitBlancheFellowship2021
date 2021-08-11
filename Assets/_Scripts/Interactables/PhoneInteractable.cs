using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using FMODUnity;

public class PhoneInteractable : InteractiveController {

    [SerializeField] private GameObject phoneReceiver;
    [SerializeField] private SimpleButtonActivate portalActivator;
    [SerializeField] private TimelineManager TimelineManager;

    //References to FMOD events
    [Header("FMOD Events")]
    [EventRef] public string phonePickup;
    [EventRef] public string phonePutdown;
    [EventRef] public string poem;

    [Header("References")]
    public StudioEventEmitter music;
    public StudioEventEmitter phoneRing;
    public PlayableAsset timelineEvent;
    private StudioEventEmitter emit;

    public override void Awake() {

        base.Awake();
        emit = GetComponent<StudioEventEmitter>();
    }

    public override void InteractWithObject() {

        portalActivator = GameObject.FindWithTag("Portal").GetComponent<SimpleButtonActivate>();
        music = GameObject.FindWithTag("Music").GetComponent<StudioEventEmitter>();
        TimelineManager = GameObject.FindWithTag("Timeline").GetComponent<TimelineManager>();

        TimelineManager.ChangePlayable(timelineEvent);
        TimelineManager.PlayTimeline();

        StartCoroutine(BeginCall());
    }

    IEnumerator BeginCall() {

        if (!isInteracted) {

            //Start Coroutine and disable phone receiver object.
            phoneReceiver.SetActive(false);
            RuntimeManager.PlayOneShot(phonePickup, transform.position);
            music.SetParameter("TrackSelection", 3f);
            isInteracted = true;

            //Deactivate phone ringing
            phoneRing.Stop();

            //Activate the portal
            portalActivator.ActivatePortal();

            //set and play poem
            emit.Stop();
            emit.Event = poem;
            emit.Play();

            //yield until the emitter stops playing.
            yield return new WaitUntil(() => !emit.IsPlaying());

            //After we audio is finished, put phone receiver back.
            phoneReceiver.SetActive(true);
            RuntimeManager.PlayOneShot(phonePutdown, transform.position);
            isInteracted = false;
        }
    }
}
