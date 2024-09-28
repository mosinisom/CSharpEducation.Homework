using System;
using System.Collections.Generic;

namespace Homeworks.EmployeeSystem
{
  internal class SystemManager
  {
    #region Поля и свойства
    private List<Employee> employees = new List<Employee>();
    #endregion

    #region Методы
    public void AddEmployee()
    {
      Console.Write("Введите id сотрудника: ");
      int id = int.Parse(Console.ReadLine());

      Console.Write("Введите имя сотрудника: ");
      string name = Console.ReadLine();

      Console.Write("Введите должность: ");
      string position = Console.ReadLine();

      Console.Write("Введите зарплату: ");
      decimal salary = decimal.Parse(Console.ReadLine());

      employees.Add(new Employee { Id = id, Name = name, Position = position, Salary = salary });
      Console.WriteLine("Сотрудник добавлен!!!.");
    }

    public void UpdateEmployee()
    {
      Console.Write("Введите id сотрудника: ");
      int id = int.Parse(Console.ReadLine());
      Employee employee = employees.Find(e => e.Id == id);

      if (employee != null)
      {
        Console.Write("Введите новое имя сотрудника: ");
        employee.Name = Console.ReadLine();

        Console.Write("Введите новую должность: ");
        employee.Position = Console.ReadLine();

        Console.Write("Введите новую (побольше старой) зарплату: ");
        employee.Salary = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Данные успешно обновлены.");
      }
      else
      {
        Console.WriteLine("Сотрудника с таким айди нет :( ");
      }
    }

    public void GetEmployeeInfo()
    {
      Console.Write("Введите айди сотрудника: ");
      int id = int.Parse(Console.ReadLine());
      Employee employee = employees.Find(e => e.Id == id);

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

    public void CalculateSalary()
    {
      Console.Write("Ввведите айди сотрудника, чтобы посчитать зарплату: ");
      int id = int.Parse(Console.ReadLine());
      Employee employee = employees.Find(e => e.Id == id);

      if (employee != null)
      {
        Console.WriteLine($"Зарплата {employee.Name} за месяц равна {employee.Salary} * 30 = {employee.Salary * 30}");
      }
      else
      {
        Console.WriteLine("Сотрудник не найден, поищите в офисе.");
      }
    }

    public void ListAllEmployees()
    {
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
    #endregion
  }
}
