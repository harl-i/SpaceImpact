using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(TextMeshProUGUI))]
public class ChangeTextColor : MonoBehaviour
{
    [SerializeField] private Color pressedColor;
    [SerializeField] private Button button;
    private TextMeshProUGUI buttonText;
    private int _blinkCount = 5;

    private void Start()
    {
        button = GetComponent<Button>();
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        button.onClick.AddListener(ChangeColor);
    }

    public void ChangeColor()
    {
        StartCoroutine(BlinkText());
    }

    private IEnumerator BlinkText()
    {
        WaitForSeconds blinkDuration = new WaitForSeconds(0.08f);

        for (int i = 0; i < _blinkCount; i++)
        {
            buttonText.color = pressedColor;
            yield return blinkDuration;
            buttonText.color = Color.white;
            yield return blinkDuration;
        }
    }
}
