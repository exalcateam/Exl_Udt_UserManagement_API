using Microsoft.AspNetCore.Mvc;
using User_Management.Data;
using User_Management.Model;

namespace User_Management.Repository
{
    public interface IUserRepository
    {
        List<UserDetail> GetUsers();
        ActionResult<UserDetail> Login(Login data);
        ActionResult<UserDetail> GetUserByID(string Emp_ID);
        bool CreateUser(UserDetail user);
        bool UpdateUser(UserDetail user);
        List<UserDetail> ShowUser(string Department);
        List<string> GetDepartments();
        List<string> GetRoles();
        bool DeleteUser(string Emp_ID);
    }
}
