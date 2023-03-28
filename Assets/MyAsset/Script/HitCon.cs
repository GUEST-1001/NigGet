using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class HitCon : NetworkBehaviour
{
    public float moveSpeed = 0f, lifeTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroy(gameObject);
    }
}
