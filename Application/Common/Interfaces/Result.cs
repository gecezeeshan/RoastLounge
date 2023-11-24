
namespace Application.Common.Interfaces 
{

 public class Result{

   public bool Succeed { get; set; }
   public string[] Errors { get; set; }
    internal Result(bool succeed, IEnumerable<string> errors)
    {
      Succeed = succeed;
      Errors = errors.ToArray();
    }
    public static Result Success()
    {
      return new Result(true, new string[] {});
    }

    public static Result Failure(IEnumerable<string> errors)
    {
      return new Result(true,errors);
    }
 }

}