using UnityEngine;
using TMPro;

public class ButtonAudioText : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;

    public void OnYesButtonClick()
    {
        textMeshProUGUI.SetText("You clicked Yes");
        // Thực hiện các hành động khác ở đây khi người dùng chọn Yes
    }

    public void OnNoButtonClick()
    {
        textMeshProUGUI.SetText("You clicked No");
        // Thực hiện các hành động khác ở đây khi người dùng chọn No
    }
}