using UnityEngine.InputSystem;
using VContainer;

public class KeyConfigConflictService : IKeyConfigConflict
{
    private IKeyConfigRepository keyConfigRepository;
    private IOutPutKeyConfig outPutAction;

    [Inject]
    public KeyConfigConflictService(IKeyConfigRepository keyConfigRepository, IOutPutKeyConfig outPutAction)
    {
        this.keyConfigRepository = keyConfigRepository;
        this.outPutAction = outPutAction;
    }

    public void KeyBindCange(ActionName actionName , BindIndex bindIndex)
    {
        keyConfigRepository.Update();
        var targetBind = keyConfigRepository.Find(actionName, bindIndex);
        keyConfigRepository.ChangeBind(targetBind);
        keyConfigRepository.Update();
    }

    public void KeyConfigConflict(ConflictCommand conflictCommand)
    {
        var actionName = new ActionName(conflictCommand.ConflictName);
        var bindIndex = new BindIndex(conflictCommand.BindingIndex);
        KeyBindCange(actionName,bindIndex);
        var outputData = new OutputData(false);
        outPutAction.Output(outputData);
    }

}
