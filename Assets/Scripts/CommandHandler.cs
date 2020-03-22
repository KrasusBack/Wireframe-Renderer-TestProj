
public sealed class CommandHandler
{
    public CommandHistory History { get; } = new CommandHistory();
    public string ErrorMessage { get; private set; } = string.Empty;

    /// <summary>Executes given command and puts it in CommandHistory. Returns operation success status.</summary>
    public bool ExecuteCommand(Command command)
    {
        if (!command.Execute())
        {
            ErrorMessage = command.ErrorMessage;
            return false;
        }

        ErrorMessage = string.Empty;
        History.AddNewCommand(command);
        return true;
    }

    /// <summary>Undo last command from CommandHistory. Returns operation success status.</summary>
    public bool UndoLastCommand()
    {
        var lastCommand = History.LastCommand;
        if (lastCommand == null) return false;
        if (!lastCommand.Undo())
        {
            ErrorMessage = lastCommand.ErrorMessage;
            return false;
        }

        ErrorMessage = string.Empty;
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
