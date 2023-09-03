using System;
using System.Collections.Generic;

namespace Calculator_for_user
{
    class Program
    {
        static void Main(string[] args)
        {
            data money = new data();
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("======================");
                Console.WriteLine("1. All money");
                Console.WriteLine("2. Add money");
                Console.WriteLine("3. Expenses money");
                Console.WriteLine("4. Save money");
                Console.WriteLine("5. STOP PROGRAM");
                Console.WriteLine("======================");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AllMoney(ref money);
                        break;
                    case "2":
                        AddMoney(ref money);
                        break;
                    case "3":
                        ExpensesMoney(ref money);
                        break;
                    case "4":
                        SaveMoney(ref money);
                        break;
                    case "5":
                        Console.WriteLine("Thanks goodbye!!!");
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Sorry invalid choice");
                        break;
                }
            }
        }

        static void AllMoney(ref data money)
        {
            Console.Clear();
            Console.WriteLine("======================");
            Console.WriteLine("All money");
            Console.WriteLine("======================");

            Console.WriteLine("Added Money:");
            for (int i = 0; i < money.added__moneyList.Count; i++)
            {
                Console.WriteLine($"- {money.added__moneyList[i]} ({money.name__added})");
            }

            Console.WriteLine("Expenses Money:");
            for (int i = 0; i < money.expenses__moneyList.Count; i++)
            {
                Console.WriteLine($"- {money.expenses__moneyList[i]} ({money.name__expensesList[i]})");
            }

            Console.WriteLine("Save Money:");
            for (int i = 0; i < money.save__moneyList.Count; i++)
            {
                Console.WriteLine($"- {money.save__moneyList[i]} ({money.name__saveList[i]})");
            }

            Console.WriteLine($"Total Money: {money.summa__money}");
            

        }

        static void AddMoney(ref data money)
        {
            Console.Clear();
            Console.WriteLine("======================");
            Console.WriteLine("Add money");
            Console.WriteLine("======================");

            while (!money.CorrectInput)
            {
                Console.Write("Enter money: ");
                string addedAmountStr = Console.ReadLine();
                if (float.TryParse(addedAmountStr, out float enteredMoney))
                {
                    if (enteredMoney < money.MinMoney)
                    {
                        Console.WriteLine("Sorry, you entered too small amount of money.");
                        money.CorrectInput = false;
                    }
                    else if (enteredMoney > money.MaxMoney)
                    {
                        Console.WriteLine("Sorry, maybe you entered a lot of money");
                        money.CorrectInput = false;
                    }
                    else
                    {
                        money.CorrectInput = true;
                        money.added__moneyList.Add(enteredMoney); // Save data to the money object's list
                        money.summa__money += enteredMoney;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            Console.Write("Enter a name for this addition: ");
            string addedName = Console.ReadLine();
            money.name__added = addedName;

            Console.Clear();
        }

        static void ExpensesMoney(ref data money)
        {
            Console.Clear();
            Console.WriteLine("======================");
            Console.WriteLine("Expenses money");
            Console.WriteLine("======================");

            Console.Write("Enter expenses: ");
            float addedAmount = float.Parse(Console.ReadLine());
            Console.Write("Enter expense name: ");
            string expenseName = Console.ReadLine();

            money.expenses__moneyList.Add(addedAmount); // Зберегти дані в списку об'єкта money
            money.name__expensesList.Add(expenseName);
            money.summa__money -= addedAmount;
            Console.Clear();
        }

        static void SaveMoney(ref data money)
        {
            Console.Clear();
            Console.WriteLine("======================");
            Console.WriteLine("Save money");
            Console.WriteLine("======================");

            Console.Write("Enter money to save: ");
            float addedAmount = float.Parse(Console.ReadLine());
            Console.Write("Enter saving goal name: ");
            string saveGoalName = Console.ReadLine();

            money.save__moneyList.Add(addedAmount); // Зберегти дані в списку об'єкта money
            money.name__saveList.Add(saveGoalName);
            money.summa__money -= addedAmount;
            Console.Clear();
        }
    }

    class data
    {
        public long MinMoney = 1;// мінімальна сумма грошей 
        public long MaxMoney = 200000000000; //200_000_000_000 максимальна сумма грошей 
        public bool CorrectInput = false; // проверка
                                           
        public float summa__money; // вся сума грошей
        public string name__added;
        public List<float> added__moneyList = new List<float>(); // дані з AddMoney
        public List<float> expenses__moneyList = new List<float>(); // затрати
        public List<string> name__expensesList = new List<string>(); // назва затрати
        public List<float> save__moneyList = new List<float>(); // збереження
        public List<string> name__saveList = new List<string>(); // мрія на збереження

    }
}

