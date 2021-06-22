using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTransitionTrigger : TimelineManager
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayTimeline();
        }
    }
}
