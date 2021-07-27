using UnityEngine;
using UnityEngine.Rendering;

public class MainCamera : MonoBehaviour {

    GameObject player;
    Portal[] portals;

    void Awake () {
        portals = FindObjectsOfType<Portal> ();
        player = GameObject.FindWithTag("Player");

        if(player != null) {

            RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
        }
        else {

            Debug.Log("Player not found - try resetting?");
        }
    }

    void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera) {

        for (int i = 0; i < portals.Length; i++) {
            portals[i].PrePortalRender ();
        }
        for (int i = 0; i < portals.Length; i++) {
            portals[i].Render (context);
        }

        for (int i = 0; i < portals.Length; i++) {
            portals[i].PostPortalRender ();
        }
    }

    void OnDestroy() {
        RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
    }
}