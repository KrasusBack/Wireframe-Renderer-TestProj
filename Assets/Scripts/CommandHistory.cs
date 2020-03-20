using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandHistory
{
    public List<Command> HistoryRecords { get; } = new List<Command>();

    public Command LastCommand
    {
        get
        {
            if (HistoryRecords.Count < 1) return null;
            return HistoryRecords[HistoryRecords.Count - 1];
        }
    }

    public void DeleteLastCommand()
    {
        var lastCommandIndex = HistoryRecords.Count - 1;
        if (lastCommandIndex < 0) return;
        HistoryRecords.RemoveAt(lastCommandIndex);
    }

    public void AddNewCommand(Command newCommand)
    {
        //check if history list length in limits of HistoryCapacity
        if (HistoryRecords.Count + 1 > Application.Settings.HistoryCapacity)
            DeleteFirstCommand();

        HistoryRecords.Add(newCommand);
    }

    private void DeleteFirstCommand()
    {
        HistoryRecords.RemoveAt(0);
    }

}
