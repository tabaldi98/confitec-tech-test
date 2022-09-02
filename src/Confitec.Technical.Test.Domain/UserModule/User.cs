namespace Confitec.Technical.Test.Domain.UserModule
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Mail { get; private set; }
        public DateTime BirthDate { get; private set; }
        public UserScholarity Scholarity { get; private set; }

        private User()
        { }

        public User(string name, string surname, string mail, DateTime birthDate, UserScholarity scholarity)
        {
            SetFullName(name, surname);
            SetMail(mail);
            SetBirthDate(birthDate);
            SetScholarity(scholarity);
        }

        public void SetFullName(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public void SetMail(string mail)
        {
            Mail = mail;
        }

        public void SetBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
        }

        public void SetScholarity(UserScholarity scholarity)
        {
            Scholarity = scholarity;
        }
    }
}
