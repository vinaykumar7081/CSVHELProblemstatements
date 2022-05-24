using CSVExampleProblem;
using System;
public class Program
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Reading the Data from the File");
        PersonDataManagements data = new PersonDataManagements();
        data.ImplementationCsv();
        data.ImplementationJson();
    }
}