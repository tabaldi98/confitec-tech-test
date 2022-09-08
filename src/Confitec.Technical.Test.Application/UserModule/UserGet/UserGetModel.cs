using Confitec.Technical.Test.Domain.UserModule;

namespace Confitec.Technical.Test.Application.UserModule.UserGet
{
    public class UserGetModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public DateTime BirthDate { get; set; }
        public UserScholarity Scholarity { get; set; }
    }
}
