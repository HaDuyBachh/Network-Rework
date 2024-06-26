using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSelectLessonControl : MonoBehaviour
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
        //handInput.primaryPressEvent.AddListener(Clicked);
        handInput.activePressEvent.AddListener(Clicked);
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
            transform.GetChild(0).gameObject.SetActive(true);
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
            transform.GetChild(0).gameObject.SetActive(false);
            Debug.DrawLine(lineOrigin.position, lineOrigin.position + lineOrigin.forward.normalized * 100, Color.yellow, 100f);
            if (Physics.Raycast(new Ray(lineOrigin.position, lineOrigin.forward), out var hit))
            {
                this.hit = hit;
                if (hit.collider.gameObject.name.Contains("Thực hành cắt dây mạng Panel"))
                {
                    FindObjectOfType<SceneController>().SceneNetWorkCableScene();
                }
                if (hit.collider.gameObject.name.Contains("Thực hành Neo Terra"))
                {
                    FindObjectOfType<SceneController>().SceneGamePlay();
                }
                Debug.Log("Bắn trúng " + hit.collider.name + " rùi");
            }

            line.SetPosition(0, lineOrigin.position);
            line.SetPosition(1, lineOrigin.position);
            isOffLineCast = false;
            openLineCast = false;
        }
        else
        //Debug.DrawLine(lineOrigin.position, lineOrigin.position + lineOrigin.forward.normalized * 100, Color.red);
        if (openLineCast)
        {
            line.SetPosition(0, lineOrigin.position);
            line.SetPosition(1, lineOrigin.position + lineOrigin.forward.normalized * 100);
        }

    }
}
