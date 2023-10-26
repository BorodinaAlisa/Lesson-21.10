using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_8
{
    internal class Program
    {
        static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static string FormatValue(object value)
        {
            if (value is IFormattable)
            {
                IFormattable formattableValue = value as IFormattable;// Преобразуем значение к типу IFormattable с помощью оператора as
                return formattableValue.ToString(null, null);
            }
            else
            {
                return value.ToString();
            }
        }
        public interface IFormattable
            {
                string ToString(string format, IFormatProvider formatProvider);
            }
        public static void SearchMail(ref string s)
        {
            int index = s.IndexOf('#'); // Находим индекс символа "#"
            if (index != -1)
            {
                // Выделяем адрес электронной почты
                s = s.Substring(index + 1).Trim();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 8.1. В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить метод, который переводит деньги с одного счета на другой. У метода два параметра: ссылка на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.");
            AccountBank account1 = new AccountBank();
            AccountBank account2 = new AccountBank();
            account1.Deposit(1000);
            Console.WriteLine($"Баланс1: {account1.Balance}"); 
            Console.WriteLine($"Баланс2: {account2.Balance}"); 
            account1.TransferMoney(account2, 500); 
            Console.WriteLine($"Баланс1: {account1.Balance}"); 
            Console.WriteLine($"Баланс2: {account2.Balance}");
            Console.WriteLine("Упражнение 8.2. Реализовать метод, который в качестве входного параметра принимает строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.Протестировать метод.");
            Console.WriteLine("Введите строку:");    
            string input = Console.ReadLine();
            string reversed = ReverseString(input);
            Console.WriteLine("Результат:" + reversed);
            Console.WriteLine("Упражнение 8.3. Написать программу, которая спрашивает у пользователя имя файла. Если такого файла не существует, то программа выдает пользователю сообщение и заканчивает работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными буквами.");
            Console.WriteLine("Введите имя файла:");
            string inputFileName = Console.ReadLine();
            string outputFileName = "C:\\Users\\Алиса\\Documents\\Visual Studio 2022\\outputFile.txt";
            if (!File.Exists(inputFileName))
            {
                Console.WriteLine("Файл не существует.");
                return;
            }
            try
            {
                string content = File.ReadAllText(inputFileName);
                string uppercaseContent = content.ToUpper();
                File.WriteAllText(outputFileName, uppercaseContent);
                Console.WriteLine("Содержимое файла записано в выходной файл в заглавных буквах.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибкa:" + ex.Message);
            }
            Console.WriteLine("Упражнение 8.4. Реализовать метод, который проверяет реализует ли входной параметр метода интерфейс System.IFormattable. Использовать оператор is и as. (Интерфейс IFormattable обеспечивает функциональные возможности форматирования значения объекта в строковое представление.)");
            int number = 17;
            string formattedNumber = FormatValue(number);
            Console.WriteLine(formattedNumber);
            Console.WriteLine("Домашнее задание 8.1. Работа со строками.Сформировать новый файл, содержащий список адресов электронной почты.Предусмотреть метод, выделяющий из строки адрес почты. Методу в качестве параметра передается символьная строка s, e-mail возвращается в той же строке s: public void SearchMail (ref string s).");
            string filePath = "C:\\Users\\Алиса\\Documents\\Visual Studio 2022\\fio.txt";
            string outputFilePath = "C:\\Users\\Алиса\\Documents\\Visual Studio 2022\\emails.txt";
            string[] lines = File.ReadAllLines(filePath);
            // Создание нового файла и запись адресов в него
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (string line in lines)
                {
                    string email = line;
                    SearchMail(ref email);// Вызов метода SearchMail для поиска адреса электронной почты
                    writer.WriteLine(email);
                }
            }
            Console.WriteLine("Файл с адресами электронной почты успешно создан.");
            Console.WriteLine("Домашнее задание 8.2. Список песен. В методе Main создать список из четырех песен. В цикле вывести информацию о каждой песне. Сравнить между собой первую и вторую песню в списке. Песня представляет собой класс с методами для заполнения каждого из полей, методом вывода данных о песне на печать, методом, который сравнивает между собой два объекта:");
            List<Song> songs = new List<Song>();
            Song song1 = new Song();
            song1.SetName("Неон");
            song1.SetAuthor("Pharaon и ЛСП");
            songs.Add(song1);
            Song song2 = new Song();
            song2.SetName("Перезаряжай");
            song2.SetAuthor("Три дня дождя");
            songs.Add(song2);
            Song song3 = new Song();
            song3.SetName("Добро пожаловать");
            song3.SetAuthor("OgBuda и Mayot");
            songs.Add(song3);
            Song song4 = new Song();
            song4.SetName("ХАЙЕГОХО");
            song4.SetAuthor("Toxi$");
            songs.Add(song4);
            foreach (Song song in songs)
            {
                Console.WriteLine(song.Title());
            }
            Console.WriteLine();
            if (song1.Equals(song2))
            {
                Console.WriteLine("Первая песня совпадает со второй песней");
            }
            else
            {
                Console.WriteLine("Первая песня не совпадает со второй песней");
            }
            Console.ReadKey();
        
        }
    }
}
