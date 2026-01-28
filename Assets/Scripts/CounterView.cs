using UnityEngine;
using UnityEngine.UI;

public class CounterView : MonoBehaviour
{
    [Header("—сылки")]
    [SerializeField] private Counter _counter;
    [SerializeField] private Text _textComponent;

    private void OnEnable()
    {
        if (_counter != null)
        {
            _counter.CountChanged += UpdateText;
        }
    }

    private void OnDisable()
    {
        if (_counter != null)
        {
            _counter.CountChanged -= UpdateText;
        }
    }

    private void UpdateText(int newValue)
    {
        _textComponent.text = newValue.ToString();
    }
}