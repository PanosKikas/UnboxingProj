using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    AudioSource audioSource;
 
    Rigidbody rb;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
       
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rb.velocity.magnitude > 2 && !audioSource.isPlaying)
        {
            audioSource.volume = Random.Range(0.5f, 0.8f);
            audioSource.pitch = Random.Range(0.8f, 1f);
            audioSource.Play();
        }
    }

    

}
