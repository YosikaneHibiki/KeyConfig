using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

public class MainController : MonoBehaviour
{
    private IKeyConfigRebind keyConfigRebind;
    private IKeyConfigCancel keyConfigCancel;
    private IKeyConfigConflict keyConfigConflict;
    private IKeyConfigSave keyConfigSave;
    private IKeyConfigDefault keyConfigDefault;
    private IKeyConfigSetup keyConfigSetup;

    [Inject]
    public void Injction
        ( IKeyConfigRebind keyConfigRebind,
        IKeyConfigCancel keyConfigCancel, IKeyConfigConflict keyConfigConflict,
        IKeyConfigSave keyConfigSave, IKeyConfigDefault keyConfigDefault,
        IKeyConfigSetup keyConfigSetup
        )
    {
        this.keyConfigRebind = keyConfigRebind;
        this.keyConfigCancel = keyConfigCancel;
        this.keyConfigConflict = keyConfigConflict;
        this.keyConfigSave = keyConfigSave;
        this.keyConfigDefault = keyConfigDefault;
        this.keyConfigSetup = keyConfigSetup;
    }

    public void InputRebind(RebindingCommand command)
    {
        keyConfigRebind.KeyConfigRebind(command);
    }

    public void InputConflict(ConflictCommand conflictCommand)
    {
        keyConfigConflict.KeyConfigConflict(conflictCommand);
    }

    public void InputSave(SaveCommand saveCommand)
    {
        keyConfigSave.KeyConfigSave(saveCommand);
    }
    public void InputCancel(CancelCommand cancelCommand)
    {
        keyConfigCancel.KeyConfigCancel(cancelCommand);
    }

    public void InputSetUp(SetupCmmand setupCmmand)
    {
        keyConfigSetup.KeyConfigSetup(setupCmmand);
    }

    public void InputDefalt(DefaltCommand defaltCommand)
    {
        keyConfigDefault.KeyConfigDefault(defaltCommand);
    }

}
