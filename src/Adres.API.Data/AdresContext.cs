using Adres.API.Data.Configurations;
using Adres.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;
using System;

namespace Adres.API.Data
{
    public class AdresContext : DbContext
    {
        private readonly string _defaultSchema;
        public string DbPath { get; }
        internal DbSet<AcquisitionRequirement> AcquisitionRequirement { get; set; }
       

        public AdresContext(DbContextOptions<AdresContext> options, IConfiguration settings)
            : base(options)
        {           
            _defaultSchema = settings.GetConnectionString("DefaultSchema");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Remove<DiscriminatorLengthConvention>();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(_defaultSchema);            
            builder.ApplyConfiguration(new AcquisitionRequirementConfiguration());
                     
        }
    }
}