using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float Repeatx;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Repeatx = GetComponent<BoxCollider>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - Repeatx)
        {
            transform.position = startPos;
        }
        
    }
}
