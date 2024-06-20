using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public float timeSinceLastTriggerStay = 0f;
    private float delayBetweenTriggerStay = 2f;
    public bool done = false;
    public GameObject audioTextManager;
    public GameObject example;
    private void Update()
    {
        timeSinceLastTriggerStay += Time.deltaTime;

        ///Phần này chỉ để test
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("DDang chay o day");
            OnTriggerStay(example.GetComponent<Collider>());
        }
    }
    

    private GameObject ViTriThemDayMang;
    private GameObject DayGoc;
    private void OnTriggerStay(Collider other)
    {
        if (timeSinceLastTriggerStay >= delayBetweenTriggerStay)
        {
            if (other.CompareTag("DayMang"))
            {
                if (true)
                if (InputDevicesManagement.Instance.IsTriggerPressed())
                {
                    DayGoc = other.gameObject;
                    var localScale = DayGoc.transform.localScale;
                    localScale = new Vector3(localScale.x, localScale.y * 0.9f, localScale.z);
                    DayGoc.transform.localScale = localScale;
            
                    GameObject DayNhoHon = Instantiate(DayGoc);
                    DayNhoHon.transform.localScale = 
                        new Vector3(DayNhoHon.transform.localScale.x, DayGoc.transform.localScale.y * 0.1f, DayNhoHon.transform.localScale.z);
                    
                    foreach (Transform ch in DayGoc.transform)
                    {
                        if (ch.tag.Contains("ViTriCatDayMang"))
                        {
                            ViTriThemDayMang = ch.gameObject;
                            break;
                        }    
                    }
                    DayNhoHon.transform.position = ViTriThemDayMang.transform.position;
                    DayNhoHon.transform.rotation = ViTriThemDayMang.transform.rotation;
                    DayNhoHon.GetComponent<Rigidbody>().useGravity = true;
                    DayNhoHon.GetComponent<Rigidbody>().isKinematic = false;
                    Debug.Log("Object: " + DayNhoHon.name + " useGravity = " + DayNhoHon.GetComponent<Rigidbody>().useGravity);
                    if (audioTextManager.GetComponent<AudioSource>().isPlaying)
                    {
                        audioTextManager.GetComponent<AudioSource>().Stop();
                    }
                        
                    audioTextManager.GetComponent<AudioTextManager>().PlayAudioClipAtIndex(4);
                    done = true;
                    Debug.Log("Đã hoàn thành");
                }
            }

            timeSinceLastTriggerStay = 0;
        }
        
    }
}
