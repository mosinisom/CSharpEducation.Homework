namespace CSharpEducation.Homework.Tictactoe;
internal sealed class Tictactoe
{
  #region Поля и свойства
  public bool IsGameOver { get; private set; }
  public int CurrentPlayer { get; private set; }
  int moveCount = 1;
  Dictionary<int, int> player = new() { { 0, -1 }, { 1, 1 } };
  int[,] board =
  {
        { 0, 0, 0 },
        { 0, 0, 0 },
        { 0, 0, 0 }
    };

  public int[,] Board { get => board; }

  public int this[int x, int y]
  {
    get => this.board[x, y];

    set => this.board[x, y] = value;
  }
  #endregion

  #region Методы
  public int GetCell(int x, int y)
  {
    if (x < 0)
      x = 0;
    else if (x > this.board.GetLength(0) - 1)
      x = this.board.GetLength(0) - 1;

    if (y < 0)
      y = 0;
    else if (y > this.board.GetLength(1) - 1)
      y = this.board.GetLength(1) - 1;

    return this.board[x, y];
  }

  public void SetCell(int x, int y, int value)
  {
    if (GetCell(x, y) == 0)
    {
      this.board[x, y] = this.player[CurrentPlayer];
      СheckGameover();
      NextPlayer();
    }
  }

  void NextPlayer()
  {
    this.moveCount++;
    this.CurrentPlayer = (this.CurrentPlayer + 1) % 2;
  }

  void СheckGameover()
  {
    if (this.moveCount < 5)
      return;

    for (int i = 0; i < 3; i++)
    {
      int sum = 0;
      for (int j = 0; j < 3; j++)
        sum += this.board[i, j];

      if (sum == 3 || sum == -3)
      {
        this.IsGameOver = true;
        return;
      }
    }

    for (int i = 0; i < 3; i++)
    {
      int sum = 0;
      for (int j = 0; j < 3; j++)
        sum += board[j, i];

      if (sum == 3 || sum == -3)
      {
        this.IsGameOver = true;
        return;
      }
    }

    int sumDiagonal = 0;
    for (int i = 0; i < 3; i++)
      sumDiagonal += board[i, i];

    if (sumDiagonal == 3 || sumDiagonal == -3)
    {
      this.IsGameOver = true;
      return;
    }

    int sumAntiDiagonal = 0;
    for (int i = 0; i < 3; i++)
      sumAntiDiagonal += board[i, 2 - i];
    
    if (sumAntiDiagonal == 3 || sumAntiDiagonal == -3)
    {
      this.IsGameOver = true;
      return;
    }

    if (moveCount == 9)
    {
      this.IsGameOver = true;
    }
    return;
    #endregion
  }
}