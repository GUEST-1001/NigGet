using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.SceneManagement;

public class ConnectHUD : MonoBehaviour
{
    NetworkManager manager;
    public TMP_InputField ip_InputField;
    public GameObject HostConnect_go;

    void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HostFunction()
    {
        manager.networkAddress = ip_InputField.text;
        manager.StartHost();
    }
    public void ConnectFunction()
    {
        manager.networkAddress = ip_InputField.text;
        manager.StartClient();
    }
    
        public void GoTitle()
    {
        SceneManager.LoadScene(0);
    }
}
