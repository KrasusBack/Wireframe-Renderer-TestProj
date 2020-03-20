using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Application : MonoBehaviour
{
    [SerializeField]
    private GameObject chosenObject;
    [SerializeField]
    private ApplicationSettings applicationSettings;
    [SerializeField]
    private GameObject historyTextBox;

    private CommandHandler _commandHandler = new CommandHandler();
    private Text _historyText;

    public static Application Instance { get; private set; } = null;
    public static ApplicationSettings Settings => Instance.applicationSettings;
    public static GameObject ChosenObject => Instance.chosenObject;

    private void SetInstance()
    {
        if (Instance != null)
            throw new System.Exception("There must be only 1 Application instance in the scene");

        _historyText = historyTextBox.GetComponent<Text>();
        Instance = this;
    }

    private void Start()
    {
        SetInstance();
    }

    private void Update()
    {
        if (Input.GetKeyDown(Settings.AddTrianglesKey))
        {
            _commandHandler.ExecuteCommand(new AddTrianglesCommand());
            UpdateHistoryTextbox();
            return;
        }
        if (Input.GetKeyDown(Settings.UndoKey))
        {
            _commandHandler.UndoLastCommand();
            UpdateHistoryTextbox();
            return;
        }
        if (Input.GetKeyDown(Settings.RedoKey))
        {
            _commandHandler.RepeatLastCommand();
            UpdateHistoryTextbox();
            return;
        }
    }

    #region Text Handler
        private void UpdateHistoryTextbox()
        {
            if (_historyText == null) return;

            string newHistory = string.Empty;
            var history = _commandHandler.HistoryRecords;

            for(var i = 0; i<history.Count; ++i)
            {
                newHistory += (i+1) + ") " + " " + history[i].GetType().ToString() + "\n";
            }
            _historyText.text = newHistory;
        }
    #endregion
}
