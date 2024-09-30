using System;
using System;
using System.Collections.Generic;

namespace Homeworks.Exceptions
{
  /// <summary>
  /// Класс для управления пользователями.
  /// </summary>
  public class UserManager
  {
    #region Поля и свойства

    /// <summary>
    /// Список пользователей.
    /// </summary>
    private List<User> users = new List<User>();

    #endregion

    #region Методы

    /// <summary>
    /// Добавляет нового пользователя.
    /// </summary>
    /// <param name="id">ID пользователя.</param>
    /// <param name="name">Имя пользователя.</param>
    /// <param name="age">Возраст.</param>
    /// <param name="gender">Пол.</param>
    /// <returns>True, если пользователь успешно добавлен, иначе false.</returns>
    public bool AddUser(int id, string name, int age, string gender)
    {
      if (age < 18 || age > 90)
      {
        return false;
      }

      if (gender.ToLower() != "мужской" && gender.ToLower() != "женский")
      {
        return false;
      }

      users.Add(new User { Id = id, Name = name, Age = age, Gender = gender });
      return true;
    }

    /// <summary>
    /// Удаляет пользователя.
    /// </summary>
    /// <param name="id">ID пользователя.</param>
    /// <returns>True, если пользователь успешно удалён, иначе false.</returns>
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
    /// Получение списка всех пользователей.
    /// </summary>
    /// <returns>Список всех пользователей.</returns>
    public List<User> ListUsers()
    {
      return users;
    }

    #endregion
  }
}
