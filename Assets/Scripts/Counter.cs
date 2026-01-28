using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private float _delay = 0.5f;

    [SerializeField] private InputReader _inputReader;

    public event Action<int> CountChanged;

    private int _currentValue = 0;
    private bool _isCounting = false;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        if (_inputReader != null)
        {
            _inputReader.MouseClicked += OnMouseClicked;
        }
    }

    private void OnDisable()
    {
        if (_inputReader != null)
        {
            _inputReader.MouseClicked -= OnMouseClicked;
        }
    }

    private void OnMouseClicked()
    {
        _isCounting = !_isCounting;

        if (_isCounting)
        {
            _coroutine = StartCoroutine(CountRoutine());
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator CountRoutine()
    {
        while (_isCounting)
        {
            yield return new WaitForSeconds(_delay);

            _currentValue++;

            CountChanged?.Invoke(_currentValue);

            Debug.Log($"Logic: Значение {_currentValue}");
        }
    }
}