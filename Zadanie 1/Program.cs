using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1
{
    internal class Program
    {
        static void Answer(Task task, List<Person> employees)
        {
            task.Print();
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Name() == task.GetEmployeeName())
                {
                    if (employees[i].BossName() == task.GetBossName()) Console.WriteLine("Он будет делать.");
                    else Console.WriteLine("Он не будет делать.");
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1. Написать программу, которая выполняет следующие задачи.");
            Person Semen = new Person("Семён",Department.Начальство);
            Person Rashid = new Person("Рашид", Department.Начальство, Semen);
            Person O_Ilham = new Person("О Ильхам", Department.Начальство, Semen);
            Person Lykas = new Person("Лукас", Department.Бухгалтерия, Rashid);
            Person Orkadiy = new Person("Оркадий", Department.Начальство, O_Ilham);
            Person Volodya = new Person("Володя", Department.Начальство, Orkadiy);
            Person Ilshat = new Person("Ильшат", Department.Системщик, Volodya);
            Person Ivanich = new Person("Иваныч", Department.Системщик, Ilshat);
            Person Ilya = new Person("Илья", Department.Системщик, Ivanich);
            Person Vitya = new Person("Витя", Department.Системщик, Ivanich);
            Person Zhenya = new Person("Женя", Department.Системщик, Ivanich);
            Person Sergey = new Person("Сергей", Department.Разработчик, Orkadiy);
            Person Laysan = new Person("Ляйсан", Department.Разработчик, Sergey);
            Person Dina = new Person("Дина", Department.Разработчик, Laysan);
            Person Marat = new Person("Марат", Department.Разработчик, Laysan);
            Person Ildar = new Person("Ильдар", Department.Разработчик, Laysan);
            Person Anton = new Person("Антон", Department.Разработчик, Laysan);
            List<Person> Boss = new List<Person>() { Semen, Rashid, O_Ilham, Lykas, Orkadiy, Volodya };
            List<Person> System = new List<Person>() { Ilshat, Ivanich, Ilya, Vitya, Zhenya };
            List<Person> Development = new List<Person>() { Sergey, Laysan, Dina, Marat, Ildar, Anton, };
            Task task1 = new Task(Ilshat.Name(), Department.Системщик, "устранить все неполадки", Ivanich.Name());
            Task task2 = new Task(Laysan.Name(), Department.Разработчик, "разработать приложение", Marat.Name());
            Task task3 = new Task(Laysan.Name(), Department.Разработчик, "создать мобильное приложение", Anton.Name());
            Task task4 = new Task(Sergey.Name(), Department.Разработчик, "разработать программу для обратботки данных", Laysan.Name());
            Task task5 = new Task(Ivanich.Name(), Department.Системщик, "настроить базовое ОП", Ilya.Name());
            Answer(task1, System);
            Answer(task2, Development);
            Answer(task3, Development);
            Answer(task4, Development);
            Answer(task5, System);
            Console.ReadKey();

        }
    }
}
