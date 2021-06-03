﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace EJournalBLL.Models
{
    class ProjectGroup
    {
        public int Id;
        public string Name { get; set; }
      
        public bool IsDelete { get; set; }

        public List<Student> Students { get; set; }

        public override bool Equals(object obj)
        {
            bool equal = false;

            ProjectGroup project = obj as ProjectGroup;

            if (project != null && Id == project.Id && Name == project.Name && IsDelete == project.IsDelete )
            {
                equal = Students.SequenceEqual(project.Students);
            }
            return equal;
        }
    }
}