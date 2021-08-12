using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    [SerializeField] private GameObject LoadingCanvas;
    [SerializeField] private GameObject MenuCanvas;
    [SerializeField] private GameObject OptionsMenu;
    [SerializeField] private GameObject ControlsMenu;

    private bool isLoaded = false;

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    private void Start() {

        MenuCanvas.SetActive(false);
        LoadingCanvas.SetActive(true);
    }

    private void Update() {
        
        if(FMODUnity.RuntimeManager.HasBankLoaded("Master") && !isLoaded) {

            isLoaded = true;
            MenuCanvas.SetActive(true); 
            LoadingCanvas.SetActive(false);

            Debug.Log("FMOD Loaded, Menu Canvas activated");
        }
    }


    public void StartGame() {

        if (FMODUnity.RuntimeManager.HasBankLoaded("Master")) {

            scenesToLoad.Add(SceneManager.LoadSceneAsync("Main"));
            //scenesToLoad.Add(SceneManager.LoadSceneAsync("MainScene_01", LoadSceneMode.Additive));
        }
    }

    public void QuitGame() {

            Application.Quit();
    }
}
