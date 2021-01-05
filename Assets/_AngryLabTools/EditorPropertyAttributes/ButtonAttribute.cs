using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.AttributeUsage(AttributeTargets.Method)]
public class ButtonAttribute : PropertyAttribute
{
    public readonly string methodName;
    public readonly string buttonName;
    public readonly Color color = Color.white;
    public readonly ButtonWidth buttonWidth = ButtonWidth.Medium;

    public enum ButtonWidth
    {
        Small = 30,
        Medium = 50,
        Large = 100
    }

    public enum Colors
    {
        White,
        Green,
        Red,
        Blue,
        Yellow,
        magenta
    }

    public ButtonAttribute(string methodName,string buttonName, ButtonWidth buttonWidth, Colors clr)
    {
        this.methodName = methodName;
        this.buttonName = buttonName;
        this.buttonWidth = buttonWidth;

        switch (clr)
        {
            case Colors.White:
                this.color = Color.white;
                break;
            case Colors.Green:
                this.color = Color.green;
                break;
            case Colors.Red:
                this.color = Color.red;
                break;
            case Colors.Yellow:
                this.color = Color.yellow;
                break;
            case Colors.Blue:
                this.color = Color.blue;
                break;
            case Colors.magenta:
                this.color = Color.magenta;
                break;
            default:
                this.color = Color.green;
                break;
        }
    }
}
