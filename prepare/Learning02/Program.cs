using System;
using System.Security.Cryptography.X509Certificates;
using Learning02;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle ="Programmer";
        job1._startYear = 2020;
        job1._endYear = 2022;

        job1.Display();

        Job job2 = new Job();
        job2._company = "EASports";
        job2._jobTitle ="GamerDesigner";
        job2._startYear = 2015;
        job2._endYear = 2019;

        job2.Display();

        Console.WriteLine("");

        Resume Myresume1 = new Resume();
        Myresume1._name = "Henrique Almeida";
        Myresume1._jobs.Add(job1);
        Myresume1._jobs.Add(job2); 

        Myresume1.DisplayResume();
    }
}