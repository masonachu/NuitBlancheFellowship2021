using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using FMODUnity;


public class WaveTransitionTrigger : TimelineManager
{
    [SerializeField] private PlayableAsset waveTimelineAsset;
    [SerializeField] private StudioEventEmitter waveAudio;

    private void Awake()
    {
        waveAudio = GetComponent<StudioEventEmitter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ChangePlayable(waveTimelineAsset);
            PlayTimeline();
        }
    }

    public void PlayWaveAudio()
    {
        waveAudio.Play();
    }
}
