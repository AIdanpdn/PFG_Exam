using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallController : MonoBehaviour
{
    Rigidbody body;
    Vector3 moveDir;
    [SerializeField] private bool turned = false;
    [SerializeField] private float speed;

    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    public bool dead;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!dead)
            {
                Debug.Log("Button Pressed");

                if (turned == false)
                {
                    TurnX();
                    return;
                }

                if (turned == true)
                {
                    TurnZ();
                    return;
                }
            }


        }

        if (!Physics.Raycast(gameObject.transform.position, new Vector3(0, -2, 0)))
        {
            Die();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            Collect();
            Destroy(other);
        }
    }

    void TurnX()
    {
        moveDir = new Vector3(speed, 0, 0f);
        body.velocity = moveDir;
        turned = true;
        Debug.Log(turned);
    }

    void TurnZ()
    {
        moveDir = new Vector3(0f, 0, speed);
        body.velocity = moveDir;
        turned = false;
        Debug.Log(turned);
    }


    void Die()
    {
        dead = true;
        body.useGravity = true;
        virtualCamera.Follow = null;
        virtualCamera.LookAt = null;
    }

    public void Collect()
    {
        score++;
        Debug.Log(score);
    }
}

