using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICourseRepository Course { get; }
        IStudentRepository Student { get; }

        void Save();
    }
}
