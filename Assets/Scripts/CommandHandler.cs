using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandHandler
{
    public CommandHistory History { get; } = new CommandHistory();

    public void ExecuteCommand(Command command)
    {
        History.AddNewCommand(command);
        command.Execute();
    }

    public void UndoLastCommand()
    {
        var lastCommand = History.LastCommand;
        if (lastCommand == null) return;

        History.DeleteLastCommand();
        lastCommand.Undo();
    }

    public void RepeatLastCommand()
    {
        var lastCommand = History.LastCommand;
        if (lastCommand == null) return;

        ExecuteCommand(lastCommand);
    }
}
