using System;
using System.Collections.Generic;
using System.Linq;

// Класс для студентов
class Student
{
    public string GroupNumber { get; set; }
    public string FullName { get; set; }
    public List<int> Grades { get; set; }

    public Student(string groupNumber, string fullName, List<int> grades)
    {
        GroupNumber = groupNumber;
        FullName = fullName;
        Grades = grades;
    }

    public bool IsPassedWith4or5()
    {
        return Grades.All(grade => grade >= 4);
    }

    public override string ToString()
    {
        return $"{FullName} (Группа: {GroupNumber}) | Оценки: {string.Join(", ", Grades)}";
    }
}

// Класс для книг
public class Book
{
    public string Author { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public int Year { get; set; }
    public int Pages { get; set; }

    // Конструктор с параметрами
    public Book(string author, string title, string publisher, int year, int pages)
    {
        Author = author;
        Title = title;
        Publisher = publisher;
        Year = year;
        Pages = pages;
    }

    // Метод для вывода информации о книге
    public override string ToString()
    {
        return $"Author: {Author}, Title: {Title}, Publisher: {Publisher}, Year: {Year}, Pages: {Pages}";
    }
}

class Program
{
    static List<Student> students = new List<Student>();
    static List<Book> books = new List<Book>();

    static void Main()
    {
        Console.WriteLine("Введите номер задания - ");
        int x = int.Parse(Console.ReadLine());
        switch (x)
        {
            case 1:
                HandleStudentOperations();
                break;

            case 2:
                HandleBookOperations();
                break;

            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }
    }

    static void HandleStudentOperations()
    {
        while (true)
        {
            Console.WriteLine("\nМеню студентов:");
            Console.WriteLine("1. Ввести информацию о студентах");
            Console.WriteLine("2. Показать студентов, сдавших на 4 и 5");
            Console.WriteLine("3. Добавить студента");
            Console.WriteLine("4. Удалить студента");
            Console.WriteLine("5. Найти студента по фамилии");
            Console.WriteLine("6. Проверить, есть ли студент");
            Console.WriteLine("7. Получить диапазон студентов");
            Console.WriteLine("8. Копировать студентов в массив");
            Console.WriteLine("9. Очистить список студентов");
            Console.WriteLine("0. Выход");
            Console.Write("Введите номер операции: ");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1: EnterStudentData(); break;
                case 2: ShowPassedStudents(); break;
                case 3: AddStudent(); break;
                case 4: RemoveStudent(); break;
                case 5: FindStudent(); break;
                case 6: CheckStudentExistence(); break;
                case 7: GetStudentsRange(); break;
                case 8: CopyStudentsToArray(); break;
                case 9: ClearStudents(); break;
                case 0: return;
                default: Console.WriteLine("Неверный выбор. Попробуйте снова."); break;
            }
        }
    }

    static void HandleBookOperations()
    {
        while (true)
        {
            Console.WriteLine("Выберите операцию с книгами:");
            Console.WriteLine("1 - Добавить книгу");
            Console.WriteLine("2 - Удалить книгу");
            Console.WriteLine("3 - Найти книгу");
            Console.WriteLine("4 - Проверить наличие книги");
            Console.WriteLine("5 - Получить книги из заданного диапазона лет");
            Console.WriteLine("6 - Копировать книги в массив");
            Console.WriteLine("7 - Вывести список книг");
            Console.WriteLine("0 - Выход");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: AddBook(); break;
                case 2: RemoveBook(); break;
                case 3: SearchBook(); break;
                case 4: CheckBookExistence(); break;
                case 5: GetBooksByYearRange(); break;
                case 6: CopyBooksToArray(); break;
                case 7: PrintBooks(); break;
                case 0: return;
                default: Console.WriteLine("Неверный выбор."); break;
            }
        }
    }

    // Методы для работы с студентами
    static void EnterStudentData()
    {
        Console.Write("Введите количество студентов: ");
        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            Console.WriteLine($"Введите данные для студента {i + 1}:");

            Console.Write("Номер группы: ");
            string groupNumber = Console.ReadLine();

            Console.Write("Ф.И.О. студента: ");
            string fullName = Console.ReadLine();

            List<int> grades = new List<int>();
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Оценка {j + 1}: ");
                grades.Add(int.Parse(Console.ReadLine()));
            }

            students.Add(new Student(groupNumber, fullName, grades));
        }
    }

    static void ShowPassedStudents()
    {
        Console.WriteLine("\nСтуденты, сдавшие экзамены на 4 и 5:");
        foreach (var student in students)
        {
            if (student.IsPassedWith4or5())
            {
                Console.WriteLine(student);
            }
        }
    }

    static void AddStudent()
    {
        Console.WriteLine("\nДобавление нового студента:");

        Console.Write("Номер группы: ");
        string groupNumber = Console.ReadLine();

        Console.Write("Ф.И.О. студента: ");
        string fullName = Console.ReadLine();

        List<int> grades = new List<int>();
        for (int j = 0; j < 3; j++)
        {
            Console.Write($"Оценка {j + 1}: ");
            grades.Add(int.Parse(Console.ReadLine()));
        }

        students.Add(new Student(groupNumber, fullName, grades));
        Console.WriteLine("Студент добавлен!");
    }

    static void RemoveStudent()
    {
        Console.Write("Введите индекс студента для удаления (0 - " + (students.Count - 1) + "): ");
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < students.Count)
        {
            students.RemoveAt(index);
            Console.WriteLine("Студент удален.");
        }
        else
        {
            Console.WriteLine("Неверный индекс.");
        }
    }

    static void FindStudent()
    {
        Console.Write("Введите ФИО студента для поиска: ");
        string lastName = Console.ReadLine();

        var foundStudent = students.Find(s => s.FullName.IndexOf(lastName, StringComparison.OrdinalIgnoreCase) >= 0);
        if (foundStudent != null)
        {
            Console.WriteLine("Найден студент: " + foundStudent);
        }
        else
        {
            Console.WriteLine("Студент не найден.");
        }
    }

    static void CheckStudentExistence()
    {
        Console.Write("Введите фамилию студента для проверки: ");
        string lastName = Console.ReadLine();

        bool exists = students.Exists(s => s.FullName.IndexOf(lastName, StringComparison.OrdinalIgnoreCase) >= 0);
        Console.WriteLine(exists ? "Студент найден." : "Студент не найден.");
    }

    static void GetStudentsRange()
    {
        Console.Write("Введите начальный индекс диапазона (начиная с 1): ");
        int start = int.Parse(Console.ReadLine()) - 1;  // Преобразуем в индекс, начиная с 0

        Console.Write("Введите конечный индекс диапазона (начиная с 1): ");
        int end = int.Parse(Console.ReadLine()) - 1;  // Преобразуем в индекс, начиная с 0

        if (start >= 0 && end < students.Count && start <= end)
        {
            var range = students.GetRange(start, end - start + 1);
            Console.WriteLine("\nПолучен диапазон студентов:");
            foreach (var student in range)
            {
                Console.WriteLine(student);
            }
        }
        else
        {
            Console.WriteLine("Неверный диапазон.");
        }
    }


    static void CopyStudentsToArray()
    {
        var studentsArray = students.ToArray();
        Console.WriteLine("\nКопирован в массив:");
        foreach (var student in studentsArray)
        {
            Console.WriteLine(student);
        }
    }

    static void ClearStudents()
    {
        students.Clear();
        Console.WriteLine("Список студентов очищен.");
    }

    // Методы для работы с книгами
    static void AddBook()
    {
        Console.WriteLine("Введите автора:");
        string author = Console.ReadLine();
        Console.WriteLine("Введите название книги:");
        string title = Console.ReadLine();
        Console.WriteLine("Введите издательство:");
        string publisher = Console.ReadLine();
        Console.WriteLine("Введите год издания:");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество страниц:");
        int pages = int.Parse(Console.ReadLine());
        Console.Clear();
        books.Add(new Book(author, title, publisher, year, pages));
        Console.WriteLine("Книга добавлена.");
    }

    static void RemoveBook()
    {
        Console.WriteLine("Введите название книги для удаления:");
        string title = Console.ReadLine();
        var bookToRemove = books.FirstOrDefault(b => b.Title == title);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine("Книга удалена.");
        }
        else
        {
            Console.WriteLine("Книга не найдена.");
        }
    }

    static void SearchBook()
    {
        Console.WriteLine("Введите название книги для поиска:");
        string title = Console.ReadLine();

        // Используем IndexOf для поиска без учета регистра
        var book = books.FirstOrDefault(b => b.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0);

        if (book != null)
        {
            Console.WriteLine($"Найдена книга: {book}");
        }
        else
        {
            Console.WriteLine("Книга не найдена.");
        }
    }



    static void CheckBookExistence()
    {
        Console.WriteLine("Введите название книги для проверки:");
        string title = Console.ReadLine();
        bool exists = books.Any(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (exists)
        {
            Console.WriteLine("Книга существует.");
        }
        else
        {
            Console.WriteLine("Книга не существует.");
        }
    }

    static void GetBooksByYearRange()
    {
        Console.WriteLine("Введите год для начала диапазона:");
        int startYear = int.Parse(Console.ReadLine())-1;
        Console.WriteLine("Введите год для конца диапазона:");
        int endYear = int.Parse(Console.ReadLine())-1;

        var filteredBooks = books.Where(b => b.Year >= startYear && b.Year <= endYear).ToList();
        if (filteredBooks.Any())
        {
            Console.WriteLine("Книги, изданные в этом диапазоне:");
            foreach (var book in filteredBooks)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine("Книги не найдены в этом диапазоне.");
        }
    }

    static void CopyBooksToArray()
    {
        var booksArray = books.ToArray();
        Console.WriteLine("Массив книг:");
        foreach (var book in booksArray)
        {
            Console.WriteLine(book);
        }
    }

    static void PrintBooks()
    {
        if (books.Any())
        {
            Console.WriteLine("Список всех книг:");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine("Нет книг в списке.");
        }
    }
}
