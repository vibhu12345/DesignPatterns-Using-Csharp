
internal class Handler1:Handler
{
    protected override int RequestNo { get; set; } = 1;
}
internal class Handler2 : Handler
{
    protected override int RequestNo { get; set; } = 2;
}
internal abstract class Handler
{
    protected abstract int RequestNo { get; set; }
    public  Handler? Next { get; set; }
    
    public string HandleRequest(int requestNo)
    {
        return requestNo == RequestNo ? SuccessMessage(requestNo) : NextMessage(requestNo);
    }
    protected string SuccessMessage(int requestNo) => $"Handler {requestNo} Handled the request";
    protected string NextMessage(int requestNo) => Next?.HandleRequest(requestNo) ?? "No Handler handled the request";
}