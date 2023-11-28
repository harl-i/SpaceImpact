using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class InternationalText : MonoBehaviour
{
    [SerializeField] private string _en;
    [SerializeField] private string _ru;
    [SerializeField] private string _tr;

    private TextMeshProUGUI _textMeshProUGUI;

    private const string Ru = "ru";
    private const string Tr = "tr";

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
#if !UNITY_EDITOR
        if (Language.Instance.CurrentLanguage == Tr)
        {
            _textMeshProUGUI.text = _tr;
        }
        else if (Language.Instance.CurrentLanguage == Ru)
        {
            _textMeshProUGUI.text = _ru;
        }
        else
        {
            _textMeshProUGUI.text = _en;
        }
#endif

#if UNITY_EDITOR
        _textMeshProUGUI.text = _en;
#endif

    }
}
