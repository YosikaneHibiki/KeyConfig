using UnityEngine.InputSystem;

public class OutputData
{
    public bool IsConfrict { get; }
    public string ActionName { get; }
    public int BindIndex { get; }

    public OutputData(bool isConfrict, string actionName=null, int bindIndex=-1)
    {
        IsConfrict = isConfrict;
        ActionName = actionName;
        BindIndex = bindIndex;
    }
}
