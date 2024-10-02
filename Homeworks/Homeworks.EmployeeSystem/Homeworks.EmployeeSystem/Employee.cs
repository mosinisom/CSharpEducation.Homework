using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeworks.EmployeeSystem
{
  /// <summary>
  ///  Описание сущности "Сотрудник".
  /// </summary>
  internal class Employee
  {
    #region Поля и свойства

    /// <summary>
    /// Номер сотрудника
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Должность
    /// </summary>
    public string Position { get; set; }

    /// <summary>
    /// Зарплата за 1 рабочий день
    /// </summary>
    public decimal Salary { get; set; }

    #endregion
  }
}
