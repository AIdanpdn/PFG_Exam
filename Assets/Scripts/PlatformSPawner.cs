using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSPawner : MonoBehaviour
{

    [SerializeField] private GameObject platform;
    [SerializeField] private BallController ball;
    [SerializeField] private GameObject collectible;

    int platformNumber;
    Vector3 randomVector;
    Vector3 numberVector;

    float timer;
    float waitTime = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++) 
        {
            SpawnPlatform();
        }            

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            timer = timer - waitTime;
            SpawnPlatform();
        }

    }   

    private void SpawnPlatform()
    {
        if (ball.dead == false)
        {
            GameObject newPlatform = Instantiate(platform);
            numberVector = new Vector3(platformNumber, 0, platformNumber);
            randomVector = new Vector3(Random.Range(0f, 2f), 0, Random.Range(0f, 2f));

            newPlatform.transform.position = gameObject.transform.position + randomVector + numberVector;
            platformNumber++;

            int collectibleSpawn = Random.Range(0, 10);

            if(collectibleSpawn > 8)
            {
                GameObject newCollectible = Instantiate(collectible);
                newCollectible.transform.position = newPlatform.transform.position + new Vector3(0, 1f, 0);
                
            }
        }
    }
}
