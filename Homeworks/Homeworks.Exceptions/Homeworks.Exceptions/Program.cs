using System;

namespace Homeworks.Exceptions
{
  class Program
  {
    static void Main(string[] args)
    {
      UserManager userManager = new UserManager();
      bool exit = false;

      while (!exit)
      {
        Console.WriteLine("Система управления пользователями");
        Console.WriteLine("1. Добавить пользователя");
        Console.WriteLine("2. Удалить пользователя");
        Console.WriteLine("3. Список пользователей");
        Console.WriteLine("4. Выход");
        Console.Write("Выберите опцию: ");
        string option = Console.ReadLine();

        switch (option)
        {
          case "1":
            AddUser(userManager);
            break;
          case "2":
            RemoveUser(userManager);
            break;
          case "3":
            ListUsers(userManager);
            break;
          case "4":
            exit = true;
            break;
          default:
            Console.WriteLine("Неверная опция.");
            break;
        }
      }
    }

    static void AddUser(UserManager userManager)
    {
      try
      {
        Console.Write("Введите id пользователя: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Введите имя пользователя: ");
        string name = Console.ReadLine();

        Console.Write("Введите возраст пользователя: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Введите пол пользователя (Мужской/Женский): ");
        string gender = Console.ReadLine();

        if (userManager.AddUser(id, name, age, gender))
        {
          Console.WriteLine("Пользователь успешно добавлен.");
        }
        else
        {
          Console.WriteLine("Ошибка при добавлении пользователя. Проверьте введенные данные.");
        }
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

    static void RemoveUser(UserManager userManager)
    {
      try
      {
        Console.Write("Введите id пользователя для удаления: ");
        int id = int.Parse(Console.ReadLine());

        if (userManager.RemoveUser(id))
        {
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

    static void ListUsers(UserManager userManager)
    {
      try
      {
        var users = userManager.ListUsers();

        if (users == null)
        {
          throw new Exception("Списка пользователей нет.");
        }

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
      catch (Exception ex)
      {
        Console.WriteLine($"Произошла ошибка: {ex.Message}");
      }
    }
  }
}
