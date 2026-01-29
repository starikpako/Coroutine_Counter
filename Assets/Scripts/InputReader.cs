using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _interactionButtonIndex = 0;

    public event Action InteractionPerformed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_interactionButtonIndex))
        {
            InteractionPerformed?.Invoke();
        }
    }
}