using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource BGM;
    // Start is called before the first frame update
    private void Start()
    {
        BGM = GetComponent<AudioSource>();
    }
    public void startNew()
    {
        SceneManager.LoadScene(1);
    }

}
