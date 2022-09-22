using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CourseSchedule.Core.DBModel
{
    public enum LogicalOperator
    {
        OR,
        AND
    }
    public class Combination : CourseScheduleEntity
    {
        public Guid Id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LogicalOperator LogicalOperator { get; set; }

        // Navigation Properties
        public ICollection<CourseCombination> CourseCombinations { get; set; }
    }
}
