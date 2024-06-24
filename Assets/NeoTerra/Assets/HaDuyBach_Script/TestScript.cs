using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;


public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    public XRGrabInteractable xrGrap;
    public Rigidbody rb;
    public bool select;
    void Start()
    {
        xrGrap = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        xrGrap.throwOnDetach = true;
        xrGrap.throwVelocityScale = 0.5f;
        xrGrap.onHoverExited.AddListener(IsExting());
    }

    private UnityAction<XRBaseInteractor> IsExting()
    {
        xrGrap.throwVelocityScale = 5f;
        return (XRBaseInteractor interactor) =>
        {
            Debug.Log("Action được gọi với interactor: " + interactor.gameObject.GetComponent<Rigidbody>());
            // Thực hiện các hành động cần thiết tại đây
        };
    }
}
