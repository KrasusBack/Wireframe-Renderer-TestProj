using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CommandHandler
{
    public CommandHistory History { get; } = new CommandHistory();

    /// <summary>Executes given command and puts it in CommandHistory. Returns operation success status.</summary>
    public bool ExecuteCommand(Command command)
    {
        if (!command.Execute()) return false;
        History.AddNewCommand(command);
        return true;
    }

    /// <summary>Undo last command from CommandHistory. Returns operation success status.</summary>
    public bool UndoLastCommand()
    {
        var lastCommand = History.LastCommand;
        if (lastCommand == null) return false;
        if (!lastCommand.Undo()) return false;

        History.DeleteLastCommand();
        return true;
    }

    /// <summary>Repeat last command from CommandHistory. Returns operation success status.</summary>
    public bool RepeatLastCommand()
    {
        var lastCommand = History.LastCommand;
        if (lastCommand == null) return false;

        return ExecuteCommand(lastCommand);
    }
}
