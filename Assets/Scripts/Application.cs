using UnityEngine;
using System;

public sealed class Application : MonoBehaviour
{
    [SerializeField]
    private GameObject chosenObject;
    [SerializeField]
    private ApplicationSettings applicationSettings;

    public static Application Instance { get; private set; } = null;
    public static ApplicationSettings Settings => Instance.applicationSettings;
    public static GameObject ChosenObject => Instance.chosenObject;
    public static CommandHandler CommandHandler => Instance._commandHandler;

    public delegate void CommandHistoryChangedHandler();
    public event CommandHistoryChangedHandler CommandHistoryChanged;

    private CommandHandler _commandHandler = new CommandHandler();

    private void SetInstance()
    {
        if (Instance != null)
            throw new Exception("There must be only 1 Application instance in the scene");

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
            if (_commandHandler.ExecuteCommand(new AddTrianglesCommand(ChosenObject)))
                NotifyAboutCommandHistoryUpdate();
            return;
        }
        if (Input.GetKeyDown(Settings.UndoKey))
        {
            if (_commandHandler.UndoLastCommand())
                NotifyAboutCommandHistoryUpdate();
            return;
        }
        if (Input.GetKeyDown(Settings.RedoKey))
        {
            if (_commandHandler.RepeatLastCommand())
                NotifyAboutCommandHistoryUpdate();
            return;
        }
    }

    private void NotifyAboutCommandHistoryUpdate()
    {
        CommandHistoryChanged();
    }

}
