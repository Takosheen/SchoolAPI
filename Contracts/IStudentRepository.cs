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
    }
}
