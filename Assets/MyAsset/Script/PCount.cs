using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PCount : NetworkBehaviour
{
    public int nigget = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(nigget);
    }

    public void MinNigget()
    {
        nigget -= 1;
    }
}
