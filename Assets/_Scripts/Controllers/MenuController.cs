using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string gameVersion = "0.1";
    [SerializeField] private GameObject UsernameMenu;
    [SerializeField] private GameObject ConnectPanel;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject OptionsMenu;

    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    [SerializeField] private GameObject StartButton;



    private void Awake()
    {
        //PhotonNetwork.ConnectUsingSettings();
    }

    private void Start()
    {
        MainMenu.SetActive(true);
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

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
