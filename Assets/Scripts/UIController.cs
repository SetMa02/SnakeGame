using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private PressedButt left;
    [SerializeField] private PressedButt right;

    public PressedButt Left
    {
        get { return left; }
    }
    public PressedButt Right
    {
        get { return right; }
    }

    private void Start()
    {
        PlayerController.Insanse.initUiController(this);
    }
}




