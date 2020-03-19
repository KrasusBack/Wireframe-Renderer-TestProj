using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application : MonoBehaviour
{
    [SerializeField]
    private GameObject chosenObject;
    [SerializeField]
    private ApplicationSettings applicationSettings;

    private static Application _instance = null;
    private List<Command> _history = new List<Command>();

    public static Application GetInstance()
    {
        return _instance;
    } 

    public static ApplicationSettings Settings => GetInstance().applicationSettings;

    private void SetInstance ()
    {
        if (_instance!=null)
            throw new System.Exception("There must be only 1 Application instance in the scene");
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

    public GameObject ChosenObject()
    {
        return chosenObject;
    }

    #region Commands
        private void AddTrianglesToChosen()
        {
            ExecuteCommand(new AddTrianglesCommand(this));
        }

        private void ExecuteCommand(Command command)
        {
            _history.Add(command);
            command.Execute();
        }

        private void UndoLastCommand()
        {
            var lastCommandIndex = _history.Count - 1;
            if (lastCommandIndex < 0) return;

            _history[lastCommandIndex].Undo();
            _history.RemoveAt(lastCommandIndex);
        }

        private void RepeatLastCommand()
        {
            ExecuteCommand(_history[_history.Count - 1]);
        }
    #endregion
}
