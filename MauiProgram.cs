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


public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}

