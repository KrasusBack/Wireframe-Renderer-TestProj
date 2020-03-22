using UnityEngine;
using TMPro;

public sealed class HistoryRecordsTextUpdater : MonoBehaviour
{
    [SerializeField]
    private string noRecordsMessage = "[No history records]";

    private TextMeshProUGUI _textComponent;

    void Start()
    {
        _textComponent = GetComponent<TextMeshProUGUI>();
        _textComponent.text = noRecordsMessage;
        Application.Instance.CommandHistoryChanged += UpdateHistoryScrollRect;
    }

    private void UpdateHistoryScrollRect()
    {
        string newHistory = string.Empty;
        var history = Application.CommandHandler.History.ToArrayOfStrings();

        if (history.Length == 0)
        {
            newHistory = noRecordsMessage;
        }
        else
        {
            foreach (var historyString in history)
            {
                newHistory += historyString + "\n";
            }
            newHistory += "\n";
        }  

        _textComponent.text = newHistory;
    }
}
