// See https://aka.ms/new-console-template for more information
using GradeBook;

static void EnterGrades(IBook book)
{
	while (true)
	{
		Console.WriteLine("Please type a grade or 'q' to quit");
		var input = Console.ReadLine();
		if (input == "q")
			break;
		try
		{
			ArgumentNullException.ThrowIfNull(input);
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
	}
}

static void OnGradeAdded(object sender, EventArgs e)
{
	Console.WriteLine($"A grade was added");
}

// Main
IBook book = new DiskBook("Hoko's Grade Book");
book.GradeAdded += OnGradeAdded;

// loop to take
EnterGrades(book);

var stats = book.GetStatistics();

Console.WriteLine($"For the book named {book.Name}");
Console.WriteLine($"The lowest grade is {stats.Low:N1}");
Console.WriteLine($"The highest grade is {stats.High:N1}");
Console.WriteLine($"The average grade is {stats.Average:N1}");
Console.WriteLine($"The letter grade is {stats.Letter}");




