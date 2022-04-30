using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }
    
    private IEnumerator SpawnObstacleRoutine()
    {
        yield return new WaitForSeconds(startDelay);
        while (playerControllerScript.gameOver == false)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
            yield return new WaitForSeconds(repeatRate);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
