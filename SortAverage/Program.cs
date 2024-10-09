using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAverage
{
    class Student
    {
        public string Name { get; set; }
        public Dictionary<string, int> Scores { get; set; }

        public Student(string name, int math, int physic, int chemistry)
        {
            Name = name;
            Scores = new Dictionary<string, int>
        {
            { "Math", math },
            { "Physic", physic },
            { "Chemistry", chemistry }
        };
        }

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

    internal class Program
    {
        static void Main(string[] args)
        {
            //khởi tạo array với dữ liệu ngẫu nhiên
            List<Student> students = new List<Student>
        {
            new Student("Alice", 9, 8, 7),
            new Student("Bob", 6, 7, 5),
            new Student("Charlie", 8, 8, 8),
            new Student("David", 9, 7, 9),
            new Student("Eve", 7, 7, 7)
        };

            BubbleSort(students);
            var targetStudent = FindStudentWithAverage(students, 8);

            Console.WriteLine("DS sau khi sap xep:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name} - co Diem TB: {student.GetAverageScore():F2}");
            }

            // Kết quả 
            if (targetStudent != null)
            {
                Console.WriteLine($"HS: {targetStudent.Name} co Diem TB = 8");
            }
            else
            {
                Console.WriteLine("Khong hs nao co Diem TB = 8");
            }
        }

        static void BubbleSort(List<Student> students)
        {
            int n = students.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    double avg1 = students[j].GetAverageScore();
                    double avg2 = students[j + 1].GetAverageScore();

                    // So sánh điểm trung bình, so sánh tên
                    if (avg1 < avg2 || (avg1 == avg2 && string.Compare(students[j].Name, students[j + 1].Name) > 0))
                    {
                        var temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
        }

        //Tìm học sinh có điểm trung bình bằng 8
        static Student FindStudentWithAverage(List<Student> students, double targetAvg)
        {
            foreach (var student in students)
            {
                if (Math.Abs(student.GetAverageScore() - targetAvg) < 0.001)
                {
                    return student;
                }
            }
            return null;
        }
    }
}
