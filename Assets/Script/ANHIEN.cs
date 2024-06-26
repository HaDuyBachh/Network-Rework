using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ANHIEN : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DayMangContainer;
    private GameObject TTSAU;
    private GameObject TTTRuoc;
    public GameObject audioTextManager;
    public GameObject hand;
    public CatVo KiemTraCatVo;

    public float pressThreshHoldDelta = 0f;
    public float pressThreshHoldTimeout = 0.9f;

    public void Start()
    {
        KiemTraCatVo = FindAnyObjectByType<CatVo>();
    }
    public void SetContainer(GameObject day)
    {
        DayMangContainer = day;
        TTTRuoc = DayMangContainer.transform.GetChild(0).gameObject;
        TTSAU = DayMangContainer.transform.GetChild(1).gameObject;
        TTTRuoc.SetActive(true);
        TTSAU.SetActive(false);
    }

    private void Update()
    {
        if (pressThreshHoldDelta > 0) pressThreshHoldDelta -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.O))
        {
            OnTriggerEnter(hand.transform.GetComponent<Collider>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && pressThreshHoldDelta <= 0f)
        {
            if (!TTSAU.activeSelf && KiemTraCatVo.datuot)
            {
                TTSAU.SetActive(true);
                TTTRuoc.SetActive(false);
                TTSAU.transform.position = TTTRuoc.transform.position;
                TTSAU.transform.rotation = TTTRuoc.transform.rotation;

                audioTextManager.GetComponent<AudioSource>().Stop();
                audioTextManager.GetComponent<AudioTextManager>().PlayAudioClipAtIndex(6);
                showText(1, 0);
                pressThreshHoldDelta = pressThreshHoldTimeout;
            }
            else
            if (TTSAU.activeSelf)
            {
                if (TTSAU.GetComponent<DayMangDaTachController>().isStateCableDone)
                {
                    StartCoroutine(showTextInTime(3, 1, pressThreshHoldTimeout));
                }    
                else
                {
                    StartCoroutine(showTextInTime(2, 1, pressThreshHoldTimeout));
                }
                pressThreshHoldDelta = pressThreshHoldTimeout;
            }    
        }
    }

    private void showText(int show,int hide)
    {
        transform.GetChild(0).GetChild(show).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(hide).gameObject.SetActive(false);

    }
    private IEnumerator showTextInTime(int show, int hide,float waitTime)
    {
        transform.GetChild(0).GetChild(show).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(hide).gameObject.SetActive(false);
        
        yield return new WaitForSeconds(waitTime);

        transform.GetChild(0).GetChild(show).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(hide).gameObject.SetActive(true);
    }    
}
