using Confitec.Technical.Test.Domain.Contracts.Mappers;
using Confitec.Technical.Test.Domain.Contracts.Specification;
using Confitec.Technical.Test.Domain.UserModule;
using System.Linq.Expressions;

namespace Confitec.Technical.Test.Application.UserModule.UserRetrieve
{
    public class UserRetrieveODataModel : ODataModelBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public DateTime BirthDate { get; set; }
        public UserScholarity Scholarity { get; set; }
    }

    public class UserRetrieveODataModelMapper : IHaveMapper<User, UserRetrieveODataModel>
    {
        private readonly ISpecification<User> _specification;

        public UserRetrieveODataModelMapper(ISpecification<User> specification = null)
        {
            this._specification = specification;
        }

        public Expression<Func<User, UserRetrieveODataModel>> Selector => user => new UserRetrieveODataModel()
        {
            ID = user.ID,
            Checked = false,
            Name = user.Name,
            Surname = user.Surname,
            Mail = user.Mail,
            BirthDate = user.BirthDate,
            Scholarity = user.Scholarity,
        };

        public ISpecification<User> Specification => _specification;
    }
}
