using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    GameObject EndScreen;
    [SerializeField]
    GameObject player;
    

    public void WinGame()
    {
        
        player.GetComponent<FirstPersonMovement>().enabled = false;
        player.GetComponent<AudioSource>().enabled = false;
        EndScreen.SetActive(true);
       

    }
}
