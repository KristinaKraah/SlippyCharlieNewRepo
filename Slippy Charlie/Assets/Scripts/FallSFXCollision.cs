using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollision : MonoBehaviour
{
    /*Triggers the fall sfx when the attached gameobject colliders with the ground*/

    private AudioManager audioManager;
    private GameManager gameManager;
    public AudioSource cameraAudioSrc;
    private List<AudioClip> fallSounds = new List<AudioClip>();
    private AudioClip fallsfx001;
    private AudioClip fallsfx002;
    private AudioClip fallsfx003;
    private AudioClip fallsfx004;
    private AudioClip fallsfx005;

    private bool alreadyPlayed = false;

    private void Awake()
    {
        fallsfx001 = (AudioClip)Resources.Load("SFX/FallSFX001");
        fallsfx002 = (AudioClip)Resources.Load("SFX/FallSFX002");
        fallsfx003 = (AudioClip)Resources.Load("SFX/FallsFX003");
        fallsfx004 = (AudioClip)Resources.Load("SFX/FallsFX004");
        fallsfx005 = (AudioClip)Resources.Load("SFX/FallsFX005");
    }
    // Start is called before the first frame update
    void Start()
    {
        //playerController = GameObject.FindObjectOfType<PlayerController>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        cameraAudioSrc = Camera.main.GetComponent<AudioSource>();
        SetupFallSoundsList();
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter (Collision collision)
    {
    if(!alreadyPlayed)
        { 
            if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                audioManager.PlayOneShotAudio(cameraAudioSrc, fallSounds[Random.Range(0, fallSounds.Count - 1)]);
                alreadyPlayed = true;
            }
        }

    }

    private void SetupFallSoundsList()
    {
        fallSounds.Add(fallsfx001);
        fallSounds.Add(fallsfx002);
        fallSounds.Add(fallsfx003);
        fallSounds.Add(fallsfx004);
        fallSounds.Add(fallsfx005);
    }
}
