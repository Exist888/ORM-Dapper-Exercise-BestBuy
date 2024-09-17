namespace ORM_Dapper_Exercise_BestBuy;

public interface IDepartmentRepository
{
    public IEnumerable<Department> GetAllDepartments();
    public void InsertDepartment(string newDepartmentName);
}