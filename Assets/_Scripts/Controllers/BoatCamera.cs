using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatCamera : MonoBehaviour 
{

    public bool controllerPauseState = false;

    #region Look Settings
    public bool enableCameraMovement = true;
    public enum InvertMouseInput { None, X, Y, Both }
    public InvertMouseInput mouseInputInversion = InvertMouseInput.None;
    public enum CameraInputMethod { Traditional, TraditionalWithConstraints, Retro }
    public CameraInputMethod cameraInputMethod = CameraInputMethod.Traditional;

    public float verticalRotationRange = 170;
    public float mouseSensitivity = 10;
    public float fOVToMouseSensitivity = 1;
    public float cameraSmoothing = 5f;
    public bool lockAndHideCursor = false;
    public Camera playerCamera;
    public bool enableCameraShake = false;
    internal Vector3 cameraStartingPosition;
    float baseCamFOV;


    public bool autoCrosshair = false;
    public bool drawStaminaMeter = true;
    float smoothRef;

    public Sprite Crosshair;
    public Vector3 targetAngles;
    private Vector3 followAngles;
    private Vector3 followVelocity;
    private Vector3 originalRotation;
    #endregion

    private void Awake() {

        playerCamera = GetComponentInChildren<Camera>();
    }

    private void Start() {

        #region Look Settings - Start

        if (autoCrosshair) {
            Canvas canvas = new GameObject("AutoCrosshair").AddComponent<Canvas>();
            canvas.gameObject.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.pixelPerfect = true;
            canvas.transform.SetParent(playerCamera.transform);
            canvas.transform.position = Vector3.zero;

            if (autoCrosshair) {
                Image crossHair = new GameObject("Crosshair").AddComponent<Image>();
                crossHair.sprite = Crosshair;
                crossHair.rectTransform.sizeDelta = new Vector2(25, 25);
                crossHair.transform.SetParent(canvas.transform);
                crossHair.transform.position = Vector3.zero;
            }
        }
        cameraStartingPosition = playerCamera.transform.localPosition;
        if (lockAndHideCursor) { Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false; }
        baseCamFOV = playerCamera.fieldOfView;
        #endregion
    }

    private void Update() {

        if (enableCameraMovement && !controllerPauseState) {
            float mouseYInput = 0;
            float mouseXInput = 0;
            float camFOV = playerCamera.fieldOfView;
            if (cameraInputMethod == CameraInputMethod.Traditional || cameraInputMethod == CameraInputMethod.TraditionalWithConstraints) {
                mouseYInput = mouseInputInversion == InvertMouseInput.None || mouseInputInversion == InvertMouseInput.X ? Input.GetAxis("Mouse Y") : -Input.GetAxis("Mouse Y");
                mouseXInput = mouseInputInversion == InvertMouseInput.None || mouseInputInversion == InvertMouseInput.Y ? Input.GetAxis("Mouse X") : -Input.GetAxis("Mouse X");
            }
            else {
                mouseXInput = Input.GetAxis("Horizontal") * (mouseInputInversion == InvertMouseInput.None || mouseInputInversion == InvertMouseInput.Y ? 1 : -1);
            }
            if (targetAngles.y > 180) { targetAngles.y -= 360; followAngles.y -= 360; } else if (targetAngles.y < -180) { targetAngles.y += 360; followAngles.y += 360; }
            if (targetAngles.x > 180) { targetAngles.x -= 360; followAngles.x -= 360; } else if (targetAngles.x < -180) { targetAngles.x += 360; followAngles.x += 360; }
            targetAngles.y += mouseXInput * (mouseSensitivity - ((baseCamFOV - camFOV) * fOVToMouseSensitivity) / 6f);
            if (cameraInputMethod == CameraInputMethod.Traditional) { targetAngles.x += mouseYInput * (mouseSensitivity - ((baseCamFOV - camFOV) * fOVToMouseSensitivity) / 6f); }
            else { targetAngles.x = 0f; }
            targetAngles.x = Mathf.Clamp(targetAngles.x, -0.5f * verticalRotationRange, 0.5f * verticalRotationRange);
            followAngles = Vector3.SmoothDamp(followAngles, targetAngles, ref followVelocity, (cameraSmoothing) / 100);

            playerCamera.transform.localRotation = Quaternion.Euler(-followAngles.x + originalRotation.x, 0, 0);
            transform.localRotation = Quaternion.Euler(0, followAngles.y + originalRotation.y, 0);
        }

        if (Input.GetButtonDown("Cancel")) { ControllerPause(); }

        if (Input.GetButtonDown("Fire1")) {
            if (controllerPauseState == true) {
                ControllerPause();
            }
        }
    }

    public void ControllerPause() {
        controllerPauseState = !controllerPauseState;
        if (lockAndHideCursor) {
            Cursor.lockState = controllerPauseState ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = controllerPauseState;
        }
    }
}

