using UnityEngine;
using UnityEngine.InputSystem;

public enum InputType
{
    Keyboard,
    Gamepad,
    Mouse
}

public class KeyConfig : MonoBehaviour
{

    [SerializeField]
    private InputActionReference actionRef;

    [SerializeField]
    private string bindId;

    [SerializeField]
    private GameObject maskPrefab;

    [SerializeField]
    private InputType inputType;

    [SerializeField]
    private InputType secondInputType;

    private MainController mainController;
    public InputAction action;
    private InputActionRebindingExtensions.RebindingOperation rebindOperation;

    private void Awake()
    {
        if (actionRef == null) { return; }
        mainController = GetComponentInParent<MainController>();
        action = actionRef.action;
    }

    private void OnDestroy()
    {
        CleanUpOperation();
    }

    public void StartRebinding()
    {
        if (action == null) { return; }
        rebindOperation?.Cancel();
        action.Disable();
        var bindingIndex = action.bindings.IndexOf(x => x.id.ToString() == bindId);

        if (maskPrefab != null)
        {
            maskPrefab.SetActive(true);
        }

        void OnFinished()
        {
            CleanUpOperation();
            action.Enable();
            if (maskPrefab != null)
            {
                maskPrefab.SetActive(false);
            }
        }
        var autoSavePath = new AutoSavePath();
        mainController.InputSave(new SaveCommand(autoSavePath));



        rebindOperation = action
            .PerformInteractiveRebinding(bindingIndex)
            .WithControlsHavingToMatchPath(inputType.ToString())
            .WithControlsHavingToMatchPath(secondInputType.ToString())
            .OnComplete(rebindOperation =>
            {
                var rebindComand = new RebindingCommand(rebindOperation.action.name, bindingIndex);
                mainController.InputRebind(rebindComand);
                OnFinished();
            })
            .OnCancel(_ =>
            {
                OnFinished();
            })
            .WithCancelingThrough("<Keyboard>/escape")
            .Start();
    }

    private void CleanUpOperation()
    {
        rebindOperation?.Dispose();
        rebindOperation = null;
    }

    public string GetBindingId() => bindId;

}