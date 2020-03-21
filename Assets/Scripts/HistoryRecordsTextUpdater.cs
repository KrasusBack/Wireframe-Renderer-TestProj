using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryRecordsTextUpdater : MonoBehaviour
{
    [SerializeField]
    private string noRecordsMessage = "[No history records]";

    private TMPro.TextMeshProUGUI _textComponent;

    void Start()
    {
        _textComponent = GetComponent<TMPro.TextMeshProUGUI>();
        Application.Instance.CommandsHistoryChanged += UpdateHistoryScrollRect;
    }

    private void UpdateHistoryScrollRect()
    {
        string newHistory = string.Empty;
        var history = Application.CommandHandler.History.Records;

        if (history.Count == 0)
        {
            newHistory = noRecordsMessage;
        }
        else
        {
            for (var i = 0; i < history.Count; ++i)
            {
                newHistory += (i + 1) + ") " + history[i].ToString() + "\n";
            }
        }
        newHistory += "\n";

        _textComponent.text = newHistory;
    }
}
