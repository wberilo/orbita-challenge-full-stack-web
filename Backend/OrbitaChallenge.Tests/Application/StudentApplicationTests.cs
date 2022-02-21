using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using OrbitaChallenge.Application.Commands;
using OrbitaChallenge.Application.Commands.CreateStudent;
using OrbitaChallenge.Application.Commands.DeleteStudent;
using OrbitaChallenge.Application.Queries.GetAllStudents;
using OrbitaChallenge.Application.Queries.GetStudentByRA;
using OrbitaChallenge.Domain.StudentAggregate;
using OrbitaChallenge.Infra;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OrbitaChallenge.Tests
{
    public class StudentApplicationTests
    {
        protected DbContextOptions<Context> options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Students")
                .Options;
        protected async Task ClearMemoryDb(Context context)
        {
            context.Students.RemoveRange(context.Students);
            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task CreateStudentCommandHandled()
        {
            using var context = new Context(options);
            //Arange
            CreateStudentCommandInput command = new("carlos", "carlos@gmail.com", "1234", "11111111111");
            CreateStudentCommandHandler handler = new(context);
            //Act
            await handler.Handle(command, new System.Threading.CancellationToken());

            var student = await context.Students.FirstOrDefaultAsync();
            //Asert
            Assert.Equal("carlos", student.Nome);
            Assert.Equal("carlos@gmail.com", student.Email);
            Assert.Equal("1234", student.RA);
            Assert.Equal("11111111111", student.CPF);

            await ClearMemoryDb(context);
        }
        [Fact]
        public async Task DeleteStudentCommandHandled()
        {
            using var context = new Context(options);

            //Arange
            context.Students.Add(new Student("carlos", "carlos@gmail.com", "1234", "11111111111"));
            context.SaveChanges();
            DeleteStudentCommandInput command = new("1234");
            DeleteStudentCommandHandler handler = new(context);
            //Act
            await handler.Handle(command, new System.Threading.CancellationToken());

            var students = await context.Students.ToListAsync();
            //Asert
            Assert.Empty(students);

            await ClearMemoryDb(context);
        }

        [Fact]
        public async Task UpdateStudentCommandHandled()
        {
            using var context = new Context(options);

            //Arange
            context.Students.Add(new Student("carlos", "carlos@gmail.com", "1234", "11111111111"));
            context.SaveChanges();
            UpdateStudentCommandInput command = new("ricardo", "ricardo@gmail.com", "1234");
            UpdateStudentCommandHandler handler = new(context);
            //Act
            await handler.Handle(command, new System.Threading.CancellationToken());

            var student = await context.Students.FirstOrDefaultAsync();
            //Asert
            Assert.Equal("ricardo", student.Nome);
            Assert.Equal("ricardo@gmail.com", student.Email);

            await ClearMemoryDb(context);
        }
        [Fact]
        public async Task GetAllStudentsCommandHandled()
        {
            using var context = new Context(options);

            //Arange
            context.Students.Add(new Student("carlos", "carlos@gmail.com", "1234", "11111111111"));
            context.Students.Add(new Student("pedro", "pedro@gmail.com", "1235", "11111111111"));
            context.Students.Add(new Student("break", "ricardo@gmail.com", "1236", "11111111111"));
            context.SaveChanges();
            GetAllStudentsQueryInput command = new();
            GetAllStudentsQueryHandler handler = new(context);
            //Act
            var response = await handler.Handle(command, new System.Threading.CancellationToken());

            //Asert
            Assert.Equal(3, response.Items.Count);

            await ClearMemoryDb(context);
        }
        [Fact]
        public async Task GetStudentByRaCommandHandled()
        {
            using var context = new Context(options);

            //Arange
            context.Students.Add(new Student("carlos", "carlos@gmail.com", "1234", "11111111111"));
            context.Students.Add(new Student("pedro", "pedro@gmail.com", "1235", "11111111112"));
            context.Students.Add(new Student("ricardo", "ricardo@gmail.com", "1236", "11111111113"));
            context.SaveChanges();
            GetStudentByRAQueryInput command = new("1235");
            GetStudentByRAQueryHandler handler = new(context);
            //Act
            var response = await handler.Handle(command, new System.Threading.CancellationToken());

            //Asert
            Assert.Equal("pedro", response.Nome);
            Assert.Equal("pedro@gmail.com", response.Email);
            Assert.Equal("1235", response.RA);
            Assert.Equal("11111111112", response.CPF);

            await ClearMemoryDb(context);
        }
    }
}
