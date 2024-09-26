using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCmmand
{
    public SavePath SavePath { get; }

    public SetupCmmand(SavePath savePath)
    {
        SavePath = savePath;
    }
}
