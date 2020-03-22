using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationMessagesUpdater : MonoBehaviour
{
    [SerializeField]
    private string noMessagesMessage = string.Empty;

    private TMPro.TextMeshProUGUI _textComponent;

    void Start()
    {
        _textComponent = GetComponent<TMPro.TextMeshProUGUI>();
        _textComponent.text = noMessagesMessage;
        Application.Instance.ApplicationMessageChanged += UpdateMessagesBox;
    }

    private void UpdateMessagesBox()
    {
        _textComponent.text = Application.CommandHandler.ErrorMessage;      
    }
}
