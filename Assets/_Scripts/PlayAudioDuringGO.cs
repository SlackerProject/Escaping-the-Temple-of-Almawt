using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioDuringGO : MonoBehaviour
{
    public AudioSource Audio;
    public GameObject Scene;

     
    public void OnEnable()
    {
        
        Audio.Play();
          
    }

    public void OnDisable()
    {
        Audio.Stop();
    }

}
