using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //Posso ter que remover o primeiro array
    public string[] name;

    [TextArea(3, 10)]
    public string[] sentences;
}
