using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyConfigDefaultService : IKeyConfigDefault
{
    private IKeyConfigRepository keyConfigRepository;
    private IOutPutKeyConfig outPutAction;

    public KeyConfigDefaultService(IKeyConfigRepository keyConfigRepository, IOutPutKeyConfig outPutAction)
    {
        this.keyConfigRepository = keyConfigRepository;
        this.outPutAction = outPutAction;
    }

    public void KeyConfigDefault(DefaltCommand defaltCommand)
    {
        keyConfigRepository.Delate();
        keyConfigRepository.Save(defaltCommand.AutoSavePath.Vaule);
        var outputData = new OutputData(false);
        outPutAction.Output(outputData);
    }
}
