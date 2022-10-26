namespace BigHomeWorkFromWeb.Models
{
    public class UserModel
    {
        public UserModel() { }
        public UserModel(string _FirstName,string _LastName,int Age) 
        {
            this.FirstName = _FirstName;
            this.LastName = _LastName;
            this.Age = Age;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }     

        public int? AdressId { get; set; }
        public AdressModel Adress { get; set; }
    }
}
