using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopNhat : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Hatmang1_andi;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DayMangDaTuot"))
        {
            Hatmang1_andi.transform.parent.gameObject.SetActive(false);
            foreach(Transform child in other.transform)
            {
                if (child.tag.Contains("Head"))
                {
                    child.gameObject.SetActive(true);
                    break;
                } 
            }
        }
    }
}
