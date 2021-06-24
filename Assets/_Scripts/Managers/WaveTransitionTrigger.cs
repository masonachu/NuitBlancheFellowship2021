using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class WaveTransitionTrigger : TimelineManager
{
    [SerializeField] private PlayableAsset waveTimelineAsset;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ChangePlayable(waveTimelineAsset);
            PlayTimeline();
        }
    }
}
