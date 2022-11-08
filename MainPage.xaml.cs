namespace Lab6Starter;

using System.Diagnostics;
/**
 * 
 * Name: 
 * Date: How about this?
 * Description:
 * Bugs:
 * Reflection:
 * 
 */

using Lab6Starter;
using Microsoft.Maui.Controls;


/// <summary>
/// The MainPage, this is a 1-screen app
/// </summary>
public partial class MainPage : ContentPage
{
    TicTacToeGame ticTacToe; // model class
    Button[,] grid;          // stores the buttons
    static Random random = new Random();
    Brush brush;


    /// <summary>
    /// initializes the component
    /// </summary>
    public MainPage()
    {
        InitializeComponent();
        ticTacToe = new TicTacToeGame();
        grid = new Button[TicTacToeGame.GRID_SIZE, TicTacToeGame.GRID_SIZE] { { Tile00, Tile01, Tile02 }, { Tile10, Tile11, Tile12 }, { Tile20, Tile21, Tile22 } };

        for(int i = 0; i < TicTacToeGame.GRID_SIZE; i++)
        {
            for (int j = 0; j < TicTacToeGame.GRID_SIZE; j++)
            {
                brush = new SolidColorBrush(Color.FromRgb(random.Next(1, 255), random.Next(125, 255), random.Next(200, 255)));
                grid[i, j].Background = brush;
            }
        }
    }


    /// <summary>
    /// Handles button clicks - changes the button to an X or O (depending on whose turn it is)
    /// Checks to see if there is a victory - if so, invoke 
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleButtonClick(object sender, EventArgs e)
    {
        Player victor;
        Player currentPlayer = ticTacToe.CurrentPlayer;

        Button button = (Button)sender;
        int row;
        int col;

        FindTappedButtonRowCol(button, out row, out col);
        if (button.Text.ToString() != "")
        { // if the button has an X or O, bail
            DisplayAlert("Illegal move", "You must choose an empty tile", "OK");
            return;
        }
        button.Text = currentPlayer.ToString();
        Boolean gameOver = ticTacToe.ProcessTurn(row, col, out victor);

        if (gameOver)
        {
            CelebrateVictory(victor);

        }
    }

    /// <summary>
    /// Returns the row and col of the clicked row
    /// There used to be an easier way to do this ...
    /// </summary>
    /// <param name="button"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    private void FindTappedButtonRowCol(Button button, out int row, out int col)
    {
        row = -1;
        col = -1;

        for (int r = 0; r < TicTacToeGame.GRID_SIZE; r++)
        {
            for (int c = 0; c < TicTacToeGame.GRID_SIZE; c++)
            {
                if(button == grid[r, c])
                {
                    row = r;
                    col = c;
                    return;
                }
            }
        }
        
    }


    /// <summary>
    /// Celebrates victory, displaying a message box and resetting the game
    /// </summary>
    private void CelebrateVictory(Player victor)
    {
        DisplayAlert("Winner!", String.Format("Congratulations, {0}, you're the big winner today!", victor.ToString()), "OK");
        XScoreLBL.Text = String.Format("X's Score: {0}", ticTacToe.XScore);
        OScoreLBL.Text = String.Format("O's Score: {0}", ticTacToe.OScore);

        ResetGame();
    }

    /// <summary>
    /// Resets the grid buttons so their content is all "", also randomizes the color of each tile
    /// </summary>
    private void ResetGame()
    {
                                                                        // Color randomizing nested loops
        for (int i = 0; i < TicTacToeGame.GRID_SIZE; i++)
        {
            for (int j = 0; j < TicTacToeGame.GRID_SIZE; j++)
            {
                brush = new SolidColorBrush(Color.FromRgb(random.Next(1, 255), random.Next(125, 255), random.Next(200, 255)));
                grid[i, j].Background = brush;                          // Line above generates random color, this line assigns it to the tile
            }   
        }
                                                                        // Resetting tiles to be empty nested loops
        for (int i = 0; i < TicTacToeGame.GRID_SIZE; i++)
        {
            for (int j = 0; j < TicTacToeGame.GRID_SIZE; j++)
            {
                grid[i, j].Text = string.Empty;
            }
        }
    }

}



