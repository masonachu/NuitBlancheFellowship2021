using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;

    [SerializeField] private GameObject GameCanvas;
    [SerializeField] private GameObject SceneCamera;
    [SerializeField] private Transform PlayerLocation;
    [SerializeField] private Transform UnderwaterLocation;

    private void Awake()
    {
        //GameCanvas.SetActive(true);
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-1f, 1f);
        
        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3
            (this.transform.position.x * randomValue, this.transform.position.y,
             this.transform.position.z), Quaternion.identity, 0);

        //GameCanvas.SetActive(false);
        //SceneCamera.SetActive(false);
    }

    public void TeleportPlayer(Transform tf)
    {
            PlayerLocation = GameObject.FindGameObjectWithTag("Player").transform;
            PlayerLocation.position = tf.position;
    }    
}
