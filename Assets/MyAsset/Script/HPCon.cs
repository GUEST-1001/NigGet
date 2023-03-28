using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class HPCon : NetworkBehaviour
{

    [SyncVar]
    public int MyHP = 5;
    public TextMesh HpTextHead;
    public bool HpWait;
    public TMP_Text HpTextUI;

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
            this.HpTextUI.text = MyHP.ToString();
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

    // IEnumerator HpDownWait()
    // {
    //     HpWait = false;
    //     yield return new WaitForSeconds(0.2f);
    //     HpWait = true;
    // }
}
