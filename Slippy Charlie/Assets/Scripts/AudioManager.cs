using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void PlayAudio(AudioSource audioSource, ulong delay = 0)
    {
        //audioToPlay.Play(delay);
        audioSource.Play(delay);
    }

    public void PlayOneShotAudio(AudioSource audioSource, AudioClip audioClip)
    {
        //audioToPlay.Play(delay);
        audioSource.PlayOneShot(audioClip);
    }

}
