using Homeworks.EmployeeSystem;
using System;

namespace Homeworks.EmployeeSystem
{
  class Program
  {
    static void Main(string[] args)
    {
      SystemManager employeeManager = new SystemManager();
      bool exit = false;

      while (!exit)
      {
        Console.WriteLine("Система учёта сотрудников (еле работает)");
        Console.WriteLine("1. Добавить сотрудника");
        Console.WriteLine("2. Изменить информацию о сотруднике");
        Console.WriteLine("3. Вывести информацию об одном сотруднике");
        Console.WriteLine("4. Посчитать зарплату одного сотрудника за месяц");
        Console.WriteLine("5. Вывести список всех сотрудников");
        Console.WriteLine("6. Выйти");
        Console.Write("Выбери пункт меню: ");
        string option = Console.ReadLine();

        switch (option)
        {
          case "1":
            employeeManager.AddEmployee();
            break;
          case "2":
            employeeManager.UpdateEmployee();
            break;
          case "3":
            employeeManager.GetEmployeeInfo();
            break;
          case "4":
            employeeManager.CalculateSalary();
            break;
          case "5":
            employeeManager.ListAllEmployees();
            break;
          case "6":
            exit = true;
            break;
          default:
            Console.WriteLine("Нет такого пункта меню, давай ещё раз (попытки не ограничены, тут цикл while).");
            break;
        }
      }
    }
  }
}