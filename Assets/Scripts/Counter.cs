using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [Header("Settings")]
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
            _inputReader.InteractionPerformed += OnInteraction;
        }
    }

    private void OnDisable()
    {
        if (_inputReader != null)
        {
            _inputReader.InteractionPerformed -= OnInteraction;
        }
    }

    private void OnInteraction()
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
        var wait = new WaitForSeconds(_delay);

        while (_isCounting)
        {
            yield return wait;

            _currentValue++;

            CountChanged?.Invoke(_currentValue);
        }
    }
}