using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupContller : MonoBehaviour
{

    private MainController mainController;

    void Awake()
    {
        mainController = GetComponentInParent<MainController>();
    }

    private void OnEnable()
    {
        Setup();
        Debug.Log("�Z�b�g�A�b�v����");
    }

    public void Setup()
    {
        var setupComand = new SetupCmmand(new SavePath());
        mainController.InputSetUp(setupComand);
    }

}
