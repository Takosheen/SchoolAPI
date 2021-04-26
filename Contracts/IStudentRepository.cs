using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;


namespace Contracts
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents(bool trackChanges);
        Student GetStudent(Guid companyId, bool trackChanges);
        void CreateStudent(Student student);
        IEnumerable<Student> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteStudent(Student student);
    }
}
