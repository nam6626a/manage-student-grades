// See https://aka.ms/new-console-template for more information

class Student
{
    public string Name { get; set; }
    public Dictionary<string, int> Scores { get; set; }

    public double GetAverageScore()
    {
        int total = 0;
        foreach (var score in Scores.Values)
        {
            total += score;
        }
        return (double)total / Scores.Count;
    }
}

class Program
{
    static void Main()
    {
        // 1. Tạo danh sách sinh viên ngẫu nhiên
        Student[] students = new Student[]
        {
            new Student { Name = "Nguyen Van A", Scores = new Dictionary<string, int> { { "Math", 10 }, { "Physic", 9 }, { "Chemistry", 8 } } },
            new Student { Name = "Nguyen Van B", Scores = new Dictionary<string, int> { { "Math", 7 }, { "Physic", 8 }, { "Chemistry", 9 } } },
            new Student { Name = "Nguyen Van C", Scores = new Dictionary<string, int> { { "Math", 8 }, { "Physic", 8 }, { "Chemistry", 8 } } },
            new Student { Name = "Nguyen Van D", Scores = new Dictionary<string, int> { { "Math", 9 }, { "Physic", 7 }, { "Chemistry", 7 } } },
        };

        // 2. Sắp xếp thủ công (Bubble Sort)
        for (int i = 0; i < students.Length - 1; i++)
        {
            for (int j = 0; j < students.Length - i - 1; j++)
            {
                double avgStud1 = students[j].GetAverageScore();
                double avgStud2 = students[j + 1].GetAverageScore();

                if (avgStud1 < avgStud2 || (avgStud1 == avgStud2 && string.Compare(students[j].Name, students[j + 1].Name) > 0))
                {
                    var temp = students[j];
                    students[j] = students[j + 1];
                    students[j + 1] = temp;
                }
            }
        }

        // 3. Tìm object có điểm trung bình = 8 bằng Binary Search (vì đã sắp xếp)
        int left = 0, right = students.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            double avg = students[mid].GetAverageScore();

            if (avg == 8)
            {
                Console.WriteLine("Found student with avg = 8: " + students[mid].Name);
                break;
            }
            else if (avg > 8)
                left = mid + 1;
            else
                right = mid - 1;
        }

        // 4. Xuất danh sách đã sắp xếp
        Console.WriteLine("\nSorted Students:");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name} - Average: {student.GetAverageScore():F2}");
        }
    }
}
