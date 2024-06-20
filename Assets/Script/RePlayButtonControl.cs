using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePlayButtonControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DayMang;
    public GameObject Pliers;
    public AudioTextManager audioControl;
    public GameObject ButtonNext;
    public GameObject hatMang;
    public GameObject hatMangFirstLocate;
    public float threshhold = 1.0f;
    public float theshhold_delta = 0;
    public GameObject dayBefore = null;

    private void ThemDayMangMoi()
    {

        if (dayBefore != null && !dayBefore.transform.GetChild(1).transform.GetChild(0).gameObject.activeSelf)
        {
            Destroy(dayBefore);
        }
     
        var day = Instantiate(DayMang);

        dayBefore = day;
        day.SetActive(true);

        Pliers.GetComponentInChildren<CatHan>().done = false;
        Pliers.GetComponentInChildren<CatHan>().example = day.transform.GetChild(0).gameObject;
        Pliers.GetComponentInChildren<CatVo>().datuot = false;
        Pliers.GetComponentInChildren<CatVo>().dacat = false;
        Pliers.GetComponentInChildren<CatVo>().example = day.transform.GetChild(0).gameObject;
        hatMang.SetActive(true);
        hatMang.transform.position = hatMangFirstLocate.transform.position;
        ButtonNext.GetComponent<ANHIEN>().SetContainer(day);
    }
    void Awake()
    {
        ThemDayMangMoi();
    }
    private void Start()
    {
        audioControl.PlayAudioClipAtIndex(0);
    }
    private void Update()
    {
        if (theshhold_delta > 0) theshhold_delta -= Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (theshhold_delta <=0 && other.tag.Contains("Hand")) // && InputDevicesManagement.Instance.IsTriggerPressed())
        {
            ThemDayMangMoi();
            audioControl.PlayAudioClipAtIndex(3);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Contains("Hand")) // && InputDevicesManagement.Instance.IsTriggerPressed())
        {
            theshhold_delta = threshhold;
        }
    }
}
