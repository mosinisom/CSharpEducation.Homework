namespace tictactoe;
public class Tictactoe
{
    public bool GameOver { get; private set; }
    public int CurrentPlayer { get; private set; }
    int moveCount = 1;
    Dictionary<int, int> player = new() { { 0, -1 }, { 1, 1 } };
    int[,] board =
    { 
        { 0, 0, 0 }, 
        { 0, 0, 0 }, 
        { 0, 0, 0 } 
    };

    public int[,] Board { get => board; } //!!!

    public int this[int x, int y]
    {
        get => board[x,y];
        set => board[x,y] = value;
    }

    public int GetCell(int x, int y)
    {
        if(x < 0)
        {
            x = 0;
        }
        else if(x > board.GetLength(0) - 1)
        {
            x = board.GetLength(0) - 1;
        }

        if (y < 0)
        {
            y = 0;
        }
        else if (y > board.GetLength(1) - 1)
        {
            y = board.GetLength(1) - 1;
        }

        return board[x, y];
    }

    public void SetCell(int x, int y, int value)
    {
        if(GetCell(x, y) == 0)
        {
            board[x, y] = player[CurrentPlayer];
            checkGameover();
            NextPlayer();
        }
    }

    void NextPlayer()
    {
        moveCount++;
        CurrentPlayer = (CurrentPlayer + 1) % 2;
    }

    void checkGameover()
    {
        if(moveCount < 5)
        {
            return;
        }

        for (int i = 0; i < 3; i++)
        {
            int sum = 0;
            for (int j = 0; j < 3; j++)
            {
                sum += board[i, j];
            }
            if (sum == 3 || sum == -3)
            {
                GameOver = true;
                return;
            }
        }
        
        for (int i = 0; i < 3; i++)
        {
            int sum = 0;
            for (int j = 0; j < 3; j++)
            {
                sum += board[j, i];
            }
            if (sum == 3 || sum == -3)
            {
                GameOver = true;
                return;
            }
        }

        int sumDiagonal = 0;
        for (int i = 0; i < 3; i++)
        {
            sumDiagonal += board[i, i];
        }
        if (sumDiagonal == 3 || sumDiagonal == -3)
        {
            GameOver = true;
            return;
        }

        int sumAntiDiagonal = 0;
        for (int i = 0; i < 3; i++)
        {
            sumAntiDiagonal += board[i, 2 - i];
        }
        if (sumAntiDiagonal == 3 || sumAntiDiagonal == -3)
        {
            GameOver = true;
            return;
        }

        if (moveCount == 9)
        {
            GameOver = true;
        }
        return;
    }
}