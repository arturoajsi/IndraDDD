using Indra.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Infrastructure.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        void DeleteStudent(int id);


    }
}
