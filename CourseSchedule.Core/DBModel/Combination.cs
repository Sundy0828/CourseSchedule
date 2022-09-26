using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseSchedule.Core.DBModel
{
    public enum LogicalOperator
    {
        OR,
        AND
    }
    public class Combination : CourseScheduleEntity
    {
        public Combination()
        {
            Id = Guid.NewGuid();
            LogicalOperator = LogicalOperator.AND;

            CourseCombinations = new HashSet<CourseCombination>();
        }
        public Guid Id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LogicalOperator LogicalOperator { get; set; }

        // Navigation Properties
        public ICollection<CourseCombination> CourseCombinations { get; set; }
    }
}
