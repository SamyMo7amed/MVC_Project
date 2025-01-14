using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class CourseResult
    {

        public int Id { get; set; } 
        public int Degree { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public int TraineeId { get; set; }  

        [ForeignKey(nameof(TraineeId))]
        public Trainee Trainee { get; set; }    



    }
}
