using UnityEngine;
using TMPro;

public class ApplicationMessagesUpdater : MonoBehaviour
{
    [SerializeField]
    private string noMessagesMessage = string.Empty;

    private TextMeshProUGUI _textComponent;

    void Start()
    {
        _textComponent = GetComponent<TextMeshProUGUI>();
        _textComponent.text = noMessagesMessage;
        Application.Instance.ApplicationMessageChanged += UpdateMessagesBox;
    }

    private void UpdateMessagesBox()
    {
        _textComponent.text = Application.CommandHandler.ErrorMessage;      
    }
}
