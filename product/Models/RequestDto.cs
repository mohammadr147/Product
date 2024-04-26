namespace product.Models;

public class RequestDto
{
    public string url { get; set; }
    public byte httpmethod { get; set; }    //1-get  2-post  3-put
    public object Data { get; set; }
}