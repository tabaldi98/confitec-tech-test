using Confitec.Technical.Test.Domain.Contracts.Specification;

namespace Confitec.Technical.Test.Domain.SystemUserModule
{
    public static class SystemUserSpecification
    {
        public static DirectSpecification<SystemUser> ByUserNameOrMail(string userNameOrMail)
        {
            return new DirectSpecification<SystemUser>(p =>
                p.UserName.ToLower().Equals(userNameOrMail.ToLower()) ||
                p.Mail.ToLower().Equals(userNameOrMail.ToLower()));
        }

        public static DirectSpecification<SystemUser> ByUserNameOrMail(string userName, string mail)
        {
            return new DirectSpecification<SystemUser>(p =>
                p.UserName.ToLower().Equals(userName.ToLower()) ||
                p.Mail.ToLower().Equals(mail.ToLower()));
        }
    }
}
