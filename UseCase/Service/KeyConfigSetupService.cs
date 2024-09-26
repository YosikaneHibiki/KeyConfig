using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class KeyConfigSetupService : IKeyConfigSetup
{
    private IKeyConfigRepository keyConfigRepository;
    private IOutPutKeyConfig outPutAction;

    [Inject]
    public KeyConfigSetupService(IKeyConfigRepository keyConfigRepository, IOutPutKeyConfig outPutAction)
    {
        this.keyConfigRepository = keyConfigRepository;
        this.outPutAction = outPutAction;
    }

    public void KeyConfigSetup(SetupCmmand setupCommand)
    {
        Setup(setupCommand);
        var outputData = new OutputData(false);
        outPutAction.Output(outputData);
    }

    public void Setup(SetupCmmand setupComand)
    {
        keyConfigRepository.Load(setupComand.SavePath.Value);
        keyConfigRepository.Update();
        keyConfigRepository.Save(setupComand.SavePath.Value);
    }

}
