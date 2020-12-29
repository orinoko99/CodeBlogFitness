﻿using CodeBlogFitness.BL.Controller;
using System;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение CodeBlogFitness");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            Console.WriteLine("Введите пол");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            var birhtdate = DateTime.Parse(Console.ReadLine()); // TODO переписать

            Console.WriteLine("Введите вес");
            var weight = double.Parse(Console.ReadLine()); // TODO переписать

            Console.WriteLine("Введите рост");
            var height = double.Parse(Console.ReadLine()); // TODO переписать

            var userController = new UserController(name, gender, birhtdate, weight, height);
            userController.Save();
        }
    }
}
