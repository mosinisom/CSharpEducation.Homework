namespace Homeworks.Exceptions
{
  /// <summary>
  /// Описание сущности "Пользователь".
  /// </summary>
  public class User
  {
    #region Поля и свойства

    /// <summary>
    /// Номер пользователя
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Возраст пользователя
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Пол пользователя
    /// </summary>
    public string Gender { get; set; }

    #endregion
  }
}
