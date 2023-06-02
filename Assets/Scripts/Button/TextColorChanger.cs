using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(TextMeshProUGUI))]
public class TextColorChanger : MonoBehaviour
{
    [SerializeField] private Color _pressedColor;
    [SerializeField] private Button _button;

    private TextMeshProUGUI _buttonText;
    private int _blinkCount = 5;

    private void Start()
    {
        _button = GetComponent<Button>();
        _buttonText = _button.GetComponentInChildren<TextMeshProUGUI>();
        _button.onClick.AddListener(ChangeColor);
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
            _buttonText.color = _pressedColor;
            yield return blinkDuration;
            _buttonText.color = Color.white;
            yield return blinkDuration;
        }
    }
}
