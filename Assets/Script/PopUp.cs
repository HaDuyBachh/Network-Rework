using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public bool isPopUp = false;
    private Vector3 Des;
    private bool isPopping = false;
    private Vector3 Origin;

    public void Awake()
    {
        Origin = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("va vao " + other.gameObject.name);
        if (other.gameObject.CompareTag("Hand") && !isPopUp)
        {
            isPopUp = true;
            SetPopUp(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hand") && isPopUp)
        {
            isPopUp = false;
            SetPopUp(false);
        }
    }

    public void SetPopUp(bool state)
    {
        if (state) 
            Des =Origin - 0.2f * transform.up;
        else
            Des = Origin;
        isPopping = true;
    }

    private void Update()
    {
        if (isPopping)
        {
            transform.position = Vector3.Lerp(transform.position, Des, 2f * Time.deltaTime);
            if ((transform.position - Des).magnitude <= 0.01f)
            {
                isPopping = false;
                transform.position = Des;
            }
        }    
    }
}
