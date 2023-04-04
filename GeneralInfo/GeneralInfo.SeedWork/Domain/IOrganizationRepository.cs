namespace GeneralInfo.SeedWork.Domain;

public interface IOrganizationBaseRepository : IRepository<OrganizationBase>
{
    OrganizationBase Add(OrganizationBase organizationBase);
    OrganizationBase Update(OrganizationBase organizationBase);
    bool Delete(OrganizationBase organizationBase);
    Task<OrganizationBase> FindAsync(string organizationName);
    Task<OrganizationBase> FindByIdAsync(Guid id);
    Task<OrganizationBase> FindParentOrgAsync(Guid id);
    Task<OrganizationBase> FindFirstParentOrgAsync(Guid id);
    Task<OrganizationBase> FindChildOrgAsync(Guid id);
}

