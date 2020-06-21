
namespace TricorRootsAPI.Repository.Query
{
    public class Query : IQuery
    {
        public string GetEmployees => "Select * From Employees";
        public string GetEmployeeDetails => "Select * From Employees Where empId= @empId";
        public string AddEmployee => "Insert Into  Employees (FirstName, LastName, Gender, Age, JoinedDate) Values (@firstName, @lastName, @gender, @age, @joinedDate)";
        public string UpdateEmployee => "Update Employees set FirstName = @firstName, LastName = @lastName, Gender = @gender, Age= @age, JoinedDate= @joinedDate Where empId =@empId";
        public string RemoveEmployee => "Delete From Employees Where empId= @empId";
    }
}
