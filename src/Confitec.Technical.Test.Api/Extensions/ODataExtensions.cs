using Confitec.Technical.Test.Application.UserModule.UserRetrieve;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Confitec.Technical.Test.Api.Extensions
{
    public static class ODataExtensions
    {
        public static void AddODataOptions(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddOData(p =>
            {
                p.AddRouteComponents("v1", GetEdmModel());
                p.Filter();
                p.Select();
                p.Count();
                p.Expand();
                p.SetMaxTop(500);
                p.SkipToken();
                p.OrderBy();
            });
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<UserRetrieveODataModel>("UsersOData").EntityType.HasKey(p => p.ID);

            builder.EnableLowerCamelCase();

            return builder.GetEdmModel();
        }
    }
}
