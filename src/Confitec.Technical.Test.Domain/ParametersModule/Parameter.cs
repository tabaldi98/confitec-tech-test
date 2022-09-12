namespace Confitec.Technical.Test.Domain.ParametersModule
{
    public class Parameter : Entity
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
        public DateTime LastDateUpdated { get; private set; }

        public Parameter()
        {
            LastDateUpdated = DateTime.Now;
        }

        public Parameter(string key, string value)
            : this()
        {
            Key = key;
            Value = value;
        }

        public void UpdateValue(string value)
        {
            Value = value;
            LastDateUpdated = DateTime.Now;
        }

        public static IList<Parameter> GetDefaultParameters()
        {
            return new List<Parameter>()
            {
                new Parameter(ParametersKeys.KEY_SESSION_TIME, "120") { ID = ParametersKeys.ID_SESSION_TIME },
            };
        }
    }
}
