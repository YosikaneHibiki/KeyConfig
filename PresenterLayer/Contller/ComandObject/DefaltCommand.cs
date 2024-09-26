using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaltCommand
{
    public AutoSavePath AutoSavePath { get; }

    public DefaltCommand(AutoSavePath autoSavePath)
    {
        AutoSavePath = autoSavePath;
    }
}
