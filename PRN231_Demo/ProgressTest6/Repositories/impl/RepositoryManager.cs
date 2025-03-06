using ProgressTest6.Models;

namespace ProgressTest6.Repositories.impl
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;
        public RepositoryManager(RepositoryContext repositoryContext, ICompanyRepository companyRepository, IEmployeeRepository employeeRepository)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }

        public ICompanyRepository Company
        {
            get 
            { 
                if(_companyRepository == null)
                {
                    _companyRepository = new CompanyRepository(_repositoryContext);
                }
                return _companyRepository; 
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_repositoryContext);
                }
                return _employeeRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
    }
}
