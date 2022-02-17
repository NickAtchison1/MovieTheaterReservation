using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieTheaterReservation.Data.Models;

namespace MovieTheaterReservation.Data.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Auditorium> Auditoriums { get; set; }
        public DbSet<MovieShowing> MoviesShowings { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
    }
}