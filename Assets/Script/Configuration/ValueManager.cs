using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ValueManager : MonoBehaviour
{
    TMP_Text tmp;
    public float Value;
    float tempValue;
    public bool isPointerDown = false;
    public UnityEvent onValueChanged = new UnityEvent();
    void Start()
    {
        tmp = GetComponent<TMP_Text>();
        ConfigManager.EnsureInitialization();
        onValueChanged.AddListener(UpdateText);
    }
    void Update()
    {
        if (isPointerDown)
        {
            ChangeValueContinue(tempValue);
        }
    }
    public void ChangeValueContinue(float _value)
    {
        tempValue = _value;
        Value += Time.deltaTime * _value;
        isPointerDown = true;
        onValueChanged?.Invoke();
    }
    public void PointerState(bool state)
    {
        isPointerDown = state;
    }
    public void ResetValue()
    {
        Value = 0;
        onValueChanged?.Invoke();
    }
    public void UpdateText()
    {
        tmp.text = String.Format("{0:F2}", Value);
    }
}
