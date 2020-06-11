using System;
using System.Collections.Generic;
class Numbers
{
    List<int> numbers = new List<int>();
    public string enteredValue;
    public int upperLimit;

    public string choice;
    



    public void Start()
    {
        Console.WriteLine("What is the upper limit for the numbers being drawn?");
        enteredValue = Console.ReadLine();



        if (int.TryParse(enteredValue, out int temp))
        {
            upperLimit = temp;
            if (upperLimit < 0)
            {
                Console.WriteLine("the Value you have entered in negative, please enter positive value");
                Start();


            }
            else
            {
                Main();
            }
        }
        else
        {
            Console.WriteLine("The value you have entered is not a number, please enter a number");
            Start();
        }
    }
    public void Main()
    {
        Console.WriteLine("Welcome to the Swinburne Bingo Club");
        Console.WriteLine("1. Draw next number");
        Console.WriteLine("2. View all drawn numbers");
        Console.WriteLine("3. Check specific number");
        Console.WriteLine("4. exit");
        var userSelection = Console.ReadLine();
        
        switch (userSelection)
        {
            case "1":
                DrawNumber();
                break;
            case "2":
                ShowNumbersDrawn();
                break;
            case "3":
                CheckSpecificNuumber();
                break;
            case "4":
                Exit();
                break;
         

        }

    }

    public void DrawNumber()
    {
        try
        {

            if (this.numbers.Count < upperLimit)
            {
                this.numbers.Add(GetNewRand());

                Console.WriteLine("the number drawn was {0},", this.numbers[this.numbers.Count - 1]);
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();
                Main();
            }
            else
            {
                Console.WriteLine("all numbers have been drawn!");
            }
        
        }
        catch (Exception e)
        {
            Console.WriteLine("yayaya " + e.Message);
        }
        return;
    }
    public int GetNewRand()
    {
        Random rand = new Random();
        int g;

        do
        {
            g = rand.Next(1, upperLimit + 1);
        }
        while (this.numbers.IndexOf(g) != -1);
        return g;
    }
    public void ShowNumbersDrawn()
    {
        Console.WriteLine("Would you like to see the numbers in order of being drawn? If so press 1.");
        Console.WriteLine("Would you like to see the numbers in numeric order? If so press 2.");
        Console.WriteLine("If instead you would like to return to mainmenu, press 3.");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                ShowNumbersInOrderDrawn();
                break;
            case "2":
                ShowNumbersInNumericOrder();
                break;
            case "3":
                Main();
                break;
        }

    }

    public void ShowNumbersInOrderDrawn()
    {
        var numberCount = numbers.Count;
        Console.WriteLine("===============");
        for (var i = 0; i < numberCount; i++)
        {
            Console.WriteLine(value: numbers[i]);
            if (i == numbers.Count)
            {
                break;
            }
        }
        Console.WriteLine("===============");
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
        Main();
    }

    public void ShowNumbersInNumericOrder()
    {
        numbers.Sort();
        Console.WriteLine("===============");
        foreach (int x in numbers)
        {
            Console.WriteLine(x);
        }
        Console.WriteLine("===============");
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
        Main();
    }

    public void CheckSpecificNuumber()
    {
        Console.WriteLine("Please enter the number you would like to check.");
        int i = Convert.ToInt32(Console.ReadLine());
        if (numbers.Exists(x => x == i) == true)
            Console.WriteLine("Yes, {0} has been drawn", i);
        else
        {
            Console.WriteLine("No, {0} has not been drawn", i);
        }
        Console.WriteLine("Would you like to check another number? if so press 1");
        Console.WriteLine("Would you like to go back to main menu? if so press 2");
        
        choice = Console.ReadLine();
        
        if (int.TryParse(choice, out int temp))
        {
            
            if (temp == 1)
            {
                CheckSpecificNuumber();


            }
            else
            {
                Main();
            }
        }
        else 
        {
        }
    }

    public void Exit()
    {
        Console.WriteLine("Thank you for playing!");
    }
}