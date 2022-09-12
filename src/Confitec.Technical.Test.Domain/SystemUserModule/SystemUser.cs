using Confitec.Technical.Test.Domain.RecoveryPasswordModule;
using Confitec.Technical.Test.Domain.SystemUserModule.Permissions;

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
        public DateTime? LastUpdatePasswordDate { get; private set; }

        private readonly List<RecoveryPassword> _recoveryPasswords;
        public virtual ICollection<RecoveryPassword> RecoveryPasswords => _recoveryPasswords;

        private readonly List<Permission> _permissions;
        public virtual ICollection<Permission> Permissions => _permissions;

        public SystemUser()
        {
            _recoveryPasswords = new List<RecoveryPassword>();
            _permissions = new List<Permission>();
            CreateDate = DateTime.Now;
            LastUpdatePasswordDate = DateTime.Now;
        }

        public SystemUser(string fullName, string userName, string password, string mail)
            : this()
        {
            UpdateBasicInfo(fullName, mail);
            UserName = userName;
            Password = password;
        }


        public void UpdateBasicInfo(string fullName, string mail)
        {
            FullName = fullName;
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

        public void UpdatePass(string newPass)
        {
            Password = newPass;
            LastUpdatePasswordDate = DateTime.Now;
        }

        public void UpdatePass(string newPass, string currentPass)
        {
            if (!Password.Equals(currentPass))
            {
                throw new InvalidDataException("Current password not match!");
            }

            Password = newPass;
            LastUpdatePasswordDate = DateTime.Now;
        }

        public static SystemUser DefaultUser()
        {
            return new SystemUser("Administrador do Sistema", "admin", "123", "andersonandi_t@hotmail.com")
            {
                ID = 1
            };
        }
    }
}
