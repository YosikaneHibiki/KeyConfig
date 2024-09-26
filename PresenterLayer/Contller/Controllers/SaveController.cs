using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    private MainController mainController;

    public void Start()
    {
        mainController = GetComponentInParent<MainController>();
    }

    public void Save()
    {
        var savePath = new SavePath();
        var saveComand = new SaveCommand(savePath);
        mainController.InputSave(saveComand);
    }
}
