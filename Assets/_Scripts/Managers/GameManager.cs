using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;


public class GameManager : MonoBehaviour
{
    [Header("Debug Mode")]
    public bool DebugMode;

    [Header("References")]
    public GameObject PlayerPrefab;
    public GameObject GameCanvas;
    public TimelineManager TimelineManager;
<<<<<<< Updated upstream
=======

    [Header("Timeline")]
>>>>>>> Stashed changes
    [SerializeField] private PlayableAsset introTimeline;
    //public GameObject SceneCamera;

    private Transform PlayerLocation;

    [Header("Teleport Zones")]
    [SerializeField] private Transform StartLocation;
    [SerializeField] private Transform UnderwaterLocation;
    [SerializeField] private Transform SpaceLocation;

    
    private void Awake() {

        GameCanvas.SetActive(true);
        TeleportPlayer(StartLocation);

        TimelineManager.ChangePlayable(introTimeline);
        TimelineManager.PlayTimeline();
    }

    public void SpawnPlayer(Transform tf) {
        
        GameObject.Instantiate(PlayerPrefab, new Vector3
            (tf.transform.position.x, tf.transform.position.y,
             tf.transform.position.z), Quaternion.identity);
    }

    public void TeleportPlayer(Transform tf) {

        PlayerLocation = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerLocation.position = tf.position;
    }
}
