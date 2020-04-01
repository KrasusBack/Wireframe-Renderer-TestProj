using UnityEngine;
using System;

public sealed class ApplicationCore : MonoBehaviour
{
    [SerializeField]
    private GameObject chosenObject;
    [SerializeField]
    private ApplicationSettings applicationSettings;

    public static ApplicationCore Instance { get; private set; } = null;
    public static ApplicationSettings Settings => Instance.applicationSettings;
    public static GameObject ChosenObject => Instance.chosenObject;
    public static CommandHandler CommandHandler => Instance._commandHandler;

    public delegate void CommandHistoryChangedHandler();
    public event CommandHistoryChangedHandler CommandHistoryChanged;

    public delegate void ApplicationMessageHandler();
    public event ApplicationMessageHandler ApplicationMessageChanged;

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
        CheckAndHandleCommands();
    }

    private void CheckAndHandleCommands()
    {
        if (AddTrianglesHandler()) return;
        if (RemoveTrianglesHandler()) return;
        if (UndoHandler()) return;
        if (RedoHandler()) return;
    }

    private bool AddTrianglesHandler()
    {
        if (!Input.GetKeyDown(Settings.AddTrianglesKey)) return false;

        if (_commandHandler.ExecuteCommand(new AddTrianglesCommand(ChosenObject)))
        {
            NotifyAboutCommandHistoryUpdate();
        }
        NotifyAboutApplicationMessageChanged();
        return true;
    }

    private bool RemoveTrianglesHandler ()
    {
        if (!Input.GetKeyDown(Settings.RemoveTrianglesKey)) return false;

        if (_commandHandler.ExecuteCommand(new RemoveTrianglesCommand(ChosenObject)))
        {
            NotifyAboutCommandHistoryUpdate();
        }
        NotifyAboutApplicationMessageChanged();
        return true;
    }

    private bool UndoHandler()
    {
        if (!Input.GetKeyDown(Settings.UndoKey)) return false;

        if (_commandHandler.UndoLastCommand())
        {
            NotifyAboutCommandHistoryUpdate();
        }
        NotifyAboutApplicationMessageChanged();
        return true;
    }

    private bool RedoHandler ()
    {
        if (!Input.GetKeyDown(Settings.RedoKey)) return false;

        if (_commandHandler.RepeatLastCommand())
        {
            NotifyAboutCommandHistoryUpdate();
        }
        NotifyAboutApplicationMessageChanged();
        return true;
    }

    private void NotifyAboutCommandHistoryUpdate()
    {
        CommandHistoryChanged();
    }

    private void NotifyAboutApplicationMessageChanged ()
    {
        ApplicationMessageChanged();
    }
}
