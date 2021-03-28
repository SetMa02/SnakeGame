﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedButt : MonoBehaviour
{
    private bool isPressed;
    public bool IsPressed
    {  get { return isPressed; } }

    public void onPointerDown()
    {
        isPressed = true; 
    }

    public void onPointerUp()
    {
        isPressed = false;
    }
}
