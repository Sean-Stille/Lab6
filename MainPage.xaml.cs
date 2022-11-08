namespace Lab6Starter;

/**
 * 
 * Name: Sean Stille and Duaa Ahmad
 * Date: 11/7/22
 * Description: A .net Maui Tic Tac Toe game, tracking when someone wins, resetting the game, and keeping score, among other things
 * Bugs: None we're aware of
 * Reflection:	This lab was a great chance to use Git in a much more practical setting. At the end of the day, Git is about collaboration,
 *				so it's great to practice those skills. Outside of just Git, this lab provided practice with working on software that was
 *				started by another developer. Interpretating and adding to another developers work is an essential skill in the world of
 *				software engineering, making the experience this lab provided all the more useful.
 * 
 */

using Lab6Starter;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;


/// <summary>
/// The MainPage, this is a 1-screen app
/// </summary>
public partial class MainPage : ContentPage
{
    Stopwatch stopWatch = new Stopwatch();
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
        stopWatch.Start();
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
        stopWatch.Stop();
        TimeSpan timeSpan = stopWatch.Elapsed;
        DisplayAlert("Winner!", String.Format("Congratulations, {0}, you're the big winner today! Time elapsed: {1}", victor.ToString(), String.Format("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds), stopWatch.Elapsed), "OK");
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

        stopWatch.Start();
    }

}



