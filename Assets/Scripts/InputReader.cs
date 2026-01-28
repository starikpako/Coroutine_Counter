using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action MouseClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClicked?.Invoke();
        }
    }
}