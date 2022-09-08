namespace Confitec.Technical.Test.Application.SystemUserModule.Login
{
    public class SystemUserLoginModel
    {
        public string AccessToken { get; private set; }
        public string TokenType => "bearer";
        public long ExpiresIn { get; private set; }

        public SystemUserLoginModel(string accessToken, long expiresIn)
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
        }
    }
}
