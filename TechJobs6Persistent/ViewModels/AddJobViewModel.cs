using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TechJobs6Persistent.Models;
namespace TechJobs6Persistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required(ErrorMessage = "Enter Valid Job ")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Enter Valid Job Name ")]
        public string JobName { get; set; }

        [Required(ErrorMessage = "Employer Name is required")]
        public int EmployerId { get; set; }

        public List<SelectListItem> Employers { get; set; } = new List<SelectListItem>();

        public AddJobViewModel(List<Employer> possibleEmployers)
        {
            foreach (var employer in possibleEmployers)
            {
                /*Employers.Add(new SelectListItem
                {
                    Text = employer.Name,
                    Value = employer.Id.ToString()
                });*/ // refactoring 
                Employers = possibleEmployers.Select(employer => new SelectListItem
                {
                    Text = employer.Name,
                    Value = employer.Id.ToString()
                }).ToList();
            }
        }
        public AddJobViewModel() { }
    }

}
