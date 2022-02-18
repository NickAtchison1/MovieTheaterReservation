using Microsoft.EntityFrameworkCore;
using MovieTheaterReservation.Data.Data;
using MovieTheaterReservation.Data.Models;
using MovieTheaterReservation.Shared.DisplayModels.Auditorium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservation.Services.Services.AuditoriumService
{
    public class AuditoriumService : IAuditoriumService
    {
        private readonly ApplicationDbContext _context;

        public AuditoriumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAuditorium(AuditoriumCreate auditoriumCreate, string userId)
        {
            var auditoriumEntity = new Auditorium()
            {
                Name = auditoriumCreate.Name,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                UpdatedBy = userId,
                UpdatedDate = DateTime.Now,
            };
            _context.Auditoriums.Add(auditoriumEntity);
            return await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<AuditoriumListItem>> GetAllAuditoriums()
        {
            var query = await _context.Auditoriums
                .Select(a => new AuditoriumListItem()
                {
                    Name = a.Name,
                }).ToListAsync();

            return query;
        }

        public async Task<AuditoriumDetail> GetAuditoriumById(int id)
        {
            var auditoriumEntity = await _context.Auditoriums.SingleAsync(a => a.Id == id);
            var auditoriumDetail = new AuditoriumDetail()
            {
                Name = auditoriumEntity.Name,
            };
            return auditoriumDetail;
        }

        public async Task<bool> UpdateAuditorium(AuditoriumEdit auditoriumEdit, string userId)
        {
            var auditoriumToUpdate = await _context.Auditoriums.SingleAsync(a => a.Id == auditoriumEdit.AuditoriumId);
            auditoriumToUpdate.Name = auditoriumEdit.Name;
            auditoriumToUpdate.CreatedBy = auditoriumToUpdate.CreatedBy;
            auditoriumToUpdate.CreatedDate = auditoriumToUpdate.CreatedDate;
            auditoriumToUpdate.UpdatedBy = userId;
            auditoriumToUpdate.UpdatedDate = DateTime.Now;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAuditorium(int id)
        {
            var auditoriumToDelete = await _context.Auditoriums.SingleAsync(a => a.Id == id);
            _context.Auditoriums.Remove(auditoriumToDelete);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
