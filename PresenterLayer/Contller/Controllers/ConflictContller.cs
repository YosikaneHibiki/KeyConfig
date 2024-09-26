using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConflictContller : MonoBehaviour
{
    private MainController controller;
    [SerializeField]
    private Button cancelButton;
    [SerializeField]
    private Button conflictButton;
    [SerializeField]
    private TMP_Text tMP;

    private void Start()
    {
        controller = GetComponentInParent<MainController>();
    }

    public void ButtonSetting(OutputData outputData)
    {
        tMP.text = outputData.ActionName + "KeyConflict";
        conflictButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();

        conflictButton.onClick.AddListener(() => Conflict(outputData));
        cancelButton.onClick.AddListener(Cancel);
    }

    private void Cancel()
    {
        var autoSaveComand = new AutoSavePath();
        var canselComand = new CancelCommand(autoSaveComand);
        controller.InputCancel(canselComand);
        controller.InputSave(new SaveCommand(autoSaveComand));
        this.gameObject.SetActive(false);
    }

    private void Conflict(OutputData outputData)
    {
        var conflictCommand = new ConflictCommand(outputData.ActionName, outputData.BindIndex);
        controller.InputConflict(conflictCommand);
        this.gameObject.SetActive(false);
    }
}
