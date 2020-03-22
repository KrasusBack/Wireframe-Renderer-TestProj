
public abstract class Command
{
    protected string errorMessage = string.Empty;

    public string ErrorMessage => errorMessage;
    /// <summary>Execute command. Returns operation success status.</summary>
    public abstract bool Execute();
    /// <summary>Undo command. Returns operation success status.</summary>
    public abstract bool Undo();

    //Should preferably return the name of the command in the application
    public abstract override string ToString();
}
