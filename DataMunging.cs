using System;
using System.Collections.Generic;
using System.Linq;


namespace DataMunging
{
    public class DataMunging
    {
        static void Main(string[] args)
        {
            DataMunging dataMunging = new DataMunging(){};
            string smallSpread = dataMunging.DayWithSmallestTempSpread();
            Console.WriteLine(smallSpread);

            string smallScoreSpread = dataMunging.FootballTeamWithSmallestSpread();
            Console.WriteLine(smallScoreSpread);

            //for weather
            var weatherArrayOfRows = dataMunging.ReadInFileToRowArrays(@"C:\weather.dat");
            var weatherSmallestRow = dataMunging.GetRowWithSmallestDifferenceInValues(1,2,weatherArrayOfRows, 0);
            //for soccer game
            var footballArrayOfRows = dataMunging.ReadInFileToRowArrays(@"C:\football.dat"); 
            var footballSmallestRow = dataMunging.GetRowWithSmallestDifferenceInValues(6,8,footballArrayOfRows, 1);

            
            Console.WriteLine(weatherSmallestRow);
            Console.WriteLine(footballSmallestRow);
        }

        //Method for part 1
        public string DayWithSmallestTempSpread()
        {
            //string[] days = System.IO.File.ReadAllLines(@"C:\weather.dat");
            //reads the file and removes new lines/empty lines
            string[] days = System.IO.File.ReadAllLines(@"C:\weather.dat").Where(s => s.Trim() != string.Empty).ToArray();

            //set in to max value so we know we will get the proper difference 
            int smallestTempSpread = int.MaxValue;
            string dayWithSmallestTempSpread = "";

            for (int i = 0; i < days.Length; i++)
            {
                //split the current row into an array so we can grab the day and temps
                string[] dayData = days[i].Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                //the first row and some of the temps have non numberic values in them so we wanna strip em.
                dayData[1] = new string(dayData[1].Where(c => char.IsDigit(c)).ToArray());
                dayData[2] = new string(dayData[2].Where(c => char.IsDigit(c)).ToArray());

                int highTemp;
                int lowTemp;

                //now we have to check that the values were looking at are actual numbers. 
                //If one fails the TryParse, we will Continue, that way the first row gets accounted for and
                //the last row will just finish the loop.
                 if(!(int.TryParse(dayData[1], out highTemp)))
                 {
                    continue;
                 }

                 if (!(int.TryParse(dayData[2], out lowTemp)))
                 {
                     continue;
                 }

                //take the difference
                int tempSpread =  highTemp - lowTemp;

                //compare results
                if (smallestTempSpread > tempSpread)
                {
                    smallestTempSpread = tempSpread;
                    dayWithSmallestTempSpread = dayData[0];
                }
            }

            return dayWithSmallestTempSpread;
        }

        //Method for part 2
        //I left a lot of comments out here because it's extremely similear
        public string FootballTeamWithSmallestSpread()
        {
            //reads the file and removes new lines/empty lines
            string[] teams = System.IO.File.ReadAllLines(@"C:\football.dat").Where(s => s.Trim() != string.Empty).ToArray();

            //set in to max value so we know we will get the proper difference 
            int smallestScoreSpread = int.MaxValue;
            string teamWithSmallestScoreSpread = "";

            for(int i = 0; i < teams.Length; i++)
            {
                //split the current row into an array so we can grab the team data
                string[] teamData = teams[i].Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                if(teamData.Length < 7)
                {
                    continue;
                }

                int goalsScored;
                int goalsAllowed;

                if(!(int.TryParse(teamData[6], out goalsScored)))
                 {
                    continue;
                 }

                 if (!(int.TryParse(teamData[8], out goalsAllowed)))
                 {
                     continue;
                 }

                 //take the difference
                int teamSpread =  Math.Abs(goalsScored - goalsAllowed);

                //compare results
                if (smallestScoreSpread > teamSpread)
                {
                    smallestScoreSpread = teamSpread;
                    teamWithSmallestScoreSpread = teamData[1];
                }

            }

            return teamWithSmallestScoreSpread;
        }


        //---------------------------------------------------------------------------------------//
        //So there's a lot of shared functionality in those two methods
        //I'm going to try to logically break them out to create common functions

        //First thing, reading in the file:
        //This will leave out empty rows, could create a variable to toggle that, will keep it simple for now
        public string[] ReadInFileToRowArrays(string filePath)
        {
            return System.IO.File.ReadAllLines(filePath).Where(s => s.Trim() != string.Empty).ToArray();
        }

        //So, what I want to do here is a difference function, and were going to return the row
        //that has the lowest difference in the file. That way, we don't have to mess with returning 
        //different types, just return the row and grab that row from the file

        //It takes the two rows we want to compare and the file we split into a string array

        //parametr for which column is the one we want to return!!
        public string GetRowWithSmallestDifferenceInValues(int row1, int row2, string[] fileArray, int returnColumn)
        {
            //creating an int to track the smallest value
            int smallestValue = int.MaxValue;

            //creating an in to track the smallest row
            string valueWithSmallestDiff = "";

            for(int i = 0; i < fileArray.Length; i++)
            {
                //this too will remove empty rows
                string[] rowData = fileArray[i].Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                //so without being able to just hardcode to specific file, we will have to do much more validations to 
                //ensure our loop runs smoothly. 

                //so the first validation I want to make sure I don't go out of the bounds of my array when trying to 
                //convert the strings to an int to do calculations. so I'm thinking if the rowData array's length is less than
                //either of our row1 or row2 were comparing, continue the loop.
                if ((rowData.Length <= row1) || (rowData.Length <= row2))
                {
                    continue;
                }

                //now, we want to check the string array just incase there are any non numeric values
                rowData[row1] = new string(rowData[row1].Where(c => char.IsDigit(c)).ToArray());
                rowData[row2] = new string(rowData[row2].Where(c => char.IsDigit(c)).ToArray());

                int highValue;
                int lowValue;

                //now we have to check that the values were looking at are actual numbers. 
                //If one fails the TryParse, we will Continue, that way the first row gets accounted for and
                //the last row will just finish the loop.
                //This is incase there's randome lines in there, or sentences describing the file
                 if(!(int.TryParse(rowData[row1], out highValue)))
                 {
                    continue;
                 }

                 if (!(int.TryParse(rowData[row2], out lowValue)))
                 {
                     continue;
                 }

                 //take the difference
                 //realizing now highValue and lowValue is a bit misleading...
                int spread =  Math.Abs(highValue - lowValue);

                if (smallestValue > spread)
                {
                    smallestValue = spread;
                    valueWithSmallestDiff = rowData[returnColumn];
                }
            }
            return valueWithSmallestDiff;
        }
        
        
    }
}