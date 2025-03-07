using System;
using System.Collections.Generic;
using System.Linq;

public interface IPersonService
{
    int CalculateAge();
    void GetAddresses();
}

public interface IStudentService : IPersonService
{
    double CalculateGPA();
    void EnrollCourse(Course course);
}

public interface IInstructorService : IPersonService
{
    decimal CalculateSalary();
}

public abstract class Person
{
    public string Name { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    private List<string> Addresses { get; set; } = new List<string>();

    protected Person(string name, DateTime dob)
    {
        Name = name;
        DateOfBirth = dob;
    }

    public int CalculateAge()
    {
        return DateTime.Now.Year - DateOfBirth.Year;
    }

    public void AddAddress(string address)
    {
        Addresses.Add(address);
    }

    public void GetAddresses()
    {
        Console.WriteLine($"{Name}'s Addresses:");
        foreach (var address in Addresses)
        {
            Console.WriteLine($"- {address}");
        }
    }

    public abstract decimal CalculateSalary();
}

public class Student : Person, IStudentService
{
    private List<(Course, char)> Courses { get; set; } = new List<(Course, char)>();

    public Student(string name, DateTime dob) : base(name, dob) { }

    public void EnrollCourse(Course course)
    {
        Courses.Add((course, 'F'));
        course.AddStudent(this);
    }

    public void AssignGrade(Course course, char grade)
    {
        for (int i = 0; i < Courses.Count; i++)
        {
            if (Courses[i].Item1 == course)
            {
                Courses[i] = (course, grade);
            }
        }
    }

    public double CalculateGPA()
    {
        if (Courses.Count == 0) return 0;

        Dictionary<char, double> gradePoints = new Dictionary<char, double>
        {
            { 'A', 4.0 }, { 'B', 3.0 }, { 'C', 2.0 }, { 'D', 1.0 }, { 'F', 0.0 }
        };

        double totalPoints = Courses.Sum(c => gradePoints[c.Item2]);
        return totalPoints / Courses.Count;
    }

    public override decimal CalculateSalary() => 0;
}

public class Instructor : Person, IInstructorService
{
    public string Department { get; set; }
    public DateTime JoinDate { get; set; }
    private decimal BaseSalary { get; set; }

    public Instructor(string name, DateTime dob, string department, DateTime joinDate, decimal baseSalary)
        : base(name, dob)
    {
        Department = department;
        JoinDate = joinDate;
        BaseSalary = baseSalary;
    }

    public int YearsOfExperience()
    {
        return DateTime.Now.Year - JoinDate.Year;
    }

    public override decimal CalculateSalary()
    {
        decimal experienceBonus = YearsOfExperience() * 500;
        return BaseSalary + experienceBonus;
    }
}

public class Course
{
    public string CourseName { get; private set; }
    private List<Student> EnrolledStudents { get; set; } = new List<Student>();

    public Course(string courseName)
    {
        CourseName = courseName;
    }

    public void AddStudent(Student student)
    {
        EnrolledStudents.Add(student);
    }

    public void ListEnrolledStudents()
    {
        Console.WriteLine($"Students in {CourseName}:");
        foreach (var student in EnrolledStudents)
        {
            Console.WriteLine($"- {student.Name}");
        }
    }
}

public class Department
{
    public string Name { get; private set; }
    public Instructor Head { get; set; }
    public decimal Budget { get; private set; }
    public DateTime BudgetStart { get; private set; }
    public DateTime BudgetEnd { get; private set; }
    private List<Course> CoursesOffered { get; set; } = new List<Course>();

    public Department(string name, decimal budget, DateTime start, DateTime end)
    {
        Name = name;
        Budget = budget;
        BudgetStart = start;
        BudgetEnd = end;
    }

    public void AddCourse(Course course)
    {
        CoursesOffered.Add(course);
    }

    public void ListCourses()
    {
        Console.WriteLine($"Courses in {Name} Department:");
        foreach (var course in CoursesOffered)
        {
            Console.WriteLine($"- {course.CourseName}");
        }
    }
}

public class Color
{
    public int Red { get; private set; }
    public int Green { get; private set; }
    public int Blue { get; private set; }
    public int Alpha { get; private set; } = 255; // Default to opaque

    public Color(int red, int green, int blue, int alpha = 255)
    {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }

    public int GetGrayscale() => (Red + Green + Blue) / 3;
}

public class Ball
{
    public int Size { get; private set; }
    public Color Color { get; private set; }
    private int ThrowCount { get; set; } = 0;

    public Ball(int size, Color color)
    {
        Size = size;
        Color = color;
    }

    public void Pop() => Size = 0;

    public void Throw()
    {
        if (Size > 0)
        {
            ThrowCount++;
        }
    }

    public int GetThrowCount() => ThrowCount;
}

public class Program
{
    public static void Main()
    {
        Student student = new Student("Alice", new DateTime(2002, 5, 20));
        Course math = new Course("Mathematics");
        student.EnrollCourse(math);
        student.AssignGrade(math, 'A');
        Console.WriteLine($"{student.Name}'s GPA: {student.CalculateGPA()}");

        Instructor instructor = new Instructor("Dr. Smith", new DateTime(1980, 7, 10), "Computer Science", new DateTime(2010, 8, 1), 50000);
        Console.WriteLine($"{instructor.Name}'s Salary: {instructor.CalculateSalary()}");

        Color redColor = new Color(255, 0, 0);
        Ball ball = new Ball(10, redColor);
        ball.Throw();
        ball.Throw();
        Console.WriteLine($"Ball throw count: {ball.GetThrowCount()}");
        ball.Pop();
        ball.Throw();
        Console.WriteLine($"Ball throw count after pop: {ball.GetThrowCount()}");
    }
}
