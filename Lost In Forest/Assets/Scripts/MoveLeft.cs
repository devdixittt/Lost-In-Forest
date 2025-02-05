using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 5f;
    private PlayerController PlayerControllerScript;
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
       PlayerControllerScript
         = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControllerScript.GameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.LeftShift) && PlayerControllerScript.GameOver == false)
        {
            transform.Translate(Vector3.left * (speed * 2) * Time.deltaTime);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
