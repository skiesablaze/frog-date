using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = menuMusic;
        audioSource.Play();
    }

    // ok actually not sure if i should have used a coroutine for this but here we are anyways
    public IEnumerator ChangeMusic(){
        audioSource.clip = gameMusic;
        audioSource.Play();
        yield return null;
    }
}
