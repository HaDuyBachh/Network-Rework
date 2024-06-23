using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCableStopButtonControl : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            FindObjectOfType<SceneController>().SceneFirstPlace();
        }    
    }
}
