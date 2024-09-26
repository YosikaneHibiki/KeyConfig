public class ConflictCommand
{
    public string ConflictName { get; }
    public int BindingIndex { get; }

    public ConflictCommand(string conflictName,int BindingIndex)
    {
        this.ConflictName = conflictName;
        this.BindingIndex = BindingIndex;
    }
}
