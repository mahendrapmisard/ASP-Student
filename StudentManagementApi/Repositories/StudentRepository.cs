
using StudentManagementApi.Models;

namespace StudentManagementApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Mahendra", Age = 24, Course = "CSharp" },
            new Student { Id = 2, Name = "Madan", Age = 25, Course = "SQL" },
            new Student { Id = 3, Name = "Kavya", Age = 23, Course = "Angular" }
        };

        public List<Student> GetAll()
        {
            return students;
        }

        public Student? GetById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Student student)
        {
            students.Add(student);
        }

        public void Update(Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);

            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Age = student.Age;
                existingStudent.Course = student.Course;
            }
        }

        public void Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                students.Remove(student);
            }
        }
    }
}
