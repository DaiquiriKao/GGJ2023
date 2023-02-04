using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Status : MonoBehaviour
{
    [Flags]
    public enum status { None = 0, Float = 1, Flyable = 1 << 1, Unstoppable = 1 << 2};

    public status CurrentSatus;
}
