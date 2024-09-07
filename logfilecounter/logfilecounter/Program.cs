using System;
using System.Collections.Generic;
using System.Globalization;

class LogFileCounter
{
    static void Main()
    {
        // // Initializing a list of tuples to store log file names along with their creation timestamps.
        var logs = new List<(string filename, DateTime createdTime)>
        {
            ("log1234.log", DateTime.Parse("2019-01-01 13:41:21")),
            ("log2913.10g", DateTime.Parse("2019-01-01 15:12:07")),
            ("log3192.10g", DateTime.Parse("2019-01-02 01:53:49")),
            ("log3322.log", DateTime.Parse("2019-01-02 23:30:54")),
            ("log3561.log", DateTime.Parse("2019-01-03 08:01:03")),
            ("log5678.log", DateTime.Parse("2019-01-06 11:27:25")),
            ("10g7890.1og", DateTime.Parse("2019-01-07 03:44:55")),
            ("log8888.log", DateTime.Parse("2019-01-07 19:36:34"))
        };

        // Dictionary to keep track of the number of files created on each date.
        var fileCountByDate = new Dictionary<string, int>();

        // Loop through each log in the list
        foreach (var log in logs)
        {
            // Extract the date in "yyyy-MM-dd" format from the log's created time.
            string date = log.createdTime.ToString("yyyy-MM-dd");

            // If the date is already in the dictionary, increment its count.
            if (fileCountByDate.ContainsKey(date))
            {
                fileCountByDate[date]++;
            }
            else
            {
                // If the date is not in the dictionary, add it with a count of 1.
                fileCountByDate[date] = 1;
            }
        }

        // Define the range of dates to print
        DateTime startDate = DateTime.Parse("2019-01-01");
        DateTime endDate = DateTime.Parse("2019-01-07");

        // Display results
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
        {
            string dateString = date.ToString("yyyy-MM-dd");

            if (fileCountByDate.ContainsKey(dateString))
            {
                Console.WriteLine($"{dateString}: {fileCountByDate[dateString]} files");
            }
            else
            {
                // If no files were created on this date, output 0 files.
                Console.WriteLine($"{dateString}: 0 files");
            }
        }
    }
}
