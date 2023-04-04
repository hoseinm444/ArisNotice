namespace GeneralInfo.SeedWork.Domain;

public interface IOrganization
{
    Guid Id { get; }
    string OrganizationName { get; }
    IOrganization? ParentOrganization { get; }
}

public class OrganizationBase : IAggregateRoot, IOrganization
{
    public Guid Id { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string OrganizationName { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public OrganizationBase? ParentOrganization { get; set; }

    IOrganization? IOrganization.ParentOrganization
    {
        get
        {
            if (ParentOrganization is not null)
                return (ParentOrganization as IOrganization).ParentOrganization;
            else
                return null;
        }
    }

}

