using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.SceneManagement;

public class HPConP2 : NetworkBehaviour
{
    static public HPCon insten;

    [SyncVar]
    public int MyHP = 10;
    public TextMesh HpTextHead;
    public bool HpWait;
    public TMP_Text HpTextUI;
    public GameObject roof;

    void Awake()
    {
        HpTextHead.text = MyHP.ToString();
        HpWait = true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CmdHPUp();
        UpdateCount();
        if (this.isLocalPlayer)
        {
            // var cHit = GetComponent<ClickHitP2>();
            // Debug.Log(cHit);
            this.HpTextUI.text = "HP " + MyHP.ToString();
        }
    }

    [Command]
    public void CmdHPDown()
    {
        HPDown();
    }

    [ClientRpc]
    void HPDown()
    {
        MyHP -= 1;
        HpTextHead.text = MyHP.ToString();
        if (MyHP < 1)
        {
            GoToDead();
            SendDead();
        }
    }

    [Command]
    void CmdHPUp()
    {
        HpUp();
    }

    [ClientRpc]
    void HpUp()
    {
        HpTextHead.text = MyHP.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hit"))
        {
            CmdHPDown();
        }
    }

    [Command]
    void CmdGoToDead()
    {
        GoToDead();
    }
    void GoToDead()
    {
        roof = GameObject.FindWithTag("roof");
        Debug.Log(roof);
        roof.SetActive(false);
        gameObject.transform.position = new Vector3(110f, 100f, 50f);
    }

    [Command]
    void SendDead()
    {
        var count = FindObjectOfType<CustomNetwork>();
        count.MinKaTi();
    }

    [Command]
    void UpdateCount()
    {
        var count = FindObjectOfType<CustomNetwork>();
        if (count.SendKaTi() < 1)
        {
            CmdNigetWin();
        }
        if (count.SendNigget() < 1)
        {
            CmdKaTiWin();
        }
    }

    [Command]
    public void CmdNigetWin()
    {
        NigetWin();
    }

    [ClientRpc]
    public void NigetWin()
    {
        SceneManager.LoadScene("WinNigget");
        NetworkManager.singleton.StopClient();
        NetworkManager.singleton.StopServer();
        Cursor.lockState = CursorLockMode.None;
        Destroy(gameObject);
    }

    [Command]
    public void CmdKaTiWin()
    {
        KaTiWin();
    }

    [ClientRpc]
    public void KaTiWin()
    {
        SceneManager.LoadScene("WinKati");
        NetworkManager.singleton.StopClient();
        NetworkManager.singleton.StopServer();
        Cursor.lockState = CursorLockMode.None;
        Destroy(gameObject);
    }

    // IEnumerator HpDownWait()
    // {
    //     HpWait = false;
    //     yield return new WaitForSeconds(0.2f);
    //     HpWait = true;
    // }
}
