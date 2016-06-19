using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Student
{
    private int year; //объявление закрытого поля

    public int Year //объявление свойства
    {
        get // аксессор чтения поля
        {
            return year;
        }
        set // аксессор записи в поле
        {
            if (value < 1)
                year = 1;
            else if (value > 5)
                year = 5;
            else year = value;
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Student st1 = new Student();
        st1.Year = 0; // записываем в поле, используя аксессор set     Console.WriteLine(st1.Year); // читаем поле, используя аксессор get, выведет 1
        Console.ReadKey();
    }
}
