using ProgressTest6.Models;

namespace ProgressTest6.Repositories.impl
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCompany(Company company)
        => Create(company);

        public void DeleteCompany(Company company)
        => Delete(company);

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        => FindAll(trackChanges).OrderBy(c => c.Name).ToList();

        public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        => FindByCondition(c => ids.Contains(c.Id), trackChanges).ToList();

        public Company GetCompany(Guid companyId, bool trackChanges)
        => FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefault();
    }
}
