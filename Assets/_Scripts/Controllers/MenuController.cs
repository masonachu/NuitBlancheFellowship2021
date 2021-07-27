using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject MenuCanvas;
    [SerializeField] private GameObject OptionsMenu;
    [SerializeField] private GameObject ControlsMenu;

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();


    private void Start() {
        MenuCanvas.SetActive(true);
    }


    public void StartGame() {
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Main"));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Scene_01", LoadSceneMode.Additive));
    }
}
