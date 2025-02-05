using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ObstaclePrefab;
    private Vector3 spawnPos = new Vector3(1.43f, -3.333f, -0.5f);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController PCscript;
    // Start is called before the first frame update
    void Start()
    {
        PCscript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("Spawn", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn()
    {
        int obsIndex = Random.Range(0,ObstaclePrefab.Length);
        if (PCscript.GameOver == false)
        {
            Instantiate(ObstaclePrefab[obsIndex], spawnPos, ObstaclePrefab[obsIndex].transform.rotation);
        }
    }
}
