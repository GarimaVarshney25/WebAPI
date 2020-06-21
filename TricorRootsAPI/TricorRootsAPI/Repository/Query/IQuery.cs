

namespace TricorRootsAPI.Repository.Query
{
    public interface IQuery
    {
        string GetEmployees { get; }
        string GetEmployeeDetails { get; }
        string AddEmployee { get; }
        string UpdateEmployee { get; }
        string RemoveEmployee { get; }
    }
}
