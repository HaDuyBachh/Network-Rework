using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    public Transform StandPlace;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent!=null && other.transform.parent.CompareTag("trash"))
        {
            Destroy(other.gameObject, 0.1f);
        }   
        else
        if (other.transform.CompareTag("player"))
        {
            other.transform.position = StandPlace.position;
        }    
    }
}
