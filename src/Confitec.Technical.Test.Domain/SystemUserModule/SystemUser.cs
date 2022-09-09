namespace Confitec.Technical.Test.Domain.SystemUserModule
{
    public class SystemUser : Entity
    {
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Mail { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? LastLoginDate { get; private set; }

        public SystemUser()
        {
            CreateDate = DateTime.Now;
        }

        public SystemUser(string fullName, string userName, string password, string mail) : this()
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
            Mail = mail;
        }

        public void DoLogin(string password)
        {
            if (!Password.Equals(password))
            {
                throw new InvalidDataException("Password not match!");
            }

            LastLoginDate = DateTime.Now;
        }

        public static SystemUser DefaultUser()
        {
            return new SystemUser("Administrador", "admin", "123", "tabaldi98@gmail.com")
            {
                ID = 1
            };
        }
    }
}
