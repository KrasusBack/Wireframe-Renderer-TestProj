using System.Collections.Generic;

public sealed class CommandHistory
{
    private List<Command> _records = new List<Command>();

    /// <summary>Returns last command from command history. Returns null if there is none.</summary>
    public Command LastCommand
    {
        get
        {
            if (_records.Count == 0) return null;
            return _records[_records.Count - 1];
        }
    }

    public void AddNewCommand(Command newCommand)
    {
        //Checks if history list length in limits of HistoryCapacity
        if (_records.Count + 1 > Application.Settings.HistoryCapacity)
            DeleteFirstCommand();

        _records.Add(newCommand);
    }

    public void DeleteLastCommand()
    {
        var lastCommandIndex = _records.Count - 1;
        if (lastCommandIndex < 0)
        { 
            return;
        }
        _records.RemoveAt(lastCommandIndex);
    }

    private void DeleteFirstCommand()
    {
        _records.RemoveAt(0);
    }

    public void ClearHistory()
    {
        _records.Clear();
    }

    /// <summary>Returns array of command history records in "{index}) {commandType}.ToString()"  </summary>
    public string[] ToArrayOfStrings()
    {
        string[] history = new string[_records.Count];
        if (_records.Count == 0) return history;

        for (var i = 0; i < _records.Count; ++i)
        {
            history[i] = (i + 1) + ") " + _records[i].ToString();
        }

        return history;
    }
}
