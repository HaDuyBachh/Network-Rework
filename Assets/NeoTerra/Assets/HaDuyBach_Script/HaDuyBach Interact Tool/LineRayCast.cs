using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRayCast : MonoBehaviour
{
    public LineRenderer line;
    public Transform lineOrigin;
    public HandInputValue handInput;
    public bool openLineCast = false;
    public bool isOffLineCast = false;
    public RaycastHit hit;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        handInput.primaryPressEvent.AddListener(Clicked); 
    }
    public RaycastHit getHit()
    {
        return hit;
    }    
    void Clicked()
    {
        if (!openLineCast)
        {
            openLineCast = true;
            isOffLineCast = false;
        }
        else
        {
            isOffLineCast = true;
        }    
    }    
    // Update is called once per frame
    void Update()
    {
        if (isOffLineCast)
        {
            Debug.DrawLine(lineOrigin.position, lineOrigin.position + lineOrigin.forward.normalized * 100, Color.yellow, 100f);
            if (Physics.Raycast(new Ray(lineOrigin.position, lineOrigin.forward), out var hit))
            {
                this.hit = hit;
                if (hit.transform.TryGetComponent<RayCastActiveObjectController>(out var _active))
                {
                    _active.RayCastActive();
                }    
            }

            line.SetPosition(0, lineOrigin.position);
            line.SetPosition(1, lineOrigin.position);
            isOffLineCast = false;
            openLineCast = false;
        }    
        
        Debug.DrawLine(lineOrigin.position, lineOrigin.position + lineOrigin.forward.normalized * 100, Color.red);
        if (openLineCast)
        {
            line.SetPosition(0, lineOrigin.position);
            line.SetPosition(1, lineOrigin.position + lineOrigin.forward.normalized*100);
        }
       
    }
}
