using Confitec.Technical.Test.Domain.Contracts.Specification;

namespace Confitec.Technical.Test.Domain.RecoveryPasswordModule
{
    public static class RecoveryPasswordSpecification
    {
        public static DirectSpecification<RecoveryPassword> ByUserId(int userId)
        {
            return new DirectSpecification<RecoveryPassword>(p => p.ID == userId);
        }

        public static DirectSpecification<RecoveryPassword> ByUserName(string userName)
        {
            return new DirectSpecification<RecoveryPassword>(p =>
                !p.IsUsed &&
                (p.SystemUser.UserName.ToLower().Equals(userName.ToLower()) ||
                p.SystemUser.Mail.ToLower().Equals(userName.ToLower())));
        }
    }
}
