using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandHandler
{
    CommandHistory _commandHistory = new CommandHistory();

    public List<Command> HistoryRecords => _commandHistory.HistoryRecords;

    public void ExecuteCommand(Command command)
    {
        _commandHistory.AddNewCommand(command);
        command.Execute();
    }

    public void UndoLastCommand()
    {
        var lastCommand = _commandHistory.LastCommand;
        if (lastCommand == null) return;

        _commandHistory.DeleteLastCommand();
        lastCommand.Undo();
    }

    public void RepeatLastCommand()
    {
        var lastCommand = _commandHistory.LastCommand;
        if (lastCommand == null) return;

        ExecuteCommand(lastCommand);
    }
}
