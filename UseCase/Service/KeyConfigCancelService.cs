using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

public class KeyConfigCancelService : IKeyConfigCancel
{
    private IKeyConfigRepository configRepository;
    private IOutPutKeyConfig outPutAction;

    [Inject]
    public KeyConfigCancelService(IKeyConfigRepository configRepository, IOutPutKeyConfig outPutAction)
    {
        this.configRepository = configRepository;
        this.outPutAction = outPutAction;
    }

    public void CancelBind(AutoSavePath autoSavePath)
    {
        configRepository.Load(autoSavePath.Vaule);
        configRepository.Update();
    }

    public void KeyConfigCancel(CancelCommand cancelCommand)
    {
        CancelBind(cancelCommand.autoSavePath);
        var outputData = new OutputData(false);
        outPutAction.Output(outputData);
    }
}
