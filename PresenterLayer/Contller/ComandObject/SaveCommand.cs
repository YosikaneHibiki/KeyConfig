using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCommand
{
    public SavePath SavePath { get; }
    public AutoSavePath AutoSavePath { get; }

    public SaveCommand(SavePath savePath)
    {
        SavePath = savePath;
    }
    public SaveCommand(AutoSavePath autoSavePath)
    {
        AutoSavePath = autoSavePath;
    }


}
