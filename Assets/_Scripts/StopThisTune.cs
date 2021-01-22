using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopThisTune : MonoBehaviour
{
   public AudioSource tune;

    private void OnEnable()
    {
        tune.Stop();
    }
}
