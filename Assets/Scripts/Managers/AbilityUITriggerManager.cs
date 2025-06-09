using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using TMPro;
using System;
public class AbilityUITriggerManager : MonoBehaviour
{
    public static event Action<GameObject> AssignAbility;
    [SerializeField] static GameObject bananaPeel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static void OnBananaPeelClick()
    {
        AssignAbility.Invoke(bananaPeel);
        Debug.Log("AssignAbility invoked, banana peel added");
    }
}



