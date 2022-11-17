//**********************************************************************
//*Практическая работа №12                                             *   
//* Выполнил: Кондаков.П.А.,группа 2ИСП                                *
//* Задание: изучение особенностей использования указателей в языке С#.*
//**********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_14
{
    class Program
    {
        unsafe static double MethodPolDel(double *a, double *b, double *eps)
        {
            double* c;//с-середина,выделение памяти под переменную типа double
            double c1 = 0.0;
            c = &c1;
            while(Math.Abs(*a-*b)>=*eps)
            {
                *c = (*a + *b) / 2;//расчет середины отрезка[a,b]
                //расчет новых границ отрезка

                if ((Math.Tan(3.4 * Math.Pow(*a, 3.0)) + Math.Cos(*a + 1.2)) *(Math.Tan(3.4 * Math.Pow(*c, 3.0)) + Math.Cos(*c + 1.2))  <= 0)//Для a и с
                { *b = *c; }// новый отрезок [a,c]  
                else
                { *a = *c; }   // новый отрезок [c,b]                      
            }
            return *c;
        }
        unsafe static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Здравствуйте");
            Console.WriteLine("Практическая работа №14");
            Console.WriteLine("Используя метод половинного деления,найти корень уравнения.\n");
            double *a;double *b; double *eps;
            try
            {
                //Ввод данных
                Console.Write("левая граница отрезка,a=");
                double a1 = Convert.ToDouble(Console.ReadLine());
                a = &a1;// взятие адреса переменной а1,хранящей значение левой границы отрезка
                Console.Write("Правая граница отрезка,b=");
                double b1 = Convert.ToDouble(Console.ReadLine());
                b = &b1;//взятие адреса переменной b1,хранящей значение левой границы отрезка
                Console.Write("Точность расчетов,esp=");
                double eps1 = Convert.ToDouble(Console.ReadLine());
                eps = &eps1;//взятие адреса esp
                //Вызов функции
                double x = MethodPolDel(a, b, eps);
                Console.WriteLine("Корень уравнения x = {0:0.#####}", x);
            }
            catch(InvalidCastException e)
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Ошибка ввода данных!" + e.Message);
            }
            Console.ReadKey();
        }
    }
}
