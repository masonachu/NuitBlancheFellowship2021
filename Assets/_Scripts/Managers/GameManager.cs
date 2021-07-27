using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;


public class GameManager : MonoBehaviour
{
    [Header("References")]
    public GameObject PlayerPrefab;
    public GameObject GameCanvas;
    public TimelineManager TimelineManager;

    public bool DebugMode;

    [SerializeField] private PlayableAsset introTimeline;
    //public GameObject SceneCamera;

    private Transform PlayerLocation;

    [Header("Teleport Zones")]
    [SerializeField] private Transform StartLocation;
    [SerializeField] private Transform WaterLocation;
    [SerializeField] private Transform IslandLocation;
    [SerializeField] private Transform UnderwaterLocation;
    [SerializeField] private Transform SpaceLocation;

    
    private void Awake() {

        if (!DebugMode) {

            GameCanvas.SetActive(true);
            TeleportPlayer(StartLocation);

            TimelineManager.ChangePlayable(introTimeline);
            TimelineManager.PlayTimeline();
        }
    }

    public void SpawnPlayer(Transform tf) {

        GameObject.Instantiate(PlayerPrefab, new Vector3
            (tf.transform.position.x, tf.transform.position.y,
             tf.transform.position.z), Quaternion.identity);
    }

    public void TeleportPlayer(Transform tf) {

        PlayerLocation = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerLocation.SetPositionAndRotation(tf.position, tf.rotation);
    }

    private void Update() {

        if (DebugMode) {

            DebugTeleport();
        }
    }

    public void DebugTeleport() {

        if (Input.GetKeyDown(KeyCode.Keypad1)) {
            TeleportPlayer(StartLocation);
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad2)) {
            TeleportPlayer(WaterLocation);
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad3)) {
            TeleportPlayer(IslandLocation);
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad4)) {
            TeleportPlayer(UnderwaterLocation);
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad4)) {
            TeleportPlayer(SpaceLocation);
        }
    }
}
