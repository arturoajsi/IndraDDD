using Indra.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Indra.Web.Dto
{
    public class StudentDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

        public static StudentEntity MaptoStudentEntity(StudentDto studentDto)
        {
            return new StudentEntity
            {
                Name = studentDto.Name,
                Surname = studentDto.Surname,
                Birthday = studentDto.Birthday
            };
        }

        public static StudentDto MaptoStudentDto(StudentEntity studentEntity)
        {
            return new StudentDto
            {
                Name = studentEntity.Name,
                Surname = studentEntity.Surname,
                Birthday = studentEntity.Birthday
            };
        }

        public static IEnumerable<StudentDto> MaptoStudentDtoList(IEnumerable<StudentEntity> students)
        {
            List<StudentDto> studentsList = new List<StudentDto>();
            foreach (StudentEntity student in students)
            {
                studentsList.Add(MaptoStudentDto(student));
            }
            return studentsList;

        }

    }
}
