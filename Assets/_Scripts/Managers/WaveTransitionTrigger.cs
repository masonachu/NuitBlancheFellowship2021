using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using FMODUnity;


public class WaveTransitionTrigger : TimelineManager
{
    [SerializeField] private PlayableAsset waveTimelineAsset;

    public void TransitionToUnderwater() {

        ChangePlayable(waveTimelineAsset);
        PlayTimeline();
    }
}
