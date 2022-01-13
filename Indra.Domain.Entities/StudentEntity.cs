using Indra.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;

namespace Indra.Domain.Entities
{
    public class StudentEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }

        public static StudentEntity MaptoStudentEntity(Student student)
        {
            return new StudentEntity
            {
                Name = student.Name,
                Surname = student.Surname,
                Birthday = student.Birthday,
                Age = student.Age
            };
        }

        public static Student MaptoStudent(StudentEntity studentEntity)
        {
            return new Student
            {
                Name = studentEntity.Name,
                Surname = studentEntity.Surname,
                Birthday = studentEntity.Birthday,
                Age = studentEntity.Age
            };
        }

        public static IEnumerable<StudentEntity> MaptoStudentEntityList(IEnumerable<Student> students)
        {
            List<StudentEntity> studentsList = new List<StudentEntity>();
            foreach (Student student in students)
            {
                studentsList.Add(MaptoStudentEntity(student));
            }
            return studentsList;

        }

        public static IEnumerable<Student> MaptoStudentList(IEnumerable<StudentEntity> studentsEntity)
        {
            List<Student> studentsList = new List<Student>();
            foreach (StudentEntity student in studentsEntity)
            {
                studentsList.Add(MaptoStudent(student));
            }
            return studentsList;

        }
    }
}
