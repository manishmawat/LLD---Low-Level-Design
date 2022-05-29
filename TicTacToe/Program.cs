// See https://aka.ms/new-console-template for more information
using TicTacToe;

Console.WriteLine("Please enter the name for first player");
string player1Name = Console.ReadLine();
Console.WriteLine("Please enter the character/sign for first player");
string player1Character = Console.ReadLine();

Console.WriteLine("Please enter the name for second player");
string player2Name = Console.ReadLine();
Console.WriteLine("Please enter the character/sign for second player");
string player2Character = Console.ReadLine();

var player1 = new Player.PlayerBuilder().setName(player1Name).setCharacter(player1Character?.Length > 0 ? player1Character : "X").Build();
var player2 = new Player.PlayerBuilder().setName(player2Name).setCharacter(player2Character?.Length > 0 ? player2Character : "O").Build();
var board = new Board.BoardBuilder().setPlayer1(player1).setPlayer2(player2).Build();

Player winner = null;

Player[] players = new Player[2];
players[0] = player1;
players[1] = player2;

int count = 0;

while (count < 9)
{
    Console.WriteLine($"Player {players[count % 2].Name} with {players[count % 2].Character} turn");
    Console.WriteLine($"Select row number in range {String.Join(',', Enumerable.Range(1, 3).ToArray<int>())}");
    int row = Convert.ToInt16(Console.ReadLine());

    Console.WriteLine($"Select col number in range {String.Join(',', Enumerable.Range(1, 3).ToArray<int>())}");
    int col = Convert.ToInt16(Console.ReadLine());
    bool isWinner = board.Move(players[count % 2], row - 1, col - 1);
    if (isWinner)
    {
        winner = players[count % 2];
        break;
    }
    count++;
}

if (winner is not null)
    Console.WriteLine($"Player {winner.Name} is the Winner");
else
    Console.WriteLine("Match is draw");



