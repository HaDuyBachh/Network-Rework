using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chucmung : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject audioTextManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DayMangDaTuot") && InputDevicesManagement.Instance.IsTriggerPressed())
            {
                audioTextManager.GetComponent<AudioSource>().Stop();
                audioTextManager.GetComponent<AudioTextManager>().PlayAudioClipAtIndex(7);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
