using Confitec.Technical.Test.Domain.RecoveryPasswordModule;

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

        private readonly List<RecoveryPassword> _recoveryPasswords;
        public virtual ICollection<RecoveryPassword> RecoveryPasswords => _recoveryPasswords;

        public SystemUser()
        {
            _recoveryPasswords = new List<RecoveryPassword>();
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
            return new SystemUser("Administrador do Sistema", "admin", "123", "andersonandi_t@hotmail.com")
            {
                ID = 1
            };
        }

        public void UpdatePass(string newPass)
        {
            Password = newPass;
        }
    }
}
