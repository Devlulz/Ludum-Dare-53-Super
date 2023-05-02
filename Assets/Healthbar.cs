using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public static Healthbar Instance;

    public Slider slider;

    private void Awake()
    {
        Instance = this;
    }
}
