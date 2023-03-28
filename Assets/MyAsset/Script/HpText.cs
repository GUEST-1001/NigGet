using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HpText : MonoBehaviour
{
    static public HpText instan;
    public TMP_Text HpTextUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHP(int HpUp)
    {
        this.HpTextUI.text = HpUp.ToString();
    }
}
