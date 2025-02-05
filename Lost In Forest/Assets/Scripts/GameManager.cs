using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerController playerC;
    public int Score;
    public Text scoreText;
    public Transform startingPoint;
    public float lerpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
        Score = 0;
        playerC.GameOver = true;
        StartCoroutine(PlayIntro());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!playerC.GameOver)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                Score++;
                scoreText.text = "Score: " + Score.ToString("0");
                Destroy(collision.gameObject);
                PlayerPrefs.SetInt("Highest Score", Score);
            }
            Debug.Log("Score: " + Score);
        }
    }
    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerC.transform.position;
        Vector3 endPos = startingPoint.position;
        float Jlength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;
        float Dcovered = (Time.time - startTime) * lerpSpeed;
        float FractionOfJourney = Dcovered / Jlength;
        playerC.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);

        while(FractionOfJourney < 1)
        {
            Dcovered = (Time.time - startTime) * lerpSpeed;
            FractionOfJourney = Dcovered / Jlength;
            playerC.transform.position = Vector3.Lerp(startPos, endPos, FractionOfJourney);
            yield return null;
        }
        playerC.GetComponent<Animator>().SetFloat("Speed_Multiplier", 1.0f);
        playerC.GameOver = false;
    }
}
