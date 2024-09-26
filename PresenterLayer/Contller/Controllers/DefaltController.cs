using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaltController : MonoBehaviour
{
    private MainController mainController;

    private void Start()
    {
        mainController = GetComponentInParent<MainController>();
    }

    public void Defalt()
    {
        var defaltCommand = new DefaltCommand(new AutoSavePath()) ;
        mainController.InputDefalt(defaltCommand);
    }
}
