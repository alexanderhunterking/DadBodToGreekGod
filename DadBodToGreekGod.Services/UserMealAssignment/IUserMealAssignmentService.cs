using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.UserMealAssignment;

namespace DadBodToGreekGod.Services.UserMealAssignment
{
    public interface IUserMealAssignmentService
    {
        Task<int> AssignMealToUserAsync(AssignMealToUserModel assignModel);

        Task<IEnumerable<UserMealAssignmentListItemModel>> GetUserMealAssignmentsAsync();

        Task UpdateUserMealAssignmentAsync(int userMealAssignmentId, UpdateUserMealAssignmentModel updateModel);

        Task RemoveMealFromUserAsync(int userMealAssignmentId);
    }
}