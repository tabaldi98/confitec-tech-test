using Confitec.Technical.Test.Domain.Contracts.Specification;

namespace Confitec.Technical.Test.Domain.UserModule
{
    public static class UserSpecification
    {
        public static DirectSpecification<User> ByNameAndSurName(string name, string surName)
        {
            return new DirectSpecification<User>(p =>
                p.Name.ToLower().Equals(name.ToLower()) &&
                p.Surname.ToLower().Equals(surName.ToLower()));
        }

        public static DirectSpecification<User> ByNameAndSurNameAndId(string name, string surName, int id)
        {
            return new DirectSpecification<User>(p =>
                p.Name.ToLower().Equals(name.ToLower()) &&
                p.Surname.ToLower().Equals(surName.ToLower()) &&
                p.ID != id);
        }

        public static DirectSpecification<User> ById(int id)
        {
            return new DirectSpecification<User>(p => p.ID == id);
        }
    }
}
