using Indra.Application.Services.Interfaces;
using Indra.Domain.Entities;
using Indra.Infrastructure.Data.Model;
using Indra.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Application.Services.Implementations
{
    public class StudentService : IStudentService
    {
        IStudentRepository _iStudentRepository;

        public StudentService(IStudentRepository iStudentRepository)
        {
            _iStudentRepository = iStudentRepository;
        }

        public async Task<IEnumerable<StudentEntity>> GetAllStudents()
        {
            IEnumerable<Student> studentsGet = await _iStudentRepository.GetAllStudents();
            return StudentEntity.MaptoStudentEntityList(studentsGet);
        }

        public async Task<StudentEntity> GetStudentById(int id)
        {
            Student studentGet = await _iStudentRepository.GetStudentById(id);
            return StudentEntity.MaptoStudentEntity(studentGet);
        }

        public async Task<StudentEntity> AddStudent(StudentEntity studentEntity)
        {
            studentEntity.Age = CalculatedAge(studentEntity.Birthday);
            Student studentAdded = await _iStudentRepository.AddStudent(
                                StudentEntity.MaptoStudent(studentEntity));
            return StudentEntity.MaptoStudentEntity(studentAdded);
        }

        public async Task<StudentEntity> UpdateStudent(int id, StudentEntity studentEntity)
        {
            Student studentUpdate = StudentEntity.MaptoStudent(studentEntity);
            studentUpdate.Id = id;
            await _iStudentRepository.UpdateStudent(studentUpdate);
            return StudentEntity.MaptoStudentEntity(studentUpdate);
        }

        public void DeleteStudent(int id)
        {
            _iStudentRepository.DeleteStudent(id);
        }

        public int CalculatedAge(DateTime birthday)
        {
            int age = 0;
            age = DateTime.Now.Year - birthday.Year;
            if (DateTime.Now.DayOfYear < birthday.DayOfYear)
                age--;

            return age;
        }


    }
}
