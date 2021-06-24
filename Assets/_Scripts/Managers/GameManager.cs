using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public GameObject PlayerPrefab;
    public GameObject GameCanvas;
    public GameObject SceneCamera;
    
    private Transform PlayerLocation;

    [Header("Teleport Zones")]
    [SerializeField] private Transform UnderwaterLocation;
    [SerializeField] private Transform SpaceLocation;

    [Header("Debug Mode")]
    [SerializeField] private bool DebugMode;
    
    private void Awake()
    {
        GameCanvas.SetActive(true);
    }

    private void Update()
    {
        if(DebugMode)
        {
            if(Input.GetKeyDown("q"))
            {
                TeleportPlayer(SpaceLocation);
            }
        }
    }

    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-1f, 1f);
        
        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3
            (this.transform.position.x * randomValue, this.transform.position.y,
             this.transform.position.z), Quaternion.identity, 0);

        GameCanvas.SetActive(false);
        SceneCamera.SetActive(false);
    }

    public void TeleportPlayer(Transform tf)
    {
            PlayerLocation = GameObject.FindGameObjectWithTag("Player").transform;
            PlayerLocation.position = tf.position;
    }
}
