using Golestan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golestan.Contracts
{
    public interface ITeacherRepository
    {

        List<Teacher>  GetTeachers();
        Teacher GetTeacher(int id);
    }
}
