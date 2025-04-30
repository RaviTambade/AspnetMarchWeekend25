using PlatformINterOpApp;

string filePath = @"D:/Todays_mcq.txt";

if (Helper.IsFileLocked(filePath))
{
    Console.WriteLine("File is currently locked by another process.");
}
else
{
    Console.WriteLine("File is free to use.");
}

Console.ReadLine();
