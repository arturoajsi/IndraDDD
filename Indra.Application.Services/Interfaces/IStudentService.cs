using Indra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Application.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentEntity>> GetAllStudents();
        Task<StudentEntity> GetStudentById(int id);
        Task<StudentEntity> AddStudent(StudentEntity student);
        Task<StudentEntity> UpdateStudent(int id, StudentEntity studentEntity);
        void DeleteStudent(int id);
    }
}
