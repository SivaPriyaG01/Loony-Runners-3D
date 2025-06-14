using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using TMPro;
using System;
public class AbilityUITriggerManager : MonoBehaviour
{
    public event Action<GameObject> AssignAbility;
    public event Action StartRayCast;
    [SerializeField] GameObject bananaPeel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnBananaPeelClick()
    {
        AssignAbility?.Invoke(bananaPeel);
        StartRayCast?.Invoke();
        Debug.Log("AssignAbility invoked, banana peel added");
    }
}



