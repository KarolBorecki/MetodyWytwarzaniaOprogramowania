namespace Clients
{
    public class Client : IClient
    {
        private string id;
        private string name;
        private string surname;
        private string email;

        public Client(string id, string name, string surname, string email)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.email = email;
        }

        public string GetID()
        {
            return id;
        }
        public string GetName()
        {
            return name;
        }
        public string GetSurname()
        {
            return surname;
        }
        public string GetEmail()
        {
            return email;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetSurname(string surname)
        {
            this.surname = surname;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }
    }
}