using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatVo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CatHan;
    public bool dacat = false;
    public bool datuot = false;
    public GameObject audioTextManager;
    public GameObject example;

    // Update is called once per frame
    public float timeSinceLastTriggerStay = 0f;
    private float delayBetweenTriggerStay = 0.5f;
    void Update()
    {
        if (!dacat && CatHan.GetComponent<CatHan>().done != dacat)
        {
            timeSinceLastTriggerStay = -2f;
            dacat = CatHan.GetComponent<CatHan>().done;
        }
        
        timeSinceLastTriggerStay += Time.deltaTime;

        ///Phần này chỉ để test
        if (Input.GetKeyDown(KeyCode.I) && dacat)
        {
            Debug.Log("DDang chay o day");
            OnTriggerStay(example.GetComponent<Collider>());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (timeSinceLastTriggerStay >= delayBetweenTriggerStay)
        {
            if (other.CompareTag("DayMang") && dacat)
            {
                if (true)
                if (InputDevicesManagement.Instance.IsTriggerPressed())
                {
                    GameObject dayMang = other.gameObject;
                    Transform coverTransform = dayMang.transform.Find("Cover");
                    if (coverTransform != null)
                    {
                        GameObject cover = coverTransform.gameObject;
                        Vector3 localScale = cover.transform.localScale;
                        localScale.y *= 0.95f;
                        cover.transform.localScale = localScale;
                        audioTextManager.GetComponent<AudioSource>().Stop();
                        audioTextManager.GetComponent<AudioTextManager>().PlayAudioClipAtIndex(5);
                        Debug.Log("Đã chạy đến đây");
                        datuot = true;
                    }
                }
            }
            timeSinceLastTriggerStay = 0f;
        }
    }
    
}
