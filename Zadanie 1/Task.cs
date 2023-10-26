using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1
{
    enum Department
    {
        Начальство,
        Бухгалтерия,
        Разработчик,
        Системщик
    }
    internal class Task
    {      
        public Task (string boss, Department department, string employee, string task )
        {
            this.boss = boss;
            this.department = department;
            this.employee = employee;
            this.task = task;
        }

        private string boss {  get; set; }  
        private Department department { get; set; }
        private string employee { get; set; }
        private string task { get; set; }
        public void Print()
        {
            Console.WriteLine($"{boss} даёт задачу: {task}, работнику {employee}.");
        }
        public string GetEmployeeName()
        {
            return employee;
        }
        public string GetTaskName()
        {
            return task;
        }
        public string GetBossName()
        {
            return boss;    
        }

    }
}
