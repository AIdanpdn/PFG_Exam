using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    Rigidbody body;
    private bool fallen = false;

    private float timer;
    private float waitTime = 15f;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (fallen == false)
        {
            if(timer > waitTime)
            {
                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        body.useGravity = true;
        fallen = false;
    }
}