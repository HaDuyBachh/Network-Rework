using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class DayMangDaTachController : MonoBehaviour
{
    public bool isSelect;
    public bool isSwapCableMode = false;
    public bool dayTachRa = true;
    public Transform daythaydoi;
    public Transform tempCable;
    public Transform daydangxet = null;
    public HandInputValue handInput = null;

    public int selectedCableId = -1;
    public int currentCableId = -1;
    public bool isStateCableDone = false;

    private float pressTimeout = 0f;

    private void OnEnable()
    {
        daythaydoi = transform.GetChild(2);
        for (int i = 0; i < daythaydoi.childCount; i++)
        {
            var day = daythaydoi.GetChild(i);
            day.GetChild(0).GetComponent<DayMangController>().UpdateType((DayMangController.Type)i);
            day.GetChild(1).GetComponent<DayMangController>().UpdateType((DayMangController.Type)i);
        }

        TachDay();
    }
    private void Update()
    {
        //joystick

        if (pressTimeout > 0) pressTimeout -= Time.deltaTime;
        else
        {
            if (Input.GetKeyDown(KeyCode.M) || (handInput != null && handInput.turnValue.x > 0.1f))
            {
                TurnRightCable();
                pressTimeout = 0.2f;
            }
            if (Input.GetKeyDown(KeyCode.N) || (handInput != null && handInput.turnValue.x < -0.1f))
            {
                TurnLeftCable();
                pressTimeout = 0.2f;
            }
        }


        //nút A
        if (Input.GetKeyDown(KeyCode.B)) SetSwapCable();
        //Nút B
        if (Input.GetKeyDown(KeyCode.H)) SetSwapCableMode();

        if (isSwapCableMode)
        {
            tempCable.position = daydangxet.position + daydangxet.forward * 0.03f;
            tempCable.rotation = daydangxet.rotation;
        }
    }

    private void SetSwapCableMode()
    {
        Debug.Log("Đã bấm nút này");
        if (!isSwapCableMode) OnSwapCableMode();
        else OffSwapCableMode();
    }
    private void SetSwapCable()
    {
        if (!isSwapCableMode) return;

        if (selectedCableId == -1) SetSelectedCableId();
        else
            SwapCable();
    }

    public void CheckStateCable()
    {
        if (GetType(7) == DayMangController.Type.Orange_White &&
            GetType(6) == DayMangController.Type.Organe &&
            GetType(5) == DayMangController.Type.Green_White &&
            GetType(4) == DayMangController.Type.Blue &&
            GetType(3) == DayMangController.Type.Blue_White &&
            GetType(2) == DayMangController.Type.Green &&
            GetType(1) == DayMangController.Type.Brown_White &&
            GetType(0) == DayMangController.Type.Brown)
        {
            isStateCableDone = true;
        }
        else
            isStateCableDone = false;
    }
    public void TachDay()
    {
        var daythaydoi = transform.GetChild(2);
        for (int i = 0; i < daythaydoi.childCount; i++)
        {
            var day = daythaydoi.GetChild(i);
            if (i < 3)
            {
                day.position += (dayTachRa ? 1 : -1) * (3 - i) * -0.002f * Vector3.left;
            }
            if (i > 4)
            {
                day.position -= (dayTachRa ? 1 : -1) * (i - 4) * -0.002f * Vector3.left;
            }
        }
        dayTachRa = !dayTachRa;
    }
    public void SetSelect(bool state)
    {
        isSelect = state;
        if (isSelect == true)
        {
            var hand = GetComponent<XRGrabInteractable>().firstInteractorSelecting.transform;
            handInput = hand.GetComponent<HandInputValue>();
            handInput.primaryPressEvent.AddListener(SetSwapCable);
            handInput.secondaryPressEvent.AddListener(SetSwapCableMode);
        }
        else
        {
            var hand = GetComponent<XRGrabInteractable>().firstInteractorSelecting.transform;
            handInput.primaryPressEvent.RemoveListener(SetSwapCable);
            handInput.secondaryPressEvent.RemoveListener(SetSwapCableMode);
            if (isSwapCableMode) OffSwapCableMode();
        }
    }
    public void ResetTempCable()
    {
        tempCable.GetComponent<DayMangController>().UpdateType(DayMangController.Type.None);
    }
    public void NewTempCable()
    {
        daydangxet = daythaydoi.GetChild(currentCableId).GetChild(0);
        tempCable = Instantiate(daydangxet);
        tempCable.SetParent(daythaydoi);
        ResetTempCable();
    }
    public void SetSelectedCableId()
    {
        selectedCableId = currentCableId;
        tempCable.GetComponent<DayMangController>().UpdateType(GetType(selectedCableId));
    }
    public void OnSwapCableMode()
    {
        //TachDay();
        isStateCableDone = false;
        isSwapCableMode = true;
        selectedCableId = -1;
        currentCableId = 0;
        NewTempCable();
        handInput.transform.parent.parent.GetComponent<ContinuousTurnProviderBase>().enabled = false;
        handInput.transform.parent.parent.GetComponent<ContinuousMoveProviderBase>().enabled = false;
    }
    public void OffSwapCableMode()
    {
        //TachDay();
        isSwapCableMode = false;
        Destroy(tempCable.gameObject);
        CheckStateCable();
        handInput.transform.parent.parent.GetComponent<ContinuousTurnProviderBase>().enabled = true;
        handInput.transform.parent.parent.GetComponent<ContinuousMoveProviderBase>().enabled = true;
    }
    public void TurnLeftCable()
    {
        currentCableId += 1;
        currentCableId %= 8;
        daydangxet = daythaydoi.GetChild(currentCableId).GetChild(0);
    }
    public void TurnRightCable()
    {
        currentCableId -= 1;
        currentCableId = (currentCableId + 8) % 8;
        daydangxet = daythaydoi.GetChild(currentCableId).GetChild(0);
    }
    public void ChangeTypeCableChild(int id, DayMangController.Type type)
    {
        var day = daythaydoi.GetChild(id);
        day.GetChild(0).GetComponent<DayMangController>().UpdateType(type);
        day.GetChild(1).GetComponent<DayMangController>().UpdateType(type);
    }
    public DayMangController.Type GetType(int id)
    {
        return daythaydoi.GetChild(id).GetChild(0).GetComponent<DayMangController>()._type;
    }
    public void SwapCable()
    {
        var temp = GetType(selectedCableId);
        ChangeTypeCableChild(selectedCableId, GetType(currentCableId));
        ChangeTypeCableChild(currentCableId, temp);
        selectedCableId = -1;
        ResetTempCable();
    }
}
