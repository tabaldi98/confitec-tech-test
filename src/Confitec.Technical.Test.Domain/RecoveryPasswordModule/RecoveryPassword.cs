using Confitec.Technical.Test.Domain.SystemUserModule;

namespace Confitec.Technical.Test.Domain.RecoveryPasswordModule
{
    public class RecoveryPassword : Entity
    {
        public string Code { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool IsUsed { get; private set; }

        public virtual int SystemUserID { get; private set; }
        public virtual SystemUser SystemUser { get; private set; }

        public RecoveryPassword()
        { }

        public RecoveryPassword(SystemUser user)
        {
            SystemUserID = user.ID;
            SystemUser = user;

            GenerateCode();
        }

        private void GenerateCode()
        {
            ExpirationDate = DateTime.Now.AddDays(1);

            Code = new Random().Next(100000, 999999).ToString();

            IsUsed = false;
        }

        public bool ValidateCode(string digitedCode)
        {
            // Valida se já foi usado
            if (IsUsed)
            {
                return false;
            }

            // Valida se o código bate
            if (!Code.Equals(digitedCode))
            {
                return false;
            }

            // Valida se já expirou
            if (DateTime.Now > ExpirationDate)
            {
                return false;
            }

            return true;
        }

        public void SetAsUsed()
        {
            IsUsed = true;
        }
    }
}
