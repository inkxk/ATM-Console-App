﻿using System;

public class cardHolder
{
    string cardNumber;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNumber, int pin, string firstName, string lastName, double balance)
    {
        this.cardNumber = cardNumber;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getCardNumber()
    {
        return cardNumber;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setCardNumber(string newCardNumber)
    {
        cardNumber = newCardNumber;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank for your $$. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw? ");
            double withdraw = Double.Parse(Console.ReadLine());
            // check if user has enough money
            if (currentUser.getBalance() > withdraw)
            {
                double newBalance = currentUser.getBalance() - withdraw;
                currentUser.setBalance(newBalance);
                Console.WriteLine("You're good to go! Thanks you :)");
            }
            else
            {
                Console.WriteLine("Insufficient balance :(");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1102002993162", 2541, "Potcharapol", "Nokyoo", 300000.00));

        // prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNumber = "";
        cardHolder currentUser;

        // enter card number
        while (true)
        {
            try
            {
                debitCardNumber = Console.ReadLine();
                // check cardNumber
                // มีค่า = function find ถ้าเจอก็ return user มา ถ้าไม่เจอ return null
                currentUser = cardHolders.FirstOrDefault(user => user.cardNumber == debitCardNumber);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again."); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again."); }
        }

        // enter pin
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again."); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again."); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch 
            {
                
            }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; } 
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");
    }
}
