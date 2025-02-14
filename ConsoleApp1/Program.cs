using System;
class Student
{
    public string Name { get; set; }
    public Dictionary<string, double> Scores { get; set; }

    public double GetAverageScore()
    {
        double total = 0;
        foreach (var score in Scores.Values)
        {
            total += score;
        }
        return total / Scores.Count;
    }
}

class Program
{
    static void Main()
    {
        // 1. Tạo danh sách sinh viên ngẫu nhiên
        Student[] students = new Student[]
        {
            new Student { Name = "Nguyen Van E", Scores = new Dictionary<string, double> { { "Math", 9.5 }, { "Physic", 9.5 }, { "Chemistry", 10 } } },
            new Student { Name = "Nguyen Van A", Scores = new Dictionary<string, double> { { "Math", 10 }, { "Physic", 9 }, { "Chemistry", 8 } } },
            new Student { Name = "Nguyen Van C", Scores = new Dictionary<string, double> { { "Math", 7 }, { "Physic", 8 }, { "Chemistry", 9 } } },
            new Student { Name = "Nguyen Van B", Scores = new Dictionary<string, double> { { "Math", 8 }, { "Physic", 8 }, { "Chemistry", 8 } } },
            new Student { Name = "Nguyen Van D", Scores = new Dictionary<string, double> { { "Math", 9 }, { "Physic", 7 }, { "Chemistry", 7 } } },
        };

        // 2. Sắp xếp thủ công
        for (int i = 0; i < students.Length - 1; i++)
        {
            for (int j = 0; j < students.Length - i - 1; j++)
            {
                double avgStud1 = students[j].GetAverageScore();
                double avgStud2 = students[j + 1].GetAverageScore();

                //so sánh điểm tb nếu 2 điểm bằng nhau xắp xếp theo alphabel
                if (avgStud1 < avgStud2 || (avgStud1 == avgStud2 && string.Compare(students[j].Name, students[j + 1].Name) > 0))
                {
                    var temp = students[j];
                    students[j] = students[j + 1];
                    students[j + 1] = temp;
                }
            }
        }

        // 3. Tìm object có điểm trung bình = 8 sử dụng thuật toán Binary Search
        //left :chỉ số bắt đầu của mảng; right: chỉ số kết thúc của mảng 
        int left = 0, right = students.Length - 1;
        int foundIndex = -1;

        while (left <= right)
        {
            //mid: vị trí nằm giữa của mảng, avg: điểm tb của học sinh tại mid
            int mid = (left + right) / 2;
            double avg = students[mid].GetAverageScore();

            if (avg == 8)
            {
                foundIndex = mid; // Lưu vị trí tìm thấy đầu tiên
                break;  
            }
            //ĐTB lớn hơn 8 => tìm bên phải do đã xắp xếp trước đó và ngược lại
            else if (avg > 8)
                left = mid + 1;
            else
                right = mid - 1;
        }
        if (foundIndex != -1)
        {
            // Tìm tất cả học sinh có avg = 8 về phía trái
            int i = foundIndex;
            while (i >= 0 && students[i].GetAverageScore() == 8)
            {
                Console.WriteLine("Found student with avg = 8: " + students[i].Name);
                i--;
            }

            // Tìm tất cả học sinh có avg = 8 về phía phải
            int j = foundIndex + 1;
            while (j < students.Length && students[j].GetAverageScore() == 8)
            {
                Console.WriteLine("Found student with avg = 8: " + students[j].Name);
                j++;
            }
        }

        Console.WriteLine("\nSorted Students:");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name} - Average: {student.GetAverageScore():F2}");
        }
    }
}
