

namespace ArisNotices.Domain.AggregatesModel.Notice;

public class NoticePriority : Enumeration
{
    
    public static NoticePriority NoPriority = new NoticePriority(0, nameof(NoPriority));
    public static NoticePriority High = new NoticePriority(1, nameof(High));

    public NoticePriority(int id, string name) : base(id, name)
    {

    }

   

    //list of enums value for validating which value is chosen
    public static IEnumerable<NoticePriority> List() =>
       new[] { NoPriority, High };
    public static NoticePriority FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (state == null)
        {
            throw new ArgumentNullException($"Possible values for NoticePriority: {String.Join(",", List().Select(s => s.Name))}");
            //OrderingDomainException
        }

        return state;
    }
  
   
    public static NoticePriority FromId(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state == null)
        {
            throw new ArgumentNullException($"Possible values for NoticePriority: {String.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

}