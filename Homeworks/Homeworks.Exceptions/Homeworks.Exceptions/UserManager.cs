using System;
using System.Collections.Generic;

namespace Homeworks.Exceptions
{
  /// <summary>
  /// ����� ��� ���������� ��������������.
  /// </summary>
  public class UserManager
  {
    #region ���� � ��������

    /// <summary>
    /// ������ �������������.
    /// </summary>
    private List<User> users = new List<User>();

    #endregion

    #region ������

    /// <summary>
    /// ��������� ������ ������������.
    /// </summary>
    /// <param name="id">ID ������������.</param>
    /// <param name="name">��� ������������.</param>
    /// <param name="age">�������.</param>
    /// <param name="gender">���.</param>
    /// <returns>True, ���� ������������ ������� ��������, ����� false.</returns>
    public bool AddUser(int id, string name, int age, string gender)
    {
      if (age < 18 || age > 90)
      {
        return false;
      }

      if (gender.ToLower() != "�������" && gender.ToLower() != "�������")
      {
        return false;
      }

      users.Add(new User { Id = id, Name = name, Age = age, Gender = gender });
      return true;
    }

    /// <summary>
    /// ������� ������������.
    /// </summary>
    /// <param name="id">ID ������������.</param>
    /// <returns>True, ���� ������������ ������� �����, ����� false.</returns>
    public bool RemoveUser(int id)
    {
      User user = users.Find(u => u.Id == id);

      if (user != null)
      {
        users.Remove(user);
        return true;
      }
      return false;
    }

    /// <summary>
    /// ��������� ������ ���� �������������.
    /// </summary>
    /// <returns>������ ���� �������������.</returns>
    public List<User> ListUsers()
    {
      return users;
    }

    #endregion
  }
}
