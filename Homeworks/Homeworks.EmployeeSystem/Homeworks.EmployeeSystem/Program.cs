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
        Console.WriteLine("Система учёта сотрудников");
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
            AddEmployee(employeeManager);
            break;
          case "2":
            UpdateEmployee(employeeManager);
            break;
          case "3":
            GetEmployeeInfo(employeeManager);
            break;
          case "4":
            CalculateSalary(employeeManager);
            break;
          case "5":
            ListAllEmployees(employeeManager);
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

    static void AddEmployee(SystemManager employeeManager)
    {
      Console.Write("Введите id сотрудника: ");
      int id = int.Parse(Console.ReadLine());

      Console.Write("Введите имя сотрудника: ");
      string name = Console.ReadLine();

      Console.Write("Введите должность: ");
      string position = Console.ReadLine();

      Console.Write("Введите зарплату: ");
      decimal salary = decimal.Parse(Console.ReadLine());

      employeeManager.AddEmployee(id, name, position, salary);
      Console.WriteLine("Сотрудник добавлен!!!.");
    }

    static void UpdateEmployee(SystemManager employeeManager)
    {
      Console.Write("Введите id сотрудника: ");
      int id = int.Parse(Console.ReadLine());

      Console.Write("Введите новое имя сотрудника: ");
      string name = Console.ReadLine();

      Console.Write("Введите новую должность: ");
      string position = Console.ReadLine();

      Console.Write("Введите новую (побольше старой) зарплату: ");
      decimal salary = decimal.Parse(Console.ReadLine());

      if (employeeManager.UpdateEmployee(id, name, position, salary))
      {
        Console.WriteLine("Данные успешно обновлены.");
      }
      else
      {
        Console.WriteLine("Сотрудника с таким айди нет :( ");
      }
    }

    static void GetEmployeeInfo(SystemManager employeeManager)
    {
      Console.Write("Введите айди сотрудника: ");
      int id = int.Parse(Console.ReadLine());
      Employee employee = employeeManager.GetEmployeeInfo(id);

      if (employee != null)
      {
        Console.WriteLine($"id: {employee.Id}");
        Console.WriteLine($"Имя: {employee.Name}");
        Console.WriteLine($"Должность: {employee.Position}");
        Console.WriteLine($"Зарплата: {employee.Salary}");
      }
      else
      {
        Console.WriteLine("Не найден.");
      }
    }

    static void CalculateSalary(SystemManager employeeManager)
    {
      Console.Write("Ввведите айди сотрудника, чтобы посчитать зарплату: ");
      int id = int.Parse(Console.ReadLine());
      decimal salary = employeeManager.CalculateSalary(id);

      if (salary != -1)
      {
        Console.WriteLine($"Зарплата за месяц равна {salary}");
      }
      else
      {
        Console.WriteLine("Сотрудник не найден, поищите в офисе.");
      }
    }

    static void ListAllEmployees(SystemManager employeeManager)
    {
      var employees = employeeManager.ListAllEmployees();

      if (employees.Count == 0)
      {
        Console.WriteLine("У вас в компании только вы, и то даже без записи в бд.");
        return;
      }

      foreach (var employee in employees)
      {
        Console.WriteLine($"id: {employee.Id}, Имя: {employee.Name}, Должность: {employee.Position}, Зарплата: {employee.Salary}");
      }
    }
  }
}
