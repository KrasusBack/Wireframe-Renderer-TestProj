using UnityEngine;

public sealed class HistoryRecordsTextUpdater : MonoBehaviour
{
    [SerializeField]
    private string noRecordsMessage = "[No history records]";

    private TMPro.TextMeshProUGUI _textComponent;

    void Start()
    {
        _textComponent = GetComponent<TMPro.TextMeshProUGUI>();
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
            return;
        }

        foreach (var historyString in history)
        {
            newHistory += historyString + "\n";
        } 
        newHistory += "\n";

        _textComponent.text = newHistory;
    }
}
