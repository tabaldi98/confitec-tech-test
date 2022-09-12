namespace Confitec.Technical.Test.Application.SystemUserModule.MyInformations
{
    public class SystemUserMyInformationsModel
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastUpdatePasswordDate { get; set; }
        public IEnumerable<string> Permissions { get; set; }
    }
}
