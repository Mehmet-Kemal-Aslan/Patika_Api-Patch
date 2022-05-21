using System.ComponentModel.DataAnnotations;


namespace StudentWebApi.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Grade is required.")]
        public int Grade { get; set; }
        public string Note { get; set; }
    }
}
