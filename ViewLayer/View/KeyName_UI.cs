using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyName_UI : MonoBehaviour
{

    private TMP_Text tMP_Text;

    private KeyConfig keyConfig;

    private void Start()
    {
        RefreshDisplay();
    }

    private void OnEnable()
    {
        tMP_Text = GetComponent<TMP_Text>();
        keyConfig = GetComponentInParent<KeyConfig>();

        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        var action = keyConfig.action;

        var bindingIndex = action.bindings.IndexOf(x => x.id.ToString() == keyConfig.GetBindingId());

        if (bindingIndex != -1)
        {
            tMP_Text.text = action.GetBindingDisplayString(bindingIndex);
        }
    }

}
