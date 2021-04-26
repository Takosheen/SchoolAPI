using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses(bool trackChanges);
        Course GetCourse(Guid companyId, bool trackChanges);
        void CreateCourse(Course course);
        IEnumerable<Course> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteCourse(Course course);
    }
}
