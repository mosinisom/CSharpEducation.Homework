namespace CSharpEducation.Homework.Phonebook;
internal sealed class Abonent
{
  #region Поля и свойства
  public string Name { get; set; }
  public string PhoneNumber { get; set; }
  #endregion


  public Abonent(string name, string phoneNumber)
  {
    this.Name = name;
    this.PhoneNumber = phoneNumber;
  }
}