﻿using System;
using System.Collections.Generic;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class BaseViewModel
    {
        public string Title { get; set; } = "";
        public List<JobFieldType> Columns { get; set; }

        public BaseViewModel()//this is the constructor merged from SearchJobsViewModel and JobsFieldViewModel
        {
            // Populate the list of all columns

            Columns = new List<JobFieldType>();

            foreach (JobFieldType enumVal in Enum.GetValues(typeof(JobFieldType)))
            {
                Columns.Add(enumVal);
            }


        }

    }

}
