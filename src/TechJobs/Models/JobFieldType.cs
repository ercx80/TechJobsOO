using System.ComponentModel.DataAnnotations;

namespace TechJobs.Models
{
    public enum JobFieldType
    {
        // Enum representing the JobField properties of a Job
        // that can be viewed and searched.

        Employers,
        Location,
        CoreCompetency,
        PositionType,
        All
    }
}
