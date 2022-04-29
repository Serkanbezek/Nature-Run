using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
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
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            yield return new WaitForSeconds(repeatRate);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
