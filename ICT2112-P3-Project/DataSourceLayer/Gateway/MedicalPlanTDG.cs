using DataSourceLayer.Data;
using DomainLayer.Entity;
using DomainLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourceLayer.Gateway
{
    public class MedicalPlanTDG : IMedicalPlanTDG
    {
        private readonly DataContext _context;

        public MedicalPlanTDG(DataContext context)
        {
            _context = context;
        }

        public async Task<PatientMedicalPlan> GetMedicalPlanByIdAsync(int planId)
        {
            // Use FindAsync for fetching entities by primary key
            return await _context.PatientMedicalPlans.FindAsync(planId);
        }

        public async Task CreateMedicalPlanAsync(PatientMedicalPlan newPlan)
        {
            // Use AddAsync for adding entities
            await _context.PatientMedicalPlans.AddAsync(newPlan);
            // Use SaveChangesAsync to asynchronously save changes to the database
            await _context.SaveChangesAsync();
        }
        public async Task UpdateMedicalPlanAsync(PatientMedicalPlan existingPlan)
        {
            // Attach the entity and mark it as modified if it's not being tracked
            if (!_context.PatientMedicalPlans.Local.Any(e => e == existingPlan))
            {
                _context.PatientMedicalPlans.Attach(existingPlan);
                _context.Entry(existingPlan).State = EntityState.Modified;
            }

            // No AddAsync needed here since you're updating an existing entity
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMedicalPlanAsync(int planId)
        {
            var existingPlan = await _context.PatientMedicalPlans.FindAsync(planId);
            if (existingPlan != null)
            {
                _context.PatientMedicalPlans.Remove(existingPlan);
                await _context.SaveChangesAsync();
            }
        }
    }
}