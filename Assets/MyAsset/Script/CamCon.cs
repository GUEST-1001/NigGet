using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

// This sets up the scene camera for the local player
public class CamCon : NetworkBehaviour
{
    Camera mainCam;

    void Awake()
    {
        mainCam = GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        if (!this.isLocalPlayer)
        {
            mainCam.gameObject.SetActive(false);

        }
    }
    private void Update()
    {

    }

    public override void OnStartLocalPlayer()
    {

    }

    public override void OnStopLocalPlayer()
    {
        if (mainCam != null)
        {
            mainCam.transform.SetParent(null);
            SceneManager.MoveGameObjectToScene(mainCam.gameObject, SceneManager.GetActiveScene());
            mainCam.orthographic = true;
            mainCam.orthographicSize = 15f;
            mainCam.transform.localPosition = new Vector3(0f, 70f, 0f);
            mainCam.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
        }
    }
}
