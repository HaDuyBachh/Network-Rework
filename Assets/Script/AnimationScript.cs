using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LeftHand;
    public GameObject RightHand;

    private float rotationAngle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if(InputDevicesManagement.Instance.GetTriggerValue() > 0.0f){
            rotationAngle = 10*InputDevicesManagement.Instance.GetTriggerValue();
            LeftHand.transform.localEulerAngles = new Vector3(0, 0, -rotationAngle);
            RightHand.transform.localEulerAngles = new Vector3(0, 0, rotationAngle);
        } else {
            LeftHand.transform.localEulerAngles = new Vector3(0, 0, 0); 
            RightHand.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
}
