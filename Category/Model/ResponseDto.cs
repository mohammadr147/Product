using System.Reflection.Metadata.Ecma335;

namespace Category.Model;

public class ResponseDto
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public object Result { get; set; }
}