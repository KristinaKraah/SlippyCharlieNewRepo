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

    public void PlayOneShotAudio(AudioSource audioSource, AudioClip audioClip, float delay = 0)
    {
        StartCoroutine(StartOneShotAudio(audioSource, audioClip, delay));
    }

    private IEnumerator StartOneShotAudio(AudioSource audioSource, AudioClip audioClip, float delay)
    {
        yield return new WaitForSeconds(delay);
        if(audioSource && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
        yield return null;
    }

}
