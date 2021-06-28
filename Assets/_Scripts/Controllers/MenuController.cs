using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class MenuController : MonoBehaviourPunCallbacks
{
    [SerializeField] private string gameVersion = "0.1";
    [SerializeField] private GameObject UsernameMenu;
    [SerializeField] private GameObject ConnectPanel;

    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    [SerializeField] private GameObject StartButton;



    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Start()
    {
        //UsernameMenu.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Connected");
    }

    public void ChangeUsernameInput()
    {
        if(UsernameInput.text.Length >= 3 && UsernameInput.text.Length != 0)
        {
            StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
        }
    }

    public void SetUserName()
    {
        UsernameMenu.SetActive(false);
        PhotonNetwork.NickName = UsernameInput.text;
    }

    public void CreateGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 16;
        PhotonNetwork.CreateRoom(CreateGameInput.text, roomOptions, TypedLobby.Default);
    }

    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 16;
        PhotonNetwork.JoinOrCreateRoom("12345", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("MainTest");
    }
}
