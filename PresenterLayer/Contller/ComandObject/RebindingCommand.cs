using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebindingCommand
{
    public string ActionName { get; }
    public int BindIndex { get; }

    public RebindingCommand(string actionName, int bindIndex)
    {
        this.ActionName = actionName;
        this.BindIndex = bindIndex;
    }
}
