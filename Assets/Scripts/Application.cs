using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Application : MonoBehaviour
{
    private static Application _instance = null;

    [SerializeField]
    private GameObject chosenObject;
    [SerializeField]
    private ApplicationSettings applicationSettings;
    [SerializeField]
    private GameObject historyTextBox;

    private List<Command> _history = new List<Command>();
    private Text _historyText;

    public static Application GetInstance()
    {
        return _instance;
    }

    public static ApplicationSettings Settings => GetInstance().applicationSettings;
    public static GameObject ChosenObject => GetInstance().chosenObject;

    private void SetInstance()
    {
        if (_instance != null)
            throw new System.Exception("There must be only 1 Application instance in the scene");

        _historyText = historyTextBox.GetComponent<Text>();
        _instance = this;
    }

    private void Start()
    {
        SetInstance();
    }

    private void Update()
    {
        if (Input.GetKeyDown(Settings.AddTrianglesKey))
        {
            AddTrianglesToChosen();
            return;
        }
        if (Input.GetKeyDown(Settings.UndoKey))
        {
            UndoLastCommand();
            return;
        }
        if (Input.GetKeyDown(Settings.RedoKey))
        {
            RepeatLastCommand();
            return;
        }
    }

    private void UpdateHistoryTextbox()
    {
        if (_historyText == null) return;

        string newHistory = string.Empty;

        foreach (Command command in _history)
        {
            newHistory += command.GetType().ToString() + "\n";
        }
        _historyText.text = newHistory;
    }

    #region Commands
    private void AddTrianglesToChosen()
    {
        ExecuteCommand(new AddTrianglesCommand());
    }

    private void ExecuteCommand(Command command)
    {
        _history.Add(command);
        command.Execute();
        UpdateHistoryTextbox();
    }

    private void UndoLastCommand()
    {
        var lastCommandIndex = _history.Count - 1;
        if (lastCommandIndex < 0) return;

        _history[lastCommandIndex].Undo();
        _history.RemoveAt(lastCommandIndex);
        UpdateHistoryTextbox();
    }

    private void RepeatLastCommand()
    {
        ExecuteCommand(_history[_history.Count - 1]);
    }
    #endregion
}
