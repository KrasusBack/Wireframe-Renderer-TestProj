using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public sealed class Application : MonoBehaviour
{
    [SerializeField]
    private GameObject chosenObject;
    [SerializeField]
    private ApplicationSettings applicationSettings;

    private CommandHandler _commandHandler = new CommandHandler();

    public static Application Instance { get; private set; } = null;
    public static ApplicationSettings Settings => Instance.applicationSettings;
    public static GameObject ChosenObject => Instance.chosenObject;
    public static CommandHandler CommandHandler => Instance._commandHandler;

    public delegate void CommandsHistoryChangedHandler();
    public event CommandsHistoryChangedHandler CommandsHistoryChanged;

    private void SetInstance()
    {
        if (Instance != null)
            throw new Exception("There must be only 1 Application instance in the scene");

        Instance = this;
    }

    private void Awake()
    {
        SetInstance();
    }

    private void Update()
    {
        if (Input.GetKeyDown(Settings.AddTrianglesKey))
        {
            if (_commandHandler.ExecuteCommand(new AddTrianglesCommand(ChosenObject)))
                HistoryUpdatedNotification();
            return;
        }
        if (Input.GetKeyDown(Settings.UndoKey))
        {
            if (_commandHandler.UndoLastCommand())
                HistoryUpdatedNotification();
            return;
        }
        if (Input.GetKeyDown(Settings.RedoKey))
        {
            if (_commandHandler.RepeatLastCommand())
                HistoryUpdatedNotification();
            return;
        }
    }

    private void HistoryUpdatedNotification()
    {
        CommandsHistoryChanged();
    }

}
