namespace phonebook;
internal class Abonent
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public Abonent(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }
}