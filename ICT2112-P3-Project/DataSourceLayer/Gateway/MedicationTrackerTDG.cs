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
    public class MedicationTrackerTDG : IMedicationTrackerTDG
    {
        private readonly DataContext _context;
        public async Task CreateMedicationTrackerAsync(MedicationTracker newTracker)
        {
            await _context.MedicationTrackers.AddAsync(newTracker);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMedicationTrackerAsync(int trackerId)
        {
            var tracker = await _context.MedicationTrackers.FindAsync(trackerId);
            if (tracker != null)
            {
                _context.MedicationTrackers.Remove(tracker);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("MedicationTracker not found.", nameof(trackerId));
            }
        }

        public async Task<MedicationTracker> GetMedicationTrackerById(int trackerId)
        {
            var tracker = await _context.MedicationTrackers.FindAsync(trackerId);
            if (tracker == null)
            {
                throw new KeyNotFoundException($"A MedicationTracker with the ID {trackerId} was not found.");
            }
            return tracker;
        }

        public async Task UpdateMedicationTrackerAsync(MedicationTracker existingTracker)
        {
            _context.Entry(existingTracker).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}