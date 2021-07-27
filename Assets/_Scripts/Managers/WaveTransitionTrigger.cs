using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using FMODUnity;


public class WaveTransitionTrigger : TimelineManager
{
    [SerializeField] private PlayableAsset waveTimelineAsset;

    public void TransitionToUnderwater() {

        timeline = GameObject.FindWithTag("Timeline").GetComponent<PlayableDirector>();

        ChangePlayable(waveTimelineAsset);
        PlayTimeline();
    }
}
