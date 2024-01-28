using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject startingPoint;
    public AudioSource gameMusic;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        if (audioManager != null)
        {
            if(gameMusic != null)
            {
                audioManager.PlayAudio(gameMusic);
            }
            
        }
    }

    void OnDeath()
    {

    }

    void Reset()
    {
        
    }

}
