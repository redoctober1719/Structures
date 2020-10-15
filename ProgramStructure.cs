using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace StudentNamespace
{
    struct Program
    {
        static Student[] students;
        static int NumberOfStudents, age, yearOfBirth, NumberOfSubjects;
        static string name;


        static void ChangeStudent(int id)
        {
            if (NumberOfStudents > 0 && students[id]._StudentExists == true )
            {
                Console.WriteLine("__________________________");
                Console.WriteLine("Предыдущий студент");
                students[id].GetInfo();
                Console.WriteLine("__________________________");
                Console.WriteLine("Новый студент");
                Console.Write("ФИО студента- ");
                name = Console.ReadLine();

                Console.Write("Год рождения студента- ");
                yearOfBirth = int.Parse(Console.ReadLine());

                age = 2020 - yearOfBirth;

                Console.Write("Количество предметов студента- ");
                NumberOfSubjects = int.Parse(Console.ReadLine());

                students[id] = new Student(name, age, NumberOfSubjects,true);
               
                for (int i = 0; i < NumberOfSubjects; i++)
                {
                    Console.Write("Название предмета- ");
                    string SubjName = Console.ReadLine();

                    Console.Write($"Оценка за предмет '{SubjName}'- ");
                    int mark = int.Parse(Console.ReadLine());
                    students[id]._subjectArray[i] = new Subject(SubjName, mark);

                }
            }
            else
            {
                Console.WriteLine("Добавьте студента!");
                Thread.Sleep(800);
                Console.Clear();
            }

        }

        static void DeleteStudent(int id)
        {
            if (NumberOfStudents > 0)
            {
                students[id]._StudentExists = false;
                NumberOfStudents -= 1;
            }
            else
            {
                Console.WriteLine("Добавьте студента!");
                Thread.Sleep(800);
                Console.Clear();
            }
        }
        static void AddStudent(int count)
        {
            NumberOfStudents += count;
            students = new Student[NumberOfStudents];
            for (int i = NumberOfStudents - count; i < students.Length; i++)
            {

                Console.Write("ФИО студента- ");
                name = Console.ReadLine();

                Console.Write("Год рождения студента- ");
                yearOfBirth = int.Parse(Console.ReadLine());

                age = 2020 - yearOfBirth;

                Console.Write("Количество предметов студента- ");
                NumberOfSubjects = int.Parse(Console.ReadLine());

                students[i] = new Student(name, age, NumberOfSubjects,true);
               // students[i].StudentExists = true;
                for (int id = 0; id < NumberOfSubjects; id++)
                {
                    Console.Write("Название предмета- ");
                    string SubjName = Console.ReadLine();

                    Console.Write($"Оценка за предмет '{SubjName}'- ");
                    int mark = int.Parse(Console.ReadLine());
                    students[i]._subjectArray[id] = new Subject(SubjName, mark);

                }
                Thread.Sleep(1000);
                Console.Clear();
            }

        }

        static void GetStudentInfo(int id)
        {
            if (NumberOfStudents > 0 && students[id]._StudentExists == true)
                students[id].GetInfo();
            else
            {
                Console.WriteLine("Добавьте студента!");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        static void SelectAction(int actionID)
        {
            switch (actionID)
            {
                case 1:
                    Console.WriteLine($"Какого студента просмотреть? от 0 до {NumberOfStudents - 1}");
                    int b = int.Parse(Console.ReadLine());
                    if (b < NumberOfStudents && b >= 0) GetStudentInfo(b);
                    else Console.WriteLine("Неверный номер студента");
                    break;
                case 2:
                    Console.WriteLine("Сколько студентов добавить?");
                    int a = int.Parse(Console.ReadLine());
                    AddStudent(a);
                    break;
                case 3:
                    Console.WriteLine("Какого студента удалить?");
                    int c = int.Parse(Console.ReadLine());
                    DeleteStudent(c);
                    break;
                case 4:
                    Console.WriteLine("Какого студента изменить?");
                    int d = int.Parse(Console.ReadLine());
                    ChangeStudent(d);
                    break;
            }
        }


        static void Main(string[] args)
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.WriteLine("Какое действие выполнить? ");
                Console.WriteLine("1 - просмотреть информацию о студенте");
                Console.WriteLine("2 - добавить студента");
                Console.WriteLine("3 - удалить студента");
                Console.WriteLine("4 - изменить студента");
                int input = int.Parse(Console.ReadLine());
                Console.Clear();
                SelectAction(input);

                Console.WriteLine("Нажмите Esc для выхода или любую клавишу, чтобы продолжить");
                consoleKeyInfo = Console.ReadKey(false);
            }
            while (consoleKeyInfo.Key != ConsoleKey.Escape);

            Console.ReadKey();
        }
    }

    public struct Student
    {
        public Subject[] _subjectArray;
        int _age;
        public bool _StudentExists;
        string[] _fio;


        public Student(string fio, int age, int numberOfSubjects, bool StudentExists)
        {
            _fio = fio.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            _age = age;
            _subjectArray = new Subject[numberOfSubjects];
            _StudentExists = StudentExists;
        }

        public void  GetInfo()
        {
            Console.Write("ФИО студента-");
            for (int i = 0; i < _fio.Length; i++)
            {
                Console.Write(_fio[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Возраст студента- {_age}");

            Console.WriteLine("Список предметов: ");
            for (int i = 0; i < _subjectArray.Length; i++)
            {
                _subjectArray[i].GetInfo();
            }
        }
    }
    
    public struct Subject
    {
        public string _name;
        public int _mark;

        public Subject(string name, int mark)
        {
            _name = name;
            _mark = mark;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Оценка за предмет '{_name}' - {_mark}");
        }
    }
}

