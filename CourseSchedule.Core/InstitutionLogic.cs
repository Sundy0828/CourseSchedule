using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseSchedule.Core.DBModel;

namespace CourseSchedule.Core
{
    public class InstitutionLogic
    {
        private readonly CourseScheduleDBContext _context;

        public InstitutionLogic(CourseScheduleDBContext context)
        {
            _context = context;
        }

        public Institution Create(string name)
        {
            Institution institution = new(name);

            _context.Add(institution);
            _context.SaveChanges();

            return institution;
        }

        public List<Institution> Get()
        {
            return _context.Institutions.OrderBy(i => i.Name).ToList();
        }
    }
}
