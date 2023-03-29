using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.SceneManagement;

public class HPCon : NetworkBehaviour
{
    static public HPCon insten;

    [SyncVar]
    public int MyHP = 5;
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
        Debug.Log("call hit from server");
        HPDown();
    }

    [ClientRpc]
    void HPDown()
    {
        Debug.Log("Get hit");
        MyHP -= 1;
        HpTextHead.text = MyHP.ToString();
        if (MyHP <= 0)
        {
            CmdGoToDead();
            SendDead();
        }
    }

    [Command]
    void CmdGoToDead()
    {
        GoToDead();
    }
    [TargetRpc]
    void GoToDead()
    {
        roof = GameObject.FindWithTag("roof");
        Debug.Log(roof);
        roof.SetActive(false);
        gameObject.transform.position = new Vector3(110f, 100f, 50f);
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
    void SendDead()
    {
        var count = FindObjectOfType<CustomNetwork>();
        count.MinNigget();
    }

    // IEnumerator HpDownWait()
    // {
    //     HpWait = false;
    //     yield return new WaitForSeconds(0.2f);
    //     HpWait = true;
    // }
}
