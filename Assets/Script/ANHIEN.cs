using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANHIEN : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DayMangContainer;
    private GameObject TTSAU;
    private GameObject TTTRuoc;
    public GameObject audioTextManager;
    public GameObject hand;
    public CatVo KiemTraCatVo;

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
        if (Input.GetKeyDown(KeyCode.O))
        {
            OnTriggerEnter(hand.transform.GetComponent<Collider>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && !TTSAU.activeSelf && KiemTraCatVo.datuot)
        {
            TTSAU.SetActive(true);
            TTTRuoc.SetActive(false);
            TTSAU.transform.position = TTTRuoc.transform.position;
            TTSAU.transform.rotation = TTTRuoc.transform.rotation;
            audioTextManager.GetComponent<AudioSource>().Stop();
            audioTextManager.GetComponent<AudioTextManager>().PlayAudioClipAtIndex(6);
        }
    }
}
