using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour //use simpleton method

{
    public static HealthBar Instance
    {
        get
        {
            return instance;
        }
    }

    private static HealthBar instance = null;

    public int MaxHp = 0;
    public bool IsPaused = false;
    public bool InputAllowed = true;

    void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;
    }
}

