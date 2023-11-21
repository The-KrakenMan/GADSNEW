using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource fireSound;
    // Start is called before the first frame update


    void OnTriggerEnter(Collider other)
    {
        fireSound.Play();
    }

    void OnTriggerExit(Collider other)
    {
        fireSound.Stop();
    }
}
