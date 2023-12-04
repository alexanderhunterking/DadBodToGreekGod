using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data;
using DadBodToGreekGod.Data.Entities;
using DadBodToGreekGod.Models.UserMealAssignment;
using Microsoft.EntityFrameworkCore;

namespace DadBodToGreekGod.Services.UserMealAssignment
{
    
public class UserMealAssignmentService : IUserMealAssignmentService
{
    private readonly ApplicationDbContext _context;

    public UserMealAssignmentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> AssignMealToUserAsync(AssignMealToUserModel assignModel)
    {
        var userMealAssignmentEntity = new UserMealAssignmentEntity
        {
            UserId = assignModel.UserId,
            MealId = assignModel.MealId,
            TimeOfDay = assignModel.TimeOfDay,
            // Add other properties as needed
        };

        _context.UserMealAssignments.Add(userMealAssignmentEntity);
        await _context.SaveChangesAsync();

        return userMealAssignmentEntity.UserMealAssignmentId;
    }

    public async Task<List<UserMealAssignmentListItemModel>> GetUserMealAssignmentsAsync(int userId)
    {
        var userMealAssignments = await _context.UserMealAssignments
            .Where(uma => uma.UserId == userId)
            .Select(uma => new UserMealAssignmentListItemModel
            {
                UserMealAssignmentId = uma.UserMealAssignmentId,
                MealId = uma.MealId,
                TimeOfDay = uma.TimeOfDay,
                // Add other properties as needed
            })
            .ToListAsync();

        return userMealAssignments;
    }

    public async Task UpdateUserMealAssignmentAsync(int userMealAssignmentId, UpdateUserMealAssignmentModel updateModel)
    {
        var userMealAssignmentEntity = await _context.UserMealAssignments.FindAsync(userMealAssignmentId);

        if (userMealAssignmentEntity == null)
        {
            // Handle not found
            return;
        }

        userMealAssignmentEntity.TimeOfDay = updateModel.TimeOfDay;
        // Update other properties as needed

        await _context.SaveChangesAsync();
    }

    public async Task RemoveMealFromUserAsync(int userMealAssignmentId)
    {
        var userMealAssignmentEntity = await _context.UserMealAssignments.FindAsync(userMealAssignmentId);

        if (userMealAssignmentEntity == null)
        {
            // Handle not found
            return;
        }

        _context.UserMealAssignments.Remove(userMealAssignmentEntity);
        await _context.SaveChangesAsync();
    }
}
}