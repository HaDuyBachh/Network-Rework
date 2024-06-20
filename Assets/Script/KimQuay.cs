using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KimQuay : MonoBehaviour
{
    // Start is called before the first frame update
    public int HuongQuay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InputDevicesManagement.Instance.IsTriggerPressed())
        {
            float DoQuay = HuongQuay*10*InputDevicesManagement.Instance.GetTriggerValue();
            transform.localEulerAngles = new Vector3(0, 0, DoQuay);
        }
    }
}
