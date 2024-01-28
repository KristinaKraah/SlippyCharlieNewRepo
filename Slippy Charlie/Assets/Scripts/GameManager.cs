using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;
public class GameManager : MonoBehaviour
{

    public GameObject startingPoint;
    public AudioSource gameMusic;
    private AudioManager audioManager;
    private AudioSource cameraAudioSrc;
    private PlayerController playerController;

    private List<AudioClip> laughTracks = new List<AudioClip>();
    private AudioClip laughTrack001;
    private AudioClip laughTrack002;
    private AudioClip laughTrack003;
    private AudioClip laughTrack004;
    private AudioClip laughTrack005;
    private AudioClip laughTrack006;
    private AudioClip laughTrack007;
    private AudioClip laughTrack008;
    private AudioClip laughTrack009;
    private AudioClip laughTrack010;
    private AudioClip laughTrack011;
    private AudioClip laughTrack012;
    private AudioClip laughTrack013;
    private AudioClip laughTrack014;
    private AudioClip laughTrack015;
    private AudioClip laughTrack016;

    private void Awake()
    {
        laughTrack001 = (AudioClip)Resources.Load("SFX/CrowdLaugh001");
        laughTrack002 = (AudioClip)Resources.Load("SFX/CrowdLaugh002");
        laughTrack003 = (AudioClip)Resources.Load("SFX/CrowdLaugh003");
        laughTrack004 = (AudioClip)Resources.Load("SFX/CrowdLaugh004");
        laughTrack005 = (AudioClip)Resources.Load("SFX/CrowdLaugh005");
        laughTrack006 = (AudioClip)Resources.Load("SFX/CrowdLaugh006");
        laughTrack007 = (AudioClip)Resources.Load("SFX/CrowdLaugh007");
        laughTrack008 = (AudioClip)Resources.Load("SFX/CrowdLaugh008");
        laughTrack009 = (AudioClip)Resources.Load("SFX/CrowdLaugh009");
        laughTrack010 = (AudioClip)Resources.Load("SFX/CrowdLaugh010");
        laughTrack011 = (AudioClip)Resources.Load("SFX/CrowdLaugh011");
        laughTrack012 = (AudioClip)Resources.Load("SFX/CrowdLaugh012");
        laughTrack013 = (AudioClip)Resources.Load("SFX/CrowdLaugh013");
        laughTrack014 = (AudioClip)Resources.Load("SFX/CrowdLaugh014");
        laughTrack015 = (AudioClip)Resources.Load("SFX/CrowdLaugh015");
        laughTrack016 = (AudioClip)Resources.Load("SFX/CrowdLaugh016");
    }

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        playerController = GameObject.FindObjectOfType<PlayerController>();
        cameraAudioSrc =Camera.main.GetComponent<AudioSource>();
        SetupLaughTrackList();
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

    public void OnDeath()
    {
        if(playerController != null)
        {
            
        }
        if(audioManager!= null)
        {
            audioManager.PlayOneShotAudio(cameraAudioSrc, laughTracks[Random.Range(0, laughTracks.Count - 1)], .5f);
        }
       

    }

    void Reset()
    {
        
    }


    void SetupLaughTrackList()
    {
        laughTracks.Add(laughTrack001);
        laughTracks.Add(laughTrack002);
        laughTracks.Add(laughTrack003);
        laughTracks.Add(laughTrack004);
        laughTracks.Add(laughTrack005);
        laughTracks.Add(laughTrack006);
        laughTracks.Add(laughTrack007);
        laughTracks.Add(laughTrack008);
        laughTracks.Add(laughTrack009);
        laughTracks.Add(laughTrack010);
        laughTracks.Add(laughTrack011);
        laughTracks.Add(laughTrack012);
        laughTracks.Add(laughTrack013);
        laughTracks.Add(laughTrack014);
        laughTracks.Add(laughTrack015);
        laughTracks.Add(laughTrack016);
    }


}
