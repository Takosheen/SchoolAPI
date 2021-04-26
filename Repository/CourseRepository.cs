using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Course> GetAllCourses(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.CourseName)
                .ToList();

        public Course GetCourse(Guid companyId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(companyId), trackChanges)
                .SingleOrDefault();
        public void CreateCourse(Course course) => Create(course);
        public IEnumerable<Course> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToList();


        public void DeleteCourse(Course course)
        {
            Delete(course);
        }
    }
}
