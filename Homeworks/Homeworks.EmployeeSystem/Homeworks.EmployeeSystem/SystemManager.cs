using System;
using System.Collections.Generic;

namespace Homeworks.EmployeeSystem
{
  /// <summary>
  /// Класс для системы управления сотрудников.
  /// </summary>
  internal class SystemManager
  {
    #region Поля и свойства

    /// <summary>
    /// Список сотрудников.
    /// </summary>
    private List<Employee> employees = new List<Employee>();

    #endregion

    #region Методы

    /// <summary>
    /// Добавляет нового сотрудника в систему.
    /// </summary>
    /// <param name="id">ID сотрудника.</param>
    /// <param name="name">Имя сотрудника.</param>
    /// <param name="position">Должность сотрудника.</param>
    /// <param name="salary">Зарплата сотрудника.</param>
    public void AddEmployee(int id, string name, string position, decimal salary)
    {
      employees.Add(new Employee { Id = id, Name = name, Position = position, Salary = salary });
    }

    /// <summary>
    /// Обновляет данные существующего сотрудника.
    /// </summary>
    /// <param name="id">ID сотрудника.</param>
    /// <param name="name">Новое имя сотрудника.</param>
    /// <param name="position">Новая должность сотрудника.</param>
    /// <param name="salary">Новая зарплата сотрудника.</param>
    /// <returns>True, если сотрудник найден и обновлен, иначе false.</returns>
    public bool UpdateEmployee(int id, string name, string position, decimal salary)
    {
      Employee employee = employees.Find(e => e.Id == id);

      if (employee != null)
      {
        employee.Name = name;
        employee.Position = position;
        employee.Salary = salary;
        return true;
      }
      return false;
    }

    /// <summary>
    /// Получает информацию о сотруднике по его ID.
    /// </summary>
    /// <param name="id">ID сотрудника.</param>
    /// <returns>Сотрудник, если найден, иначе null.</returns>
    public Employee GetEmployeeInfo(int id)
    {
      return employees.Find(e => e.Id == id);
    }

    /// <summary>
    /// Рассчитывает месячную зарплату сотрудника.
    /// </summary>
    /// <param name="id">ID сотрудника.</param>
    /// <returns>Месячная зарплата сотрудника, если найден, иначе -1.</returns>
    public decimal CalculateSalary(int id)
    {
      Employee employee = employees.Find(e => e.Id == id);

      if (employee != null)
      {
        return employee.Salary * 30;
      }
      return -1;
    }

    /// <summary>
    /// Выводит список всех сотрудников.
    /// </summary>
    /// <returns>Список всех сотрудников.</returns>
    public List<Employee> ListAllEmployees()
    {
      return employees;
    }

    #endregion
  }
}
