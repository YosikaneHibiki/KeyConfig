using VContainer;

public class KeyConfigRebindService : IKeyConfigRebind
{
    private IKeyConfigRepository keyConfigRepository;
    private IOutPutKeyConfig outPutAction;

    [Inject]
    public KeyConfigRebindService(IKeyConfigRepository keyConfigRepository, IOutPutKeyConfig outPutAction)
    {
        this.keyConfigRepository = keyConfigRepository;
        this.outPutAction = outPutAction;
    }

    public bool ConflictCheck(ActionName actionName , BindIndex bindIndex)
    {
        keyConfigRepository.Update();
        keyConfigRepository.Remove(actionName , bindIndex);
        var findAction = keyConfigRepository.Find(actionName, bindIndex).effectivePath;
        keyConfigRepository.Update();
        var isConflict = findAction != null;
        return isConflict;
    }

    public void KeyConfigRebind(RebindingCommand rebindingCommand)
    {
        var actionName = new ActionName(rebindingCommand.ActionName);
        var bindIndex = new BindIndex(rebindingCommand.BindIndex);
        var isConflict = ConflictCheck(actionName,bindIndex);
        var outputData = new OutputData(isConflict,actionName.Vaule,bindIndex.Vaule);
        outPutAction.Output(outputData);
    }
}
