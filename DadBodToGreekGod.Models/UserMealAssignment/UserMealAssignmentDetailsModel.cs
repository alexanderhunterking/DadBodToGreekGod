using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data.Entities;

namespace DadBodToGreekGod.Models.UserMealAssignment
{
    public interface UserMealAssignmentDetailsModel
    {
        public int UserMealAssignmentId { get; set; }

        public int UserId { get; set; }

        public int MealId { get; set; }

        public MealTime TimeOfDay { get; set; }
    }
}