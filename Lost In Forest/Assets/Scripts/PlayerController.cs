using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRb;
    public float jumpForce = 10.0f;
    public float GravityModifier;
    public bool isOnGround = true;
    public bool GameOver = false;
    private Animator playerA;
    private AudioSource PlayerAudio;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        playerA = GetComponent<Animator>();
        PlayerAudio = GetComponent<AudioSource>();
        Physics.gravity *= GravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameOver)
        {
            PlayerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;
        }

        



    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            
            
        }
        else if(collision.gameObject.CompareTag("Obstacle")){
            GameOver = true;
            Debug.Log("Game Over");
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
