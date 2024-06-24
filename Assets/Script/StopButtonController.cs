using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButtonController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            FindObjectOfType<SceneController>().SceneFirstPlace();
        }
    }
}
