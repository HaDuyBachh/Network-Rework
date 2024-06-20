using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject audioTextManager;
    public GameObject objectToShow;
    public int fromIndex;
    public int toIndex;
    // Update is called once per frame
    void Update()
    {
        if (audioTextManager.GetComponent<AudioTextManager>().currentIndex >= fromIndex && audioTextManager.GetComponent<AudioTextManager>().currentIndex <= toIndex )
        {
            objectToShow.SetActive(true);
        } else 
        {
            objectToShow.SetActive(false);
        } 
    }
}
