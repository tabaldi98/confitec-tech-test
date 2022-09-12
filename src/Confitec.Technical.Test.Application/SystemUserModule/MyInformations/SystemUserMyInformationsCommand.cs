using MediatR;

namespace Confitec.Technical.Test.Application.SystemUserModule.MyInformations
{
    public class SystemUserMyInformationsCommand : IRequest<SystemUserMyInformationsModel>
    {
        public int ID { get; private set; }

        public SystemUserMyInformationsCommand(int userid)
        {
            ID = userid;
        }
    }
}
