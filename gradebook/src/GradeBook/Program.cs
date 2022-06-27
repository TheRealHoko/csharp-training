// See https://aka.ms/new-console-template for more information
using GradeBook;

var book = new Book("Hoko's Grade Book");

// loop to take
while (true)
{
	Console.WriteLine("Please type a grade or 'q' to quit");
	var input = Console.ReadLine();
	if (input == "q" || input == null)
		break ;
	try
	{
		var grade = double.Parse(input);
		book.AddGrade(grade);
	}
	catch (ArgumentException ex)
	{
		Console.WriteLine(ex.Message);
	}
	catch (FormatException ex)
	{
		Console.WriteLine(ex.Message);
	}
	finally
	{
		Console.WriteLine("**");
	}
}

var stats = book.GetStatistics();
Console.WriteLine($"The lowest grade is {stats.Low:N1}");
Console.WriteLine($"The highest grade is {stats.High:N1}");
Console.WriteLine($"The average grade is {stats.Average:N1}");
Console.WriteLine($"The letter grade is {stats.letter}");

