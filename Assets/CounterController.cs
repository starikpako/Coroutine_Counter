using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CounterController : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private Text _counterText;

    private int _currentValue = 0;
    private Coroutine _coroutine;
    private bool _isCounting = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isCounting = !_isCounting;

            if (_isCounting)
            {
                _coroutine = StartCoroutine(CountRoutine());
            }
            else
            {
                StopCounting();
            }
        }
    }

    private void StopCounting()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator CountRoutine()
    {
        while (_isCounting)
        {
            yield return new WaitForSeconds(_delay);

            _currentValue++;

            _counterText.text = _currentValue.ToString();

            Debug.Log($"—четчик: {_currentValue}");
        }
    }
}