namespace Clients 
{
    public interface IClient 
    {
        public string GetID();
        public string GetName();
        public string GetSurname();
        public string GetEmail();

        public void SetName(string name);
        public void SetSurname(string surname);
        public void SetEmail(string email);
    }
}