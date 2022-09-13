namespace Confitec.Technical.Test.Infra.Crosscutting.RabbitMq
{
    public static class RabbitMqConstants
    {
        public const string EXCHANGE_MAIL_RECOVERY = "mail.recovery";
        public const string QUEUE_MAIL_RECOVERY = "mail.recovery.send";
        public const string ROUTING_KEY_MAIL_RECOVERY = "mail.recovery";

        public const string EXCHANGE_SYSTEM_USER_CREATED = "mail.system.user.create";
        public const string QUEUE_SYSTEM_USER_CREATED = "mail.system.user.created.send";
        public const string ROUTING_KEY_SYSTEM_USER_CREATE = "mail.system.user.create";
    }
}
