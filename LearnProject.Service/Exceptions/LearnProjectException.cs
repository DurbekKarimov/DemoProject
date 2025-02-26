namespace LearnProject.Service.Exceptions;

public class LearnProjectException:  Exception
{
    public int StatusCode { get; set; }
    public LearnProjectException(int statusCode,string message) : base(message)
    {
        this.StatusCode = statusCode;
    }
}
