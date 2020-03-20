using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandHistory
{
    public List<Command> Records { get; } = new List<Command>();

    public Command LastCommand
    {
        get
        {
            if (Records.Count < 1) return null;
            return Records[Records.Count - 1];
        }
    }

    public void DeleteLastCommand()
    {
        var lastCommandIndex = Records.Count - 1;
        if (lastCommandIndex < 0) return;
        Records.RemoveAt(lastCommandIndex);
    }

    public void AddNewCommand(Command newCommand)
    {
        //check if history list length in limits of HistoryCapacity
        if (Records.Count + 1 > Application.Settings.HistoryCapacity)
            DeleteFirstCommand();

        Records.Add(newCommand);
    }

    private void DeleteFirstCommand()
    {
        Records.RemoveAt(0);
    }

}
