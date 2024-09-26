using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelCommand
{
    public AutoSavePath autoSavePath { get; }

    public CancelCommand(AutoSavePath autoSavePath)
    {
        this.autoSavePath = autoSavePath;
    }
}
