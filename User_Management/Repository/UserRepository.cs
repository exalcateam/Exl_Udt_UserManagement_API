using Microsoft.AspNetCore.Mvc;
using User_Management.Data;
using User_Management.Model;

namespace User_Management.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<UserDetail> GetUsers()
        {
            return _context.Users.ToList();
        }

        public ActionResult<UserDetail> Login([FromBody] Login data)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Username == data.Username && x.Password == data.Password);
                if (user == null)
                    return null;
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult<UserDetail> GetUserByID( string Emp_ID) 
        {
            var user = _context.Users.FirstOrDefault(x => x.Emp_ID == Emp_ID);
            if (user == null)
                return user;
            return user;
        }

        public bool CreateUser([FromBody] UserDetail user)
        {
            try
            {
                user.Photo = null;
                user.Id = 0;

                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateUser([FromBody] UserDetail user)
        {
            try
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<UserDetail> ShowUser(string Department)
        {
            try
            {
                return _context.Users.Where(c => c.Department.Equals(Department.ToLower()) || c.Role.Equals(Department.ToLower())).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        

        public List<string> GetDepartments()
        {
            return _context.Users.Select(c => c.Department).Distinct().ToList();
        }
        public List<string> GetRoles()
        {
            return _context.Users.Select(c => c.Role).Distinct().ToList();
        }
        public bool DeleteUser(string Emp_ID)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Emp_ID == Emp_ID);
                if (user == null)
                    return false;
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
