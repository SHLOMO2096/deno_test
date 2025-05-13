using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> series = TryGetSeriesFromArgs();

            if (series == null)
            {
                series = GetSeriesFromUser();
            }
            int choice = 0;
            do
            {
                choice = ShowMenu();
                HandlingUserSelection(choice);
                Console.WriteLine();
                Console.WriteLine();
            }
            while (choice != 10);


            List<int> TryGetSeriesFromArgs()
            {
                List<int> argslist = new List<int>();
                foreach (string arg in args)
                {
                    if (int.TryParse(arg, out int num) && (num > 0))
                    {
                        argslist.Add(num);
                    }
                    else
                    {
                        return null;
                    }
                }
                if (argslist.Count >= 3)
                {
                    series = argslist;
                    return series;
                }
                else
                {
                    return null;
                }
            }

            List<int> GetSeriesFromUser()//בקשת קלט מהמשתמש והפיכתה לרשימה
            {
                series.Clear();
                series = new List<int>();
                while (series.Count < 3)
                {
                    Console.WriteLine("Enter at least three positive numbers separated by commas.");
                    string input = Console.ReadLine();
                    string[] ListString = input.Split(',');
                    foreach (string str in ListString)
                    {
                        if (int.TryParse(str, out int num) && (num > 0))
                        {
                            series.Add(num);
                        }
                        else
                        {
                            series.Clear();
                            Console.WriteLine("Invalid input!!");
                            break;
                        }
                    }

                }
                return series;
            }

            int ShowMenu()//הדפסת התפריט 
            {
                int input = 0;
                
                Console.WriteLine("Select a number from the menu (1-10)");
                Console.WriteLine("1. Input a Series. (Replace the current series)");    
                Console.WriteLine("2. Display the series in the order it was entered.");
                Console.WriteLine("3. Display the series in the reversed order it was entered.");
                Console.WriteLine("4. Display the series in sorted order (from low to high).");
                Console.WriteLine("5. Display the Max value of the series.");
                Console.WriteLine("6. Display the Min value of the series.");
                Console.WriteLine("7. Display the Average of the series.");
                Console.WriteLine("8. Display the Number of elements in the series.");
                Console.WriteLine("9. Display the Sum of the series.");
                Console.WriteLine("10. Exit.");
                int.TryParse(Console.ReadLine(), out input);
                return input;
            }

            void HandlingUserSelection(int Selection)//טיפול בבחירת המשתמש
            {
                switch (Selection)
                {
                    case 1:
                        GetSeriesFromUser();
                        break;
                    case 2:
                        ShowSeries(series);
                        break;
                    case 3:
                        ShowReversed(series);
                        break;
                    case 4:
                        ShowSorted(series);
                        break;
                    case 5:
                        GetMax(series);
                        break;
                    case 6:
                        GetMin(series);
                        break;
                    case 7:
                        GetAverage();
                        break;
                    case 8:
                        length(series);
                        break;
                    case 9:
                        GetSum(series);
                        break;
                    default:
                        Console.WriteLine("Invalid input!!");
                        break;
                }

            }

            void ShowSeries(List<int> _list)//הדפסת הרשימה 2
            {
                foreach (int i in _list)
                {
                    Console.Write(i + ",");
                }
            }

            void ShowReversed(List<int> _list)//3הדפסת הרשימה ברוורס
            {
                for (int i = _list.Count - 1; i >= 0; i--)
                {
                    Console.Write(_list[i] + ",");
                }

            }

            void ShowSorted(List<int> _list)//4הדפסת הרשימה בסדר ממוין
            {
                List<int> SortList = new List<int>(_list);
                SortList.Sort();
                foreach (int i in SortList)
                {
                    Console.Write(i + ",");
                }
            }


            void GetMax(List<int> _list)//5מציאת האיבר המקסימלי והדפסתו
            {
                int max = 0;
                foreach (int i in _list)
                {
                    max = _list[0];
                    if (i > max)
                    {
                        max = i;
                    }
                }
                Console.WriteLine(max);
            }

            void GetMin(List<int> _list)//6מציאת האיבר המינמלי והדפסתו
            {
                int min = 0;
                foreach (int i in _list)
                {
                    min = _list[0];
                    if (i < min)
                    {
                        min = i;
                    }
                }
                Console.WriteLine(min);
            }
            void GetAverage()//הדפסת ממוצע של הרשימה7
            {
                int sum = GetSum(series);
                int average = sum / series.Count;
                Console.WriteLine(average);
            }

            void length(List<int> _list)//8הדפסת כמות האיברים ברשימה
            {
                int len = 0;
                foreach (int i in _list)
                {
                    len++;
                }
                Console.WriteLine(len);
            }

            int GetSum(List<int> _list)//9הדפסת סכום האיברים ברשימה
            {
                int sum = 0;
                foreach (int i in _list)
                    sum += i;
                Console.WriteLine(sum);
                return sum;
            }

















        }
    }
}
