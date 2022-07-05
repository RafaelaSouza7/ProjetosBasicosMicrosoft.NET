using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHTTP
{
    internal class Task
    {
        public int userId;
        public int id;
        public string title;
        public bool completed;

        public void Show()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"UserID: {userId}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Completed?: {completed}");
            Console.WriteLine("---------------------------------");
        }
    }
}
