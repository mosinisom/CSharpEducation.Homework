using System;
using System.Collections.Generic;

namespace Homeworks.Exceptions
{
  public class UserManager
  {
    #region ���� � ��������
    private List<User> users = new List<User>();
    #endregion

    #region ������
    public void AddUser()
    {
      try
      {
        Console.Write("������� id ������������: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("������� ��� ������������: ");
        string name = Console.ReadLine();

        Console.Write("������� ������� ������������: ");
        int age = int.Parse(Console.ReadLine());
        if (age < 18 || age > 90)
        {
          Console.WriteLine("������� ������������ ������ ���� �� 18 �� 90 ���.");
          return;
        }

        Console.Write("������� ��� ������������ (�������/�������): ");
        string gender = Console.ReadLine();
        if (gender.ToLower() != "�������" && gender.ToLower() != "�������")
        {
          Console.WriteLine("�������� ���. ����������, ������� '�������' ��� '�������'.");
          return;
        }

        users.Add(new User { Id = id, Name = name, Age = age, Gender = gender });
        Console.WriteLine("������������ ������� ��������.");
      }
      catch (FormatException)
      {
        Console.WriteLine("�������� ������ �����. ����������, ������� ���������� ������.");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"��������� ������: {ex.Message}");
      }
    }

    public void RemoveUser()
    {
      try
      {
        Console.Write("������� id ������������ ��� ��������: ");
        int id = int.Parse(Console.ReadLine());
        User user = users.Find(u => u.Id == id);

        if (user != null)
        {
          users.Remove(user);
          Console.WriteLine("������������ ������� ������.");
        }
        else
        {
          Console.WriteLine("������������ �� ������.");
        }
      }
      catch (FormatException)
      {
        Console.WriteLine("�������� ������ �����. ����������, ������� ���������� ID.");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"��������� ������: {ex.Message}");
      }
    }

    public void ListUsers()
    {
      if (users.Count == 0)
      {
        Console.WriteLine("������������ �� �������.");
        return;
      }

      foreach (var user in users)
      {
        Console.WriteLine($"id: {user.Id}, ���: {user.Name}, �������: {user.Age}, ���: {user.Gender}");
      }
    }
    #endregion
  }
}
