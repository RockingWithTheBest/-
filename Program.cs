using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Практика
{
    internal class Library
    {
        #region - Admin Identity Check
        static Passwords[] Admin(string AdminPassword)
        {
            string[] pass = File.ReadAllLines(AdminPassword);
            Passwords[] Administrator = new Passwords[pass.Length];
            for (int i = 0; i < pass.Length; i++)
            {
                string[] AdminArray = pass[i].Split(new char[] { ';' });
                Passwords data;
                data.User_Name = AdminArray[0];
                data.Password = Convert.ToInt32(AdminArray[1]);
                Administrator[i] = data;
            }
            return Administrator;
        }
        #endregion
        #region - User Identity Search
        static void UserSearch(Registrations[] Search, string folder)
        {
            Console.WriteLine("Enter The password of the User.");
            Console.Write("Password: ");
            string userpass = Console.ReadLine();
            Console.WriteLine();
            Registrations[] matchingPass = Array.FindAll(Search, element => element.Userpass == userpass);
            foreach (var item in matchingPass)
            {
                using (StreamReader read = new StreamReader(folder))
                {
                    while (!read.EndOfStream)
                    {
                        string line = read.ReadLine();
                        if (line.Contains(item.Userpass) && line.Contains(item.Group))
                        {
                            Console.WriteLine($"Имя: {item.Names}, ");
                            Console.WriteLine($"Группа: {item.Group}");
                            Console.WriteLine($"Профессия: {item.Occupation}");
                            Console.WriteLine($"Контакт: {item.Contact}");
                            Console.WriteLine($"Принятия: {item.Date_Taken}");
                            Console.WriteLine($"Выдачи: {item.Date_Return}");
                            Console.WriteLine($"Пароль: {item.Userpass}");
                            
                        }
                    }
                }
                
            }
        }
        #endregion
        static void Main(string[] args)
        { 
                Console.SetCursorPosition((Console.WindowWidth - "OWL - One Word Library".Length) / 2, Console.CursorTop + 1);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Добро Пожаловать в OWL");
                Console.ResetColor();
                Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                Console.ForegroundColor= ConsoleColor.Cyan;
                Console.WriteLine("One World Library");
                Console.ResetColor();

            bool exit = false;
            while (!exit)
            {
                #region - Files
                string Users = "Users.txt";
                string AdminPassword = "Admininstartor Password.txt";
                string FashionMagazine_Author = "Magazine fashion-Author.txt";
                string FashionMagazine_Title = "Magazine fashion-Title.txt";
                string FashionMagazine_Year = "Magazine fashion-Year.txt";
                string ClassicBooks_Author = "Classic-Author.txt";
                string ClassicBooks_Title = "Classic-Title.txt";
                string ClassicBooks_Year = "Classic-Year.txt";
                #endregion - Files
                Registrations[] registrations = UserInfor(Users);


                Console.WriteLine("Which User are You? ");
                Console.WriteLine("1. Admininstrator.");
                Console.WriteLine("2. User");
                Console.WriteLine("3. Exit");
                Console.Write("Enter Option: ");
                
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("One World Library");
                        Console.ResetColor();
                        Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Administrator");
                        Console.ResetColor();
                        Console.Write("Enter your Name: ");
                        string AdminName = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        var password = int.Parse(Console.ReadLine());
                        Passwords[] Owner = Admin(AdminPassword);
                        Passwords[] rightAdmin = Array.FindAll(Owner, element => element.Password == password);
                        foreach (var item in rightAdmin)
                        {
                            using (StreamReader reader = new StreamReader(AdminPassword))
                            {
                                while (!reader.EndOfStream)
                                {
                                    string lines = reader.ReadLine();
                                    if (lines.Contains(item.User_Name) && lines.Contains((item.Password).ToString()))
                                    {
                                        Console.Clear();
                                        Console.SetCursorPosition((Console.WindowWidth - "OWL - One Word Library".Length) / 2, Console.CursorTop + 1);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("Добро Пожаловать в OWL Administrator");
                                        Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                                        Console.WriteLine("OWL - One World Library");
                                        Console.ResetColor();
                                        Console.WriteLine("Choose An Action");
                                        Console.WriteLine("1. View All Users");
                                        Console.WriteLine("2. Search for User Information");
                                        Console.WriteLine("3. Add a User Information");
                                        Console.WriteLine("4. Delete User");
                                        Console.WriteLine("5. Exit");
                                        Console.Write("Number Choice: ");
                                        string admin_choice = Console.ReadLine();
                                        switch (admin_choice)
                                        {
                                            case "1":
                                                {
                                                    Console.Clear();
                                                    Console.SetCursorPosition((Console.WindowWidth - "OWL - One Word Library".Length) / 2, Console.CursorTop + 1);
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.WriteLine("Добро Пожаловать в OWL Administrator");
                                                    Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                                                    Console.WriteLine("OWL - One World Library");
                                                    Console.ResetColor();
                                                    Console.WriteLine();
                                                    ShowInfo(registrations);
                                                    Console.WriteLine();
                                                    Console.WriteLine("Press Any KEy to Restart Again");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    //Console.Clear();
                                                }
                                                break;
                                            case "2":
                                                Console.Clear();
                                                Console.SetCursorPosition((Console.WindowWidth - "OWL - One Word Library".Length) / 2, Console.CursorTop + 1);
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.WriteLine("Добро Пожаловать в OWL Administrator");
                                                Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                                                Console.WriteLine("OWL - One World Library");
                                                Console.ResetColor();
                                                UserSearch(registrations, Users);
                                                Console.WriteLine();
                                                Console.WriteLine("Press Any KEy to Restart Again");
                                                Console.ReadKey();
                                                Console.Clear();
                                                break;
                                            case "3":
                                                Console.Clear();
                                                Console.SetCursorPosition((Console.WindowWidth - "OWL - One Word Library".Length) / 2, Console.CursorTop + 1);
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.WriteLine("Добро Пожаловать в OWL Administrator");
                                                Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                                                Console.WriteLine("OWL - One World Library");
                                                Console.ResetColor();
                                                Registration(Users);
                                                Console.WriteLine("Press Any KEy to Restart Again");
                                                Console.ReadKey();
                                                Console.Clear();
                                                break;

                                            case "4":
                                                Console.Clear();
                                                ShowInfo(registrations);
                                                Console.SetCursorPosition((Console.WindowWidth - "OWL - One Word Library".Length) / 2, Console.CursorTop + 1);
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.WriteLine("Добро Пожаловать в OWL Administrator");
                                                Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                                                Console.WriteLine("OWL - One World Library");
                                                Console.ResetColor();
                                                Console.WriteLine();
                                                Console.WriteLine("You want to Delete a User at which index?");
                                                Console.Write("Enter Index: ");
                                                int index = int.Parse(Console.ReadLine());
                                                DeleteUser(ref index, ref registrations);
                                                WritingToFile(Users, registrations);
                                                ShowInfo(registrations);
                                                Console.WriteLine("Успешно удален");
                                                Console.WriteLine("Press Any KEy to Restart Again");
                                                Console.ReadKey();
                                                Console.Clear();
                                                break;
                                              case "5":
                                                Console.Clear();
                                                Console.SetCursorPosition((Console.WindowWidth - "OWL - One Word Library".Length) / 2, Console.CursorTop + 1);
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.WriteLine("Добро Пожаловать в OWL Administrator");
                                                Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                                                Console.WriteLine("OWL - One World Library");
                                                Console.ResetColor(); Console.WriteLine();
                                                Console.WriteLine("Успешно Выходили из Приложение");
                                                exit = true;
                                                break; 

                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong Password!!");
                                    }
                                }
                            }
                        }
                        break;
                    case "2"://USer Menu
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("One World Library");
                        Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                        Console.WriteLine("Добро Пожаловать в OWL User");
                        Console.WriteLine("User Menu");
                        Console.ResetColor();
                        Console.Write("Enter User Name: ");
                        string userName = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        string Userpassword = Console.ReadLine();
                        Registrations[] UserPassword = Array.FindAll(registrations, element => element.Userpass == Userpassword);
                         
                        {
                           // foreach (var passwords in UserPassword)
                            {
                                using (StreamReader reads = new StreamReader(Users))
                                {
                                    string line = reads.ReadLine();
                                    //if (line.Contains(passwords.Userpass) && line.Contains(passwords.Names) && line.Contains(passwords.Group))
                                    {
                                        Console.Clear();
                                        Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("One World Library");
                                        Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                                        Console.WriteLine("User Menu");
                                        Console.ResetColor();
                                        Console.WriteLine("Choose something you want to Read or Do some research on.");
                                        Console.WriteLine("1.Magazine");
                                        Console.WriteLine("2.Book");
                                        Console.Write("Enter Choice: ");
                                        string Userchoice = Console.ReadLine();
                                        switch (Userchoice)
                                        {
                                            case "1":
                                                Magazine_ReadersChoice(FashionMagazine_Author, FashionMagazine_Title, FashionMagazine_Year);
                                                break;
                                            case "2":
                                                Book_ReadersChoice(ClassicBooks_Author, ClassicBooks_Title, ClassicBooks_Year);
                                                break;
                                        }
                                        break;
                                    }
                                    
                                }
                            }
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - "OWL - One Word Library".Length) / 2, Console.CursorTop + 1);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Добро Пожаловать в OWL ");
                        Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                        Console.WriteLine("OWL - One World Library");
                        Console.ResetColor();
                        Console.WriteLine("Успешно Выход из программы");
                        exit = true;
                        break;
                        
                }
            }
        }
        
        static void Book_ReadersChoice(string BookAuthor,string BookTitle,string BookYear)
        {
            #region Files Books
            string DramaBookTitle = "Drama-Title.txt";
            string DramaBookAuthor = "Drama-Author.txt";
            string DrammaBookYear = "Drama-Year.txt";
            string fairyTAuthor = "Fairy Tail-Author.txt";
            string fairyTailTitle ="Fairy Tail-Title.txt";
            string fairyTailYear= "Fairy Tail-Year.txt";
            string ActionAdventAuthor = "Action and Adventure -Author.txt";
            string ActionAdventTitle = "Action and Adventure-Title.txt";
            string ActionAdventYear = "Action and Adventure -Year.txt";
            #endregion
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("One World Library");
            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
            Console.WriteLine("User Menu");
            Console.ResetColor();
            Console.WriteLine("What kind of Book do you want to Read?");
            Console.WriteLine("1. Classic ");
            Console.WriteLine("2. Drama");
            Console.WriteLine("3. Fairy tale");
            Console.WriteLine("4. Action and Adventure");
            Console.Write("Enter Number Choice: ");
            string UserNum = Console.ReadLine();
            switch(UserNum)
            {
                case "1":
                    Console.ForegroundColor= ConsoleColor.Cyan;
                    Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                    Console.WriteLine("Classics Catergory");
                    Console.ResetColor();
                    Console.WriteLine("You Have Chosen a Classics");
                    Console.WriteLine("In What way do you want to View The Classics Books");
                    Console.WriteLine("1. By Author in the First Catergory");
                    Console.WriteLine("2. By Title in the First Catergory");
                    Console.WriteLine("3. By Year in the First Catergory");
                    Console.Write("Enter Choice: ");
                    string sort_choice = Console.ReadLine();
                    switch (sort_choice)
                    {
                        case "1":
                            Books[] YourBook1 = BookChoice_ByAuthorClassics(BookAuthor);
                            Display_Bookby_Author(YourBook1);
                            ChoiceBookSorted_ByAuthor(YourBook1);
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "2":
                            Books[] YourBook2 = BookChoice_ByTitle(BookTitle);
                            Display_Books_byTitle(YourBook2);
                            Books_Sorted_ByTitle(YourBook2);
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();
                            break; 
                        case "3":
                            Books[] YourBook3 = BooksChoice_ByYearClassics(BookYear);
                            Display_Book_byYear(YourBook3);
                            ChoiceBooks_Sorted_ByYear(YourBook3);
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                    break;
                case "2":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("One World Library");
                    Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                    Console.WriteLine("Drama Catergory");
                    Console.ResetColor();
                    Console.WriteLine("You Have Chosen a Classics");
                    Console.WriteLine("In What way do you want to View The Drama Books");
                    Console.WriteLine("1. By Author in the First Catergory");
                    Console.WriteLine("2. By Title in the First Catergory");
                    Console.WriteLine("3. By Year in the First Catergory");
                    Console.Write("Enter Choice: ");
                    string sort_choice_Drama = Console.ReadLine();
                    switch (sort_choice_Drama)
                    {
                        case"1":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("One World Library");
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.WriteLine("Drama Catergory");
                            Books[] DramaChoice = dramaBooks_byAuthor(DramaBookAuthor);
                            Display_BookDramabyAuthor(DramaChoice);
                            Console.WriteLine();
                            ChoiceDramaBook_ByAuthor(DramaChoice);
                            
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case"2":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("One World Library");
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.WriteLine("Drama Catergory");
                            Books[] DramaChoice2 = dramaBooks_byTitle(DramaBookTitle);
                            Display_BookDramabyTitle(DramaChoice2);
                            ChoiceDramaBook_ByTtitle(DramaChoice2);
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case"3":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("One World Library");
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.WriteLine("Drama Catergory");
                            Console.ResetColor();
                            Console.WriteLine();
                            Books[] DramaChoice3 = dramaBooks_byYear(DrammaBookYear);
                            Display_BookDramabyYear(DramaChoice3);
                            Console.WriteLine();
                            ChoiceDramaBook_ByYEar(DramaChoice3);
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                    break;
                case "3":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("One World Library");
                    Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                    Console.WriteLine("Fairy tale Catergory");
                    Console.ResetColor();
                    Console.WriteLine("You Have Chosen a Classics");
                    Console.WriteLine("In What way do you want to View The Classics Books");
                    Console.WriteLine("1. By Author in the First Catergory");
                    Console.WriteLine("2. By Title in the First Catergory");
                    Console.WriteLine("3. By Year in the First Catergory");
                    Console.Write("Enter Choice: ");
                    string sort_choice_FairyTale = Console.ReadLine();
                    switch (sort_choice_FairyTale)
                    {
                        case "1":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("One World Library");
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.WriteLine("Fairy tale Catergory");
                            Console.ResetColor();
                            Books[] fairyTChoice = BookFairyTAuthor(fairyTAuthor);
                            Display_BookDramabyAuthor(fairyTChoice);
                            Console.WriteLine();
                            ChoiceDramaBook_ByAuthor(fairyTChoice);
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                            case "2":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("One World Library");
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.WriteLine("Fairy tale Catergory");
                            Console.ResetColor();
                            Books[] FairyTChoice2  = BookFairyTTitle(fairyTailTitle);
                            Display_BookDramabyTitle(FairyTChoice2);
                            ChoiceDramaBook_ByTtitle(FairyTChoice2);
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                            case "3":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("One World Library");
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.WriteLine("Fairy tale Catergory");
                            Console.ResetColor();
                            Books[] FairyTChoice3 = BookFairyTYEar(fairyTailYear);
                            Display_BookDramabyYear(FairyTChoice3);
                            Console.WriteLine();
                            ChoiceDramaBook_ByYEar(FairyTChoice3);
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                    break; 
                  case "4":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("One World Library");
                    Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                    Console.WriteLine(" Action and Adventure Catergory");
                    Console.ResetColor();
                    Console.WriteLine("You Have Chosen a Classics");
                    Console.WriteLine("In What way do you want to View The Classics Books");
                    Console.WriteLine("1. By Author in the First Catergory");
                    Console.WriteLine("2. By Title in the First Catergory");
                    Console.WriteLine("3. By Year in the First Catergory");
                    Console.Write("Enter Choice: ");
                    string sort_choice_ActionAdventure = Console.ReadLine();
                    switch (sort_choice_ActionAdventure)
                    {
                        case "1":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("One World Library");
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.WriteLine("Action and Adventure Catergory");
                            Console.ResetColor();
                            Books[] BookActAdvent = bookActionAdventureAuthor(ActionAdventAuthor);
                            Display_BookDramabyAuthor(BookActAdvent);
                            Console.WriteLine();
                            ChoiceDramaBook_ByAuthor(BookActAdvent);
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();

                            break;
                        case "2":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("One World Library");
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.WriteLine("Action and Adventure Catergory");
                            Console.ResetColor();
                            Books[] BookActAdvent2 = bookActionAdventureTitle(ActionAdventTitle);
                            Display_BookDramabyTitle(BookActAdvent2);
                            ChoiceDramaBook_ByTtitle(BookActAdvent2);
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                            
                        case "3":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("One World Library");
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.WriteLine("Action and Adventure Catergory");
                            Console.ResetColor();
                            Books[] BookActAdvent3 = bookActionAdventureYear(ActionAdventYear);
                            Display_BookDramabyYear(BookActAdvent3);
                            Console.WriteLine();
                            ChoiceDramaBook_ByYEar(BookActAdvent3);
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                    }
                    break;
            }
        }
        #region -All Books Action and Adventure
        static Books[] bookActionAdventureAuthor(string AuthorAct)
        {
            string []Advent = File.ReadAllLines(AuthorAct);
            Books actAuthor;
            Books[]ArrayAA = new Books[Advent.Length];
            for (int i = 0; i < ArrayAA.Length; i++)
            {
                string[] ActionAdvent = Advent[i].Split(';');
                actAuthor.Author = ActionAdvent[0];
                actAuthor.Title = ActionAdvent[1];
                actAuthor.Year = ActionAdvent[2];
                ArrayAA[i] = actAuthor;
            }
            return ArrayAA;
        }
        static Books[] bookActionAdventureTitle(string TitleAct)
        {
            string[] Advent = File.ReadAllLines(TitleAct);
            Books actAuthor;
            Books[] ArrayAA = new Books[Advent.Length];
            for (int i = 0; i < ArrayAA.Length; i++)
            {
                string[] ActionAdvent = Advent[i].Split(';');
                actAuthor.Title = ActionAdvent[0];
               actAuthor.Author = ActionAdvent[1]; 
                actAuthor.Year = ActionAdvent[2];
                ArrayAA[i] = actAuthor;
            }
            return ArrayAA;
        }
        static Books[] bookActionAdventureYear(string YearAct)
        {
            string[] Advent = File.ReadAllLines(YearAct);
            Books actAuthor;
            Books[] ArrayAA = new Books[Advent.Length];
            for (int i = 0; i < ArrayAA.Length; i++)
            {
                string[] ActionAdvent = Advent[i].Split(';');
                actAuthor.Year = ActionAdvent[0];
                actAuthor.Author = ActionAdvent[1];
                actAuthor.Title = ActionAdvent[2];
                ArrayAA[i] = actAuthor;
            }
            return ArrayAA;
        }

        #endregion
        #region - All Books Fairy Tale
        static Books[] BookFairyTAuthor(string FairyTAuthor)
        {
            string[]Author = File.ReadAllLines(FairyTAuthor);
            Books[] ArryFairyauthor= new Books[Author.Length];
            Books data;
            for (int i = 0; i < ArryFairyauthor.Length; i++)
            {
                string[] Array = Author[i].Split(';');
                data.Author = Array[0];
                data.Title = Array[1];
                data.Year = Array[2];
                ArryFairyauthor[i] = data;
            }
            return ArryFairyauthor;
        }
        static Books[] BookFairyTTitle(string FairyTAuthor)
        {
            string[] Author = File.ReadAllLines(FairyTAuthor);
            Books[] ArryFairyauthor = new Books[Author.Length];
            Books data;
            for (int i = 0; i < ArryFairyauthor.Length; i++)
            {
                string[] Array = Author[i].Split(';');
                data.Title = Array[0];
                data.Author = Array[1];
                data.Year = Array[2];
                ArryFairyauthor[i] = data;
            }
            return ArryFairyauthor;
        }
        static Books[] BookFairyTYEar(string FairyTAuthor)
        {
            string[] Author = File.ReadAllLines(FairyTAuthor);
            Books[] ArryFairyauthor = new Books[Author.Length];
            Books data;
            for (int i = 0; i < ArryFairyauthor.Length; i++)
            {
                string[] Array = Author[i].Split(';');
                data.Year = Array[0];
                data.Author = Array[1];
                data.Title = Array[2];
                ArryFairyauthor[i] = data;
            }
            return ArryFairyauthor;
        }

        #endregion
        #region - All Books Drama
        static void ChoiceDramaBook_ByYEar(Books[] BramaYEar)
        {
            Console.WriteLine("Which Book from the List do you want?");
            Console.Write("Choice: ");
            int index = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"Год: {BramaYEar[index - 1].Year}");
                Console.WriteLine($"Автор :{BramaYEar[index - 1].Author}");
                Console.WriteLine($"Тема: {BramaYEar[index - 1].Title}");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Good and Wise Choice.");
            Console.ResetColor();

        }
        static void ChoiceDramaBook_ByTtitle(Books[] BramaTitle)
        {
            Console.WriteLine("Which Book from the List do you want?");
            Console.Write("Choice: ");
            int index = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 1; i++)
            { 
                Console.WriteLine($"Тема: {BramaTitle[index - 1].Title}");
                Console.WriteLine($"Автор :{BramaTitle[index - 1].Author}");
                Console.WriteLine($"Год: {BramaTitle[index - 1].Year}");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Good and Wise Choice.");
            Console.ResetColor();

        }
        static void ChoiceDramaBook_ByAuthor(Books[] BramaAuthor)
        {
            Console.WriteLine("Which Book from the List do you want?");
            Console.Write("Choice: ");
            int index = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"Автор :{BramaAuthor[index - 1].Author}");
                Console.WriteLine($"Тема: {BramaAuthor[index - 1].Title}");
                Console.WriteLine($"Год: {BramaAuthor[index - 1].Year}");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Good and Wise Choice.");
            Console.ResetColor();

        }
        static void Display_BookDramabyYear(Books[] DramaShowYEar)
        {
            int n = 1;
            for (int i = 0; i < DramaShowYEar.Length; i++)
            {
                Console.WriteLine($"{n}.Год: {DramaShowYEar[i].Year},  Автор: {DramaShowYEar[i].Author},  Тема: {DramaShowYEar[i].Title}"); n++;
            }
        }
        static void Display_BookDramabyTitle(Books[] DramaShowTitle)
        {
            int n = 1;
            for (int i = 0; i < DramaShowTitle.Length; i++)
            {
                Console.WriteLine($"{n}. Тема: {DramaShowTitle[i].Title}"); n++;
            }
        }
        static void Display_BookDramabyAuthor(Books[] DramaShowAuthor)
        {
            int n = 1;
            for (int i = 0; i < DramaShowAuthor.Length; i++)
            {
                Console.WriteLine($"{n}. Автор: {DramaShowAuthor[i].Author}");n++;
            }
        }
        static void ChoiceBook_ByAuthor(Books[] SortchoiceAuthor)
        {
            Console.WriteLine("Which Magazine from the List do you want?");
            Console.Write("Choice: ");
            int index = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"Автор :{SortchoiceAuthor[index - 1].Author}");
                Console.WriteLine($"Тема: {SortchoiceAuthor[index - 1].Title}");
                Console.WriteLine($"Год: {SortchoiceAuthor[index - 1].Year}");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Good and Wise Choice.");
            Console.ResetColor();

        }
        static void Display_BookbyDrama_Author(Books[] ShowDrama)
        {
            int n = 1;
            for (int i = 0; i < ShowDrama.Length; i++)
            {
                Console.WriteLine($"{n}.Автор: {ShowDrama[i].Author}");
                n++;
            }
        }
        static Books[] dramaBooks_byAuthor(string laugh)
        {
            string []Arraylines = File.ReadAllLines(laugh);
            Books[] LaughingDrama = new Books[Arraylines.Length];
            Books charlie;
            for (int i = 0; i < Arraylines.Length; i++)
            {
                string[] charliechapplin = Arraylines[i].Split(new char[] { ';' });
                charlie.Author = charliechapplin[0];
                charlie.Title = charliechapplin[1];
                charlie.Year = charliechapplin[2];
                LaughingDrama[i] = charlie;
            }
            return LaughingDrama;
        }
        static Books[]dramaBooks_byTitle(string laughTitle)
        {
            string []charlie_title = File.ReadAllLines(laughTitle);
            Books[]ArrayBookTitle = new Books[charlie_title.Length];Books laughing;
            for (int i = 0; i < ArrayBookTitle.Length; i++)
            {
                string[] charlie = charlie_title[i].Split(';');
                laughing.Title = charlie[0];
                laughing.Author = charlie[1];
                laughing.Year = charlie[2];
                ArrayBookTitle[i] = laughing; 
            }
            return ArrayBookTitle;
        }
        static Books[] dramaBooks_byYear(string laughTitle)
        {
            string[] charlie_title = File.ReadAllLines(laughTitle);
            Books[] ArrayBookTitle = new Books[charlie_title.Length]; Books laughing;
            for (int i = 0; i < ArrayBookTitle.Length; i++)
            {
                string[] charlie = charlie_title[i].Split(';');
                laughing.Year = charlie[0];
                laughing.Author = charlie[1];
                laughing.Title = charlie[2];
                ArrayBookTitle[i] = laughing;
            }
            return ArrayBookTitle;
        }
        #endregion

        #region - All Books-Classics

        #region - Book-Author
        static Books[] BookChoice_ByAuthorClassics(string AuthorFolder)
        {
            string[] lines = File.ReadAllLines(AuthorFolder);
            int magazineNums = lines.Length;
            Books[] Array = new Books[magazineNums];
            Books data;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] ArrayMag = lines[i].Split(new char[] { ';' });
                data.Author = ArrayMag[0];
                data.Title = ArrayMag[1];
                data.Year = ArrayMag[2];
                Array[i] = data;
            }
            return Array;
        }


        #endregion
        #region - Books-Title
        static Books[] BookChoice_ByTitle(string TitleFolder)
        {
            string[] lines = File.ReadAllLines(TitleFolder);
            int magazineNums = lines.Length;
            Books[] Array = new Books[magazineNums];
            Books data;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] ArrayMag = lines[i].Split(new char[] { ';' });
                data.Title = ArrayMag[0];
                data.Author = ArrayMag[1];
                data.Year = ArrayMag[2];
                Array[i] = data;
            }
            return Array;
        }
        #endregion
        #region - Books-Year
        static Books[] BooksChoice_ByYearClassics(string YearFolder)
        {
            string[] lines = File.ReadAllLines(YearFolder);
            int magazineNums = lines.Length;
            Books[] Array = new Books[magazineNums];
            Books data;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] ArrayMag = lines[i].Split(new char[] { ';' });
                data.Year = ArrayMag[0];
                data.Author = ArrayMag[1];
                data.Title = ArrayMag[2];
                Array[i] = data;
            }
            return Array;
        }
        static void Display_Bookby_Author(Books[] Show)
        {
            int n = 1;
            for (int i = 0; i < Show.Length; i++)
            {
                Console.WriteLine($"{n}.Автор: {Show[i].Author}, Тема: {Show[i].Title}, Год: {Show[i].Year}");
                n++;
            }
        }
        static void Display_Book_byYear(Books[] YearDisplay)
        {
            int n = 1;
            for (int i = 0; i < YearDisplay.Length; i++)
            {
                Console.WriteLine($"{n}. Год:{YearDisplay[i].Year}, Автор:{YearDisplay[i].Author}, Тема:{YearDisplay[i].Title}");
                n++;
            }

        }
        static void Display_Books_byTitle(Books[] TitleDisplay)
        {
            int n = 1;
            for (int i = 0; i < TitleDisplay.Length; i++)
            {
                Console.WriteLine($"{n}. Тема: {TitleDisplay[i].Title}, Автор:{TitleDisplay[i].Author}, Год:{TitleDisplay[i].Year}");
                n++;
            }

        }

        static void ChoiceBookSorted_ByAuthor(Books[] SortchoiceAuthor)
        {
            Console.WriteLine("Which Magazine from the List do you want?");
            Console.Write("Choice: ");
            int index = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"Автор :{SortchoiceAuthor[index - 1].Author}");
                Console.WriteLine($"Тема: {SortchoiceAuthor[index - 1].Title}");
                Console.WriteLine($"Год: {SortchoiceAuthor[index - 1].Year}");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Good and Wise Choice.");
            Console.ResetColor();

        }
        static void ChoiceBooks_Sorted_ByYear(Books[] SortchoiceYear)
        {
            Console.WriteLine("Which Magazine from the List do you want?");
            Console.Write("Choice: ");
            int index = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"Год: {SortchoiceYear[index - 1].Year}");
                Console.WriteLine($"Автор :{SortchoiceYear[index - 1].Author}");
                Console.WriteLine($"Тема: {SortchoiceYear[index - 1].Title}");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Good and Wise Choice.");
            Console.ResetColor();
        }

        static void Books_Sorted_ByTitle(Books[] SortchoiceTitle)
        {
            Console.WriteLine("Which Magazine from the List do you want?");
            Console.Write("Choice: ");
            int index = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"Тема: {SortchoiceTitle[index - 1].Title}");
                Console.WriteLine($"Автор :{SortchoiceTitle[index - 1].Author}");
                Console.WriteLine($"Год: {SortchoiceTitle[index - 1].Year}");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Good and Wise Choice.");
            Console.ResetColor();
        }
        #endregion



        #endregion
        #region - All Detials Magazine
        static void Magazine_ReadersChoice(string MagazineAuthor,string MagazineTitle, string TitleYear)
        {
            #region - Files
            string BusinessMag = "Magazine Business-Title.txt";
            string SportMagaYear = "Magazine Sports-Year.txt";
            string SportMAgaTitle = "Magazine Sports-Title.txt";
            #endregion
            Console.WriteLine("What kind of Magazine do you want to Read?");
            Console.WriteLine("1. Fashion");
            Console.WriteLine("2. Business");
            Console.WriteLine("3. Sports");
            Console.Write("Enter Number Choice: ");
            string UserNum = Console.ReadLine();
            switch(UserNum)
            {
                case "1":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("One World Library");
                    Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                    Console.WriteLine("Magazine Catergory");
                    Console.ResetColor();
                    Console.WriteLine("You Have Chosen a Fashion Magazine");
                    Console.WriteLine("In What way do you want to View The Fashion Magazines");
                    Console.WriteLine("1. By Author in the First Catergory");
                    Console.WriteLine("2. By Title in the First Catergory");
                    Console.WriteLine("3. By Year in the First Catergory");
                    Console.Write("Choice View: ");
                    string sort_choice = Console.ReadLine();
                    switch (sort_choice)
                    {
                        case "1":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("One World Library");
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.WriteLine("Fashion Catergory");
                            Console.ResetColor();
                            Magazines[] YourChoice = MagazineChoiceFashion_ByAuthor(MagazineAuthor);
                            RewritingFashionMagazineByAuthor(MagazineAuthor, YourChoice);
                            Display_Magazine_Fashionby_Author(YourChoice);
                            ChoiceMagazine_Sorted_ByAuthor(YourChoice);
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "2":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("One World Library");
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.WriteLine("Fashion Catergory");
                            Console.ResetColor();
                            Magazines[] YourChoice2 = MagazineChoiceFashion_ByAuthor(MagazineTitle);
                            RewritingBy_ByTitle(MagazineTitle, YourChoice2);
                            Display_Magazine_byTitle(YourChoice2);
                            ChoiceMagazine_Sorted_ByTitle(YourChoice2);
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "3":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("One World Library");
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.WriteLine("Fashion Catergory");
                            Console.ResetColor();
                            Magazines[] YourChoice3 = MagazineChoiceFashion_ByYear(TitleYear);
                            RewritingBy_ByYear(TitleYear, YourChoice3);
                            Display_Magazine_byYear(YourChoice3);
                            ChoiceMagazine_Sorted_ByYear(YourChoice3);
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                    break;
                case "2":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("One World Library");
                    Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                    Console.WriteLine("Business Catergory");
                    Console.ResetColor();
                    Console.WriteLine("You Have Chosen a Busines Magazine");
                    Magazines[] BusinessYourChoice2 = MagazineChoiceBusines_ByTitle(BusinessMag);
                    DisplayBusiness(BusinessYourChoice2);
                    BusinessChoiceDisplayTitle(BusinessYourChoice2);
                    Console.WriteLine();
                    Console.WriteLine("Press Any Key to Restart Again");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("One World Library");
                    Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                    Console.WriteLine("Sports Catergory");
                    Console.ResetColor();
                    Console.WriteLine("You Have Chosen a Busines Magazine");
                    Console.WriteLine("In What way do you want to View The Fashion Magazines");
                    Console.WriteLine("1. By Title in the First Catergory");
                    Console.WriteLine("2. By Year in the First Catergory");
                    Console.Write("Enter Choice: ");
                    string SportsChoice =Console.ReadLine();
                    switch (SportsChoice)
                    {
                        case"1":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("One World Library");
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.WriteLine("Sports Catergory");
                            Console.ResetColor();
                            Magazines[] SportsTitleCHoice =MagazineSports_ByTitle(SportMAgaTitle);
                            DisplayBusiness(SportsTitleCHoice);
                            BusinessChoiceDisplayTitle(SportsTitleCHoice);
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                           case"2":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("One World Library");
                            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
                            Console.WriteLine("Sports Catergory");
                            Console.ResetColor();
                            Magazines[] SportsTitleCHoice2 = MagazineChoiceSports_ByYear(SportMagaYear);
                            Display_Magazine_byYear(SportsTitleCHoice2);
                            ChoiceMagazine_Sorted_ByYear(SportsTitleCHoice2);
                            Console.WriteLine();
                            Console.WriteLine("Press Any Key to Restart Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                    break;
                
            }
        }
        #region - All SportsMagazine
        static Magazines[] MagazineSports_ByTitle(string AuthorFolder)
        {
            string[] lines = File.ReadAllLines(AuthorFolder);
            int magazineNums = lines.Length;
            Magazines[] Array = new Magazines[magazineNums];
            Magazines data;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] ArrayMag = lines[i].Split(new char[] { ';' });
                data.Title = ArrayMag[0];
                data.Author = ArrayMag[1];
                data.Year = ArrayMag[2];
                Array[i] = data;
            }
            return Array;
        }
        static Magazines[] MagazineChoiceSports_ByYear(string YearFolder)
        {
            string[] lines = File.ReadAllLines(YearFolder);
            int magazineNums = lines.Length;
            Magazines[] Array = new Magazines[magazineNums];
            Magazines data;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] ArrayMag = lines[i].Split(new char[] { ';' });
                data.Year = ArrayMag[0];
                data.Author = ArrayMag[1];
                data.Title = ArrayMag[2];
                Array[i] = data;
            }
            return Array;
        }
        #endregion
        #region - Business All detials Magazine

        static Magazines[] MagazineChoiceBusines_ByTitle(string AuthorFolder)
        {
            string[] lines = File.ReadAllLines(AuthorFolder);
            int magazineNums = lines.Length;
            Magazines[] Array = new Magazines[magazineNums];
            Magazines data;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] ArrayMag = lines[i].Split(new char[] { ';' });
                data.Title = ArrayMag[0];
                data.Author = ArrayMag[1];
                data.Year = ArrayMag[2];
                Array[i] = data;
            }
            return Array;
        }
        static void DisplayBusiness(Magazines[] Business)
        {
            int n = 1;
            for (int i = 0; i < Business.Length; i++)
            {
                Console.WriteLine($"{n}. Тема: {Business[i].Title}");
                n++;
            }
        }
        static void BusinessChoiceDisplayTitle(Magazines[]BusinessTitle)
        {
            Console.WriteLine("Which  Magazine from the List do you want?");
            Console.Write("Choice: ");
            int index = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"Тема: {BusinessTitle[index - 1].Title}");
                Console.WriteLine($"Автор :{BusinessTitle[index - 1].Author}");
                Console.WriteLine($"Год: {BusinessTitle[index - 1].Year}");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Good and Wise Choice.");
            Console.ResetColor();
        }
        #endregion
        #region - Fashion Magazine-Author
        static Magazines[] MagazineChoiceFashion_ByAuthor(string AuthorFolder)
        {
            string[] lines = File.ReadAllLines(AuthorFolder);
            int magazineNums = lines.Length;
            Magazines[] Array = new Magazines[magazineNums];
            Magazines data;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] ArrayMag = lines[i].Split(new char[] { ';' });
                data.Author = ArrayMag[0];
                data.Title = ArrayMag[1];
                data.Year = ArrayMag[2];
                Array[i] = data;
            }
            return Array;
        }
        #endregion
        #region - Fashion Magazine-Title
        static Magazines[] MagazineChoiceFashion_ByTitle(string TitleFolder)
        {
            string[] lines = File.ReadAllLines(TitleFolder);
            int magazineNums = lines.Length;
            Magazines[] Array = new Magazines[magazineNums];
            Magazines data;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] ArrayMag = lines[i].Split(new char[] { ';' });
                data.Title = ArrayMag[0];
                data.Author = ArrayMag[1];
                data.Year = ArrayMag[2];
                Array[i] = data;
            }
            return Array;
        }
        #endregion
        #region - Fashion Magazine-Year
        static Magazines[] MagazineChoiceFashion_ByYear(string YearFolder)
        {
            string[] lines = File.ReadAllLines(YearFolder);
            int magazineNums = lines.Length;
            Magazines[] Array = new Magazines[magazineNums];
            Magazines data;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] ArrayMag = lines[i].Split(new char[] { ';' });
                data.Year = ArrayMag[0];
                data.Author = ArrayMag[1];
                data.Title = ArrayMag[2];
                Array[i] = data;
            }
            return Array;
        }
        #endregion

        #region -Display of Book by Author,Title & Year
        static void Display_Magazine_Fashionby_Author(Magazines[] Show)
        {
            int n = 1;
            for (int i = 0; i < Show.Length; i++)
            {
                Console.WriteLine($"{n}.Автор: {Show[i].Author}, Тема: {Show[i].Title}, Год: {Show[i].Year}");
                n++;
            }
        }

        
        static void Display_Magazine_byYear(Magazines[] YearDisplay)
        {
            int n = 1;
            for (int i = 0; i < YearDisplay.Length; i++)
            {
                Console.WriteLine($"{n}. Год:{YearDisplay[i].Year}, Автор:{YearDisplay[i].Author}, Тема:{YearDisplay[i].Title}");
                n++;
            }

        }
        static void Display_Magazine_byTitle(Magazines[] TitleDisplay)
        {
            int n = 1;
            for (int i = 0; i < TitleDisplay.Length; i++)
            {
                Console.WriteLine($"{n}. Тема: {TitleDisplay[i].Title}, Автор:{TitleDisplay[i].Author}, Год:{TitleDisplay[i].Year}");
                n++;
            }
            
        }
        #endregion
        #region -  Choice of Magazine Sorted by Title,Year & Author
        static void ChoiceMagazine_Sorted_ByTitle(Magazines[] SortchoiceTitle)
        {
            Console.WriteLine("Which Magazine from the List do you want?");
            Console.Write("Choice: ");
            int index = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"Тема: {SortchoiceTitle[index - 1].Title}");
                Console.WriteLine($"Автор :{SortchoiceTitle[index - 1].Author}");
                Console.WriteLine($"Год: {SortchoiceTitle[index - 1].Year}");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Good and Wise Choice.");
            Console.ResetColor();
        }
        static void ChoiceMagazine_Sorted_ByAuthor(Magazines[] SortchoiceAuthor)
        {
            Console.WriteLine("Which Magazine from the List do you want?");
            Console.Write("Choice: ");
            int index = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"Автор :{SortchoiceAuthor[index-1].Author}");
                Console.WriteLine($"Тема: {SortchoiceAuthor[index-1].Title}");
                Console.WriteLine($"Год: {SortchoiceAuthor[index-1].Year}");
            }
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine("Good and Wise Choice.");
            Console.ResetColor();

        }
        static void ChoiceMagazine_Sorted_ByYear(Magazines[] SortchoiceYear)
        {
            Console.WriteLine("Which Magazine from the List do you want?");
            Console.Write("Choice: ");
            int index = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"Год: {SortchoiceYear[index - 1].Year}");
                Console.WriteLine($"Автор :{SortchoiceYear[index - 1].Author}");
                Console.WriteLine($"Тема: {SortchoiceYear[index - 1].Title}");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Good and Wise Choice.");
            Console.ResetColor();
        }
        #endregion

        #region -Writing to the document Magazine Fashion Author,Title & Year
        static void RewritingFashionMagazineByAuthor(string input, Magazines[]WriteFashion)
        {
            bool check = false;
            for (int i = 0; i < WriteFashion.Length; i++)
            {
                using (StreamWriter writeAuthor = new StreamWriter(input, check))
                {
                    writeAuthor.WriteLine($"{WriteFashion[i].Author};{WriteFashion[i].Title};{WriteFashion[i].Year}");
                    check= true;
                }
            }
        }
        static void RewritingBy_ByTitle(string title, Magazines[] SortTitle)
        {
            using (StreamWriter writerTitle = new StreamWriter(title, false))
            {
                for (int i = 0; i < SortTitle.Length; i++)
                {
                    writerTitle.WriteLine($"{SortTitle[i].Title};{SortTitle[i].Author};{SortTitle[i].Year}");
                }
            }
        }
        static void RewritingBy_ByYear(string year, Magazines[] SortYear)
        {
            bool check = false;
            for (int i = 0; i < SortYear.Length; i++)
            {
                using (StreamWriter writerYear = new StreamWriter(year, check))
                {
                    writerYear.WriteLine($"{SortYear[i].Year};{SortYear[i].Author};{SortYear[i].Title}");
                    check = true;
                }
            }
        }
        #endregion
        
        #region -writing additional registration
        static void WritingToFile(string file, Registrations[] typer)
        {
            using(StreamWriter sw = new StreamWriter(file,false)) 
            {
                for (int i = 0; i < typer.Length; i++)
                {
                    sw.WriteLine($"{typer[i].Names};{typer[i].Occupation};" +
                        $"{typer[i].Contact};{typer[i].Group};{typer[i].Date_Taken};{typer[i].Date_Return};{typer[i].Userpass} ");
                    
                }
            }
        }
        #endregion
        #endregion
        #region - User Information Delete
        static void DeleteUser(ref int index, ref Registrations[] Delete)
        {

            for (int i = 1 + index; i < Delete.Length; i++)
            {
                Delete[index - 1] = Delete[index];
            }
            Array.Resize(ref Delete, Delete.Length - 1);
        }
        static void ShowInfo(Registrations[] UserDetials)
        {
            int n = 1;
            for (int i = 0; i < UserDetials.Length; i++)
            {
                Console.WriteLine($"{n}. Иммя: {UserDetials[i].Names}, Профессия: {UserDetials[i].Occupation}, " +
                    $"Contacts: {UserDetials[i].Contact} " +
                    $"Группа: {UserDetials[i].Group}, Принятия Дату: {UserDetials[i].Date_Taken}, Выдачи: {UserDetials[i].Date_Return} , Пароль: {UserDetials[i].Userpass}");
                Console.WriteLine();
                n++;
            }
        }
        static Registrations[] UserInfor(string path)
        {
            string[] FileData = File.ReadAllLines(path);
            int filelines = FileData.Length;
            Registrations[] UserDetials = new Registrations[filelines];
            Registrations data;
            for (int i = 0; i < filelines; i++)
            {
                string[] DataIndex = FileData[i].Split(new char[] { ';' });
                data.Names = DataIndex[0];
                data.Occupation = DataIndex[1];
                data.Contact = DataIndex[2];
                data.Group = DataIndex[3];
                data.Date_Taken = DataIndex[4];
                data.Date_Return = DataIndex[5];
                data.Userpass = DataIndex[6];
                UserDetials[i] = data;
            }
            return UserDetials;
        }
        #region - Registration
        static void Registration(string add)
        {
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - "Добро Пожаловать в OWL".Length) / 2, Console.CursorTop + 1);
            Console.WriteLine("OWL - One Word Library");
            Console.WriteLine("Here You May Add User Data");
            Console.WriteLine("How many Users do you want to Add");
            Console.Write("Enter Number: ");

            int addedDataSize = Convert.ToInt32(Console.ReadLine());
            string[] addingArray = new string[addedDataSize];
            {
                for (int i = 0; i < addingArray.Length; i++)
                {
                    Console.Write("Name (ФИО) :");
                    string Name = Console.ReadLine();
                    Console.Write("Occupation: ");
                    string Occupation = Console.ReadLine();
                    Console.Write("Contact: ");
                    string Contact = Console.ReadLine();
                    Console.Write("Group: ");
                    string Group = Console.ReadLine();
                    Console.Write("Date of Registration(dd-MM-yyyy): ");
                    string DateofGetting = Console.ReadLine();
                    Console.Write("Date When Returned(dd-MM-yyyy): ");
                    string DateOfReturning = Console.ReadLine();
                    Console.Write("Password: ");
                    string passw = Console.ReadLine();
                    using (StreamWriter Writing = new StreamWriter("Users.txt", true))
                    {
                        Writing.WriteLine($"{Name};{Occupation};{Contact};" +
                                $"{Group};{DateofGetting};{DateOfReturning};{passw}");
                    }
                }
            }
        }
        #endregion
    } 
}
#endregion
