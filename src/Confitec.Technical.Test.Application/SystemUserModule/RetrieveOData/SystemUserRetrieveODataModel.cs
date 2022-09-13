using Confitec.Technical.Test.Domain.Contracts.Mappers;
using Confitec.Technical.Test.Domain.Contracts.Specification;
using Confitec.Technical.Test.Domain.SystemUserModule;
using System.Linq.Expressions;

namespace Confitec.Technical.Test.Application.SystemUserModule.RetrieveOData
{
    public class SystemUserRetrieveODataModel : IODataModelBase
    {
        public int ID { get; set; }
        public bool Checked { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastUpdatePasswordDate { get; set; }
        public bool IsAproved { get; set; }
        public IEnumerable<string> Permissions { get; set; }
    }

    public class SystemUserRetrieveODataModelMapper : IHaveMapper<SystemUser, SystemUserRetrieveODataModel>
    {
        private readonly ISpecification<SystemUser> _specification;

        public SystemUserRetrieveODataModelMapper(ISpecification<SystemUser> specification = null)
        {
            this._specification = specification;
        }

        public Expression<Func<SystemUser, SystemUserRetrieveODataModel>> Selector => user => new SystemUserRetrieveODataModel()
        {
            ID = user.ID,
            Checked = false,
            CreateDate = user.CreateDate,
            LastLoginDate = user.LastLoginDate,
            LastUpdatePasswordDate = user.LastUpdatePasswordDate,
            FullName = user.FullName,
            IsAproved = user.IsAproved,
            Mail = user.Mail,
            UserName = user.UserName,
            Permissions = user.Permissions.Select(p => p.Role),
        };

        public ISpecification<SystemUser> Specification => _specification;
    }
}
