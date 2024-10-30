using UnityEngine;
using UnityEngine.UI;

public class ButtonGlowEffect : MonoBehaviour
{
    private Outline buttonOutline;

    void Start()
    {
        buttonOutline = GetComponent<Outline>();
        buttonOutline.enabled = false; // Ban đầu tắt phát sáng
    }

    public void OnPointerEnter()
    {
        buttonOutline.enabled = true; // Bật phát sáng khi trỏ vào
    }

    public void OnPointerExit()
    {
        buttonOutline.enabled = false; // Tắt phát sáng khi rời khỏi
    }
}
