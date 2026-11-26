using StudentManagementApi.DTOs;
using StudentManagementApi.Models;

namespace StudentManagementApi.Mappings
{
    public static class StudentMapping
    {
        public static Student ToStudent(this CreateStudentDto dto)
        {
            return new Student
            {
                Name = dto.Name,
                Age = dto.Age,
                Course = dto.Course
            };
        }

        public static StudentResponseDto ToResponseDto(this Student student)
        {
            return new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                Course = student.Course
            };
        }

        public static List<StudentResponseDto> ToResponseDto(this List<Student> students)
        {
            return students.Select(s => s.ToResponseDto()).ToList();
        }
    }
}