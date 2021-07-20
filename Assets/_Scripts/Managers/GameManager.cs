using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public GameObject PlayerPrefab;
    public GameObject GameCanvas;
    //public GameObject SceneCamera;
    
    private Transform PlayerLocation;

    [Header("Teleport Zones")]
    [SerializeField] private Transform SpawnLocation;
    [SerializeField] private Transform UnderwaterLocation;
    [SerializeField] private Transform SpaceLocation;

    
    private void Awake() {

        GameCanvas.SetActive(true);
        //SpawnPlayer(SpawnLocation);
    }

    public void SpawnPlayer(Transform tf) {
        //float randomValue = Random.Range(-1f, 1f);
        
        GameObject.Instantiate(PlayerPrefab, new Vector3
            (tf.transform.position.x, tf.transform.position.y,
             tf.transform.position.z), Quaternion.identity);

        //GameCanvas.SetActive(false);
        //SceneCamera.SetActive(false);
    }

    public void TeleportPlayer(Transform tf) {

        PlayerLocation = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerLocation.position = tf.position;
    }
}
