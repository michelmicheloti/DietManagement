namespace DietManagement;
public class Result<T>
{
    public bool Success { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
    public T Data { get; set; } = default!;

    public static Result<T> Ok(T data)
    {
        return new Result<T> { Success = true, Data = data };
    }

    public static Result<T> Fail(List<string> errors)
    {
        return new Result<T> { Success = false, Errors = errors };
    }
}

