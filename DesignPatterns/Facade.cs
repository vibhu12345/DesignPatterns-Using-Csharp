

internal class Facade
{
    private List<IAdaptee> adaptees;

    public Facade(List<IAdaptee> adaptees)
    {
        this.adaptees = adaptees;
    }

    internal string ShowFacade()
    {
        return string.Join (" ",adaptees.Select(a => (a.AdapteeMethod() > 0).ToString()));
    }
}