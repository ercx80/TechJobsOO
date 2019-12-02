using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // get the Job with the given ID and pass it into the view

            
            return View(jobData.Find(id)); //just pass this jobData method as a parameter in the view to find the id
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            if (ModelState.IsValid)//this conditional check if the properties in the view model are valid 
            {
                // Validate the ViewModel and if valid, create a 
                // new Job and add it to the JobData data store. Then
                // redirect to the Job detail (Index) action/view for the new Job.
                Job newJob = new Job { //here I created an object of Job class

                

                   Name = newJobViewModel.Name,//Here name is passed as a string because it was declared as a strinf in the Job Class
                   Employer =jobData.Employers.Find(newJobViewModel.EmployerID),//The rest of the properties are passes as int (IDs) because they are their own data types
                   Location = jobData.Locations.Find(newJobViewModel.LocationID),
                   CoreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetenciesID),
                   PositionType = jobData.PositionTypes.Find(newJobViewModel.PositionTypeID)

                };
                jobData.Jobs.Add(newJob);
                return Redirect("/Job?id=" + newJob.ID);

            }

            return View(newJobViewModel);
        }
    }
}
