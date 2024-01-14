
internal class Template1: Template
{
    Func<string> action;
    public Template1(Func<string> action)
    {
        this.action = action;
    }

    protected override string Body()
    {
        return action();
    }

    public override string TemplateMethod()
    {
        return Header()+ Environment.NewLine+ Body()+ Environment.NewLine+Footer();
    }
}

abstract  class Template
{
    protected string Header()
    {
        return "Header";
    }
    protected string Footer()
    {
        return "Footer";
    }
    protected abstract string Body();
    public abstract string TemplateMethod();

}