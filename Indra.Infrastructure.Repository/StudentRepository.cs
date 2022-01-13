using Indra.Infrastructure.Data.Model;
using Indra.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indra.Infrastructure.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DatabaseContext context;

        public StudentRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var student = await context.Student.ToListAsync();
            return student;
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await context.Student.FirstOrDefaultAsync(d => d.Id == id);
            return student;
        }

        public async Task<Student> AddStudent(Student student)
        {
            context.Student.AddAsync(student);
            await context.SaveChangesAsync();
            return student;
        }

        public async void DeleteStudent(int id)
        {
            var student = context.Student.FirstOrDefault(d => d.Id == id);
            if (student != null)
            {
                context.Student.Remove(student);
                context.SaveChangesAsync();
            }
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var Dbstudent = await context.Student.FirstOrDefaultAsync(d => d.Id == student.Id);
            if (Dbstudent != null)
            {
                Dbstudent.Name = student.Name;
                Dbstudent.Surname = student.Surname;
                Dbstudent.Birthday = student.Birthday;
                Dbstudent.Age = student.Age;
                await context.SaveChangesAsync();
                return Dbstudent;
            }
            return null;
        }
    }
}
