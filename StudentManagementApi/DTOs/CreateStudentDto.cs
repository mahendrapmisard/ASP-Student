namespace StudentManagementApi.DTOs
{
   
        public class CreateStudentDto
        {
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; }
            public string Course { get; set; } = string.Empty;
        }
    }

