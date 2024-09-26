using System;
using UnityEngine;

public class KeyConfigPresenter : MonoBehaviour ,IOutPutKeyConfig
{
    [SerializeField]
    private GameObject conflictMenu;

    private KeyName_UI[] keyName_UI;

    private ConflictContller conflictContller;
    private Action Refresh_UI;


    private void OnEnable()
    {
        conflictContller = conflictMenu.GetComponent<ConflictContller>();
        keyName_UI = GetComponentsInChildren<KeyName_UI>();

        foreach(var key in keyName_UI)
        {
            Refresh_UI += key.RefreshDisplay;
        }
    }

    private void OnDisable()
    {
        foreach(var key in keyName_UI)
        {
            Refresh_UI -= key.RefreshDisplay;
        }
    }

    public void Output(OutputData outputData)
    {
        if (outputData.IsConfrict)
        {
            conflictMenu.SetActive(true);
            conflictContller.ButtonSetting(outputData);
            RefreshDisplay();
        }
        else
        {
            RefreshDisplay();
        }
    }

    public void RefreshDisplay()
    {
        Refresh_UI?.Invoke();
    }

}
