using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using User_Management.Data;
using User_Management.Model;
using User_Management.Repository;

namespace User_Management.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _userRepo;

        
        public UserController(IUserRepository userRepo , AppDbContext context)
        {
            this._userRepo = userRepo;
            _context = context;
        }
 
        [HttpGet]
        public List<UserDetail> GetUsers()
        {
           return _userRepo.GetUsers();
        }

        [HttpPost]
        public ActionResult<UserDetail> Login([FromBody] Login data)
        {
            return _userRepo.Login(data);
        }

        [HttpGet]
        public ActionResult<UserDetail> GetUserByID(string Emp_ID) 
        {
            return _userRepo.GetUserByID(Emp_ID);  
        }

        [HttpPost]
        public bool CreateUser([FromBody] UserDetail user)
        {
           return _userRepo.CreateUser(user);  
        }

        [HttpPut]
        public bool UpdateUser([FromBody] UserDetail user)
        {
            return _userRepo.UpdateUser(user);
        }

        [HttpPost]
        public List<UserDetail>  ShowUser(string Department)
        {
            return _userRepo.ShowUser(Department);
        }

        [HttpGet]
        public List<string> GetDepartments()
        {
            return _userRepo.GetDepartments();   
        }

        [HttpGet]
        public List<string> GetRoles()
        {
            return _userRepo.GetRoles();
        }

        [HttpDelete]
        public bool DeleteUser(string Emp_ID)
        {
            return _userRepo.DeleteUser(Emp_ID);
        }

    }
}
