using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayMangController : MonoBehaviour
{
    public enum Type
    {
        Orange_White,
        Organe,
        Green_White,
        Green,
        Blue_White,
        Blue,
        Brown_White,
        Brown,
        None,
    }

    public GameObject colorPart;
    public GameObject colorPart1;
    public GameObject noColorPart;
    public GameObject noColorPart1;
    public Material[] _material = new Material[5];
    public Type _type = Type.None;

    public void UpdateType(Type type)
    {
        _type = type;
        if (type == Type.None)
        {
            noColorPart.GetComponent<Renderer>().material = _material[0];
            noColorPart1.GetComponent<Renderer>().material = _material[0];
            colorPart.GetComponent<Renderer>().material = _material[0];
            colorPart1.GetComponent<Renderer>().material = _material[0];
            return;
        }    
        else
        if ((int)_type % 2 == 0)
        {
            noColorPart.GetComponent<Renderer>().material = _material[0];
            noColorPart1.GetComponent<Renderer>().material = _material[0];
        }
        else
        {
            noColorPart.GetComponent<Renderer>().material = _material[(int)_type / 2 + 1];
            noColorPart1.GetComponent<Renderer>().material = _material[(int)_type / 2 + 1];
        }
        
        colorPart.GetComponent<Renderer>().material = _material[(int)_type / 2 + 1];
        colorPart1.GetComponent<Renderer>().material = _material[(int)_type / 2 + 1];
    }

    public void Start()
    {
        if (_type != Type.None)
        {
            UpdateType(_type);
        }
    }
}
