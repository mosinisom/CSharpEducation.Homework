using System;
using System.Collections.Generic;

namespace Homeworks.Exceptions
{
  public class UserManager
  {
    #region Поля и свойства
    private List<User> users = new List<User>();
    #endregion

    #region Методы
    public void AddUser()
    {
      try
      {
        Console.Write("Введите id пользователя: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Введите имя пользователя: ");
        string name = Console.ReadLine();

        Console.Write("Введите возраст пользователя: ");
        int age = int.Parse(Console.ReadLine());
        if (age < 18 || age > 90)
        {
          Console.WriteLine("Возраст пользователя должен быть от 18 до 90 лет.");
          return;
        }

        Console.Write("Введите пол пользователя (Мужской/Женский): ");
        string gender = Console.ReadLine();
        if (gender.ToLower() != "мужской" && gender.ToLower() != "женский")
        {
          Console.WriteLine("Неверный пол. Пожалуйста, введите 'Мужской' или 'Женский'.");
          return;
        }

        users.Add(new User { Id = id, Name = name, Age = age, Gender = gender });
        Console.WriteLine("Пользователь успешно добавлен.");
      }
      catch (FormatException)
      {
        Console.WriteLine("Неверный формат ввода. Пожалуйста, введите корректные данные.");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Произошла ошибка: {ex.Message}");
      }
    }

    public void RemoveUser()
    {
      try
      {
        Console.Write("Введите id пользователя для удаления: ");
        int id = int.Parse(Console.ReadLine());
        User user = users.Find(u => u.Id == id);

        if (user != null)
        {
          users.Remove(user);
          Console.WriteLine("Пользователь успешно удален.");
        }
        else
        {
          Console.WriteLine("Пользователь не найден.");
        }
      }
      catch (FormatException)
      {
        Console.WriteLine("Неверный формат ввода. Пожалуйста, введите корректный ID.");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Произошла ошибка: {ex.Message}");
      }
    }

    public void ListUsers()
    {
      if (users.Count == 0)
      {
        Console.WriteLine("Пользователи не найдены.");
        return;
      }

      foreach (var user in users)
      {
        Console.WriteLine($"id: {user.Id}, Имя: {user.Name}, Возраст: {user.Age}, Пол: {user.Gender}");
      }
    }
    #endregion
  }
}
