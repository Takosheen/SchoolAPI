﻿using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;
using System.Linq;

namespace Repository
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Student> GetAllStudents(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.UserName)
                .ToList();

        public Student GetStudent(Guid companyId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(companyId), trackChanges)
                .SingleOrDefault();
        public void CreateStudent(Student student) => Create(student);
        public IEnumerable<Student> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToList();


        public void DeleteStudent(Student student)
        {
            Delete(student);
        }
    }
}