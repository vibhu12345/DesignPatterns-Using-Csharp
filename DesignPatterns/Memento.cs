// The memento: an immutable snapshot of the editor's state
internal record EditorState(string Text, int Cursor);

internal class Editor
{
    private EditorState state = new("", 0);
    private readonly Stack<EditorState> history = new();

    public void Type(string text)
    {
        history.Push(state); // nothing to copy: a record cannot change after it is made
        state = state with { Text = state.Text + text, Cursor = state.Cursor + text.Length };
    }

    public void Undo()
    {
        if (history.TryPop(out var previous)) state = previous;
    }

    public override string ToString() => state.Text;
}
