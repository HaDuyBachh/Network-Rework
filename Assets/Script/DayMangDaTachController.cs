using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayMangDaTachController : MonoBehaviour
{
    private void OnEnable()
    {
        var daythaydoi = transform.GetChild(2);
        for (int i = 0; i<daythaydoi.childCount; i++)
        {
            var day = daythaydoi.GetChild(i);
            day.GetChild(0).GetComponent<DayMangController>()._type = (DayMangController.Type)i;
            day.GetChild(1).GetComponent<DayMangController>()._type = (DayMangController.Type)i;
        }
    }
}
