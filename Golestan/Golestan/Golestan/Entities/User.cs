namespace Golestan.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string UserName { get; set; }
        protected string Password { get; set; }
        public bool IsActive { get; private set; }

        public User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = email;
            IsActive = true;
        }

        public virtual Result ChangePassword(string currentPass, string newPass)
        {
            if(currentPass == Password)
            {
                return SetPassword(newPass);
            }
            else
            {
                return new Result(false, "Current Pass Is InCorrect.");
            }
        }
        public virtual Result SetPassword(string pass)
        {
            if (!string.IsNullOrEmpty(pass) && pass.Length >= 3)
            {
                Password = pass;
                return new Result(true, null);
            }
            else
                return new Result(false,"Password Is Incorrect.");
        }

        public Result CheckPassword(string pass)
        {
            if (Password == pass)
                return new Result(true, null);
            else
                return new Result(false, "Password Is Incorrect.");
        }
        public string ActivateUser()
        {
            IsActive = true;
            return "Success";
        }
    }
}
