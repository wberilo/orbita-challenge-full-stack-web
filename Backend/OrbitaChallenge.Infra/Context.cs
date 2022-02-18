using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrbitaChallenge.Domain.StudentAggregate;

namespace OrbitaChallenge.Infra
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options): base(options)
        {

        }

        public DbSet<Student> Students { get; set;}

    }
}
