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
            userManager.AddUser();
            break;
          case "2":
            userManager.RemoveUser();
            break;
          case "3":
            userManager.ListUsers();
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
  }
}

