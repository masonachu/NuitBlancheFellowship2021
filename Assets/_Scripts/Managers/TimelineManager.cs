using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;

    private void Start() {

        timeline = GameObject.FindWithTag("Timeline").GetComponent<PlayableDirector>();
    }

    public void ChangePlayable(PlayableAsset newTimelineAsset)
    {
        timeline.playableAsset = newTimelineAsset;

        //rebuild for runtime playing
        timeline.RebuildGraph();
        timeline.time = 0.0;
    }

    public void PlayTimeline()
    {
        timeline.Play();
    }
}
