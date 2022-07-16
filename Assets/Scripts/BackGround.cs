using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    public AudioClip clipEndGame;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void SetMusic()
    {
        audioSource.Stop();
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(clipEndGame);
    }
    
}
