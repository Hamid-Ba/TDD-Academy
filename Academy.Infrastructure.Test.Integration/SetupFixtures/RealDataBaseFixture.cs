using System;
using System.Transactions;
using Academy.Domain.Entities;
using Academy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Test.Integration.SetupFixtures
{
    public class RealDataBaseFixture : IDisposable
    {
        public AcademyContext Context;
        private readonly TransactionScope _scope;

        public RealDataBaseFixture()
        {
            var option = new DbContextOptionsBuilder<AcademyContext>()
                .UseSqlServer(
                    "Data Source = HamidBa\\MySqlServer;Initial Catalog=TddAcademyDB;Integrated Security = true")
                .Options;
            Context = new AcademyContext(option);

            _scope = new TransactionScope();

            var asp = new Course(0, "Asp", true, 700, "Hamid");
            var tdd = new Course(0, "Tdd And Bdd", true, 300, "Hamid");
            var webDesign = new Course(0, "Web Design", true, 400, "Khosro");

            Context.Add(asp);
            Context.Add(tdd);
            Context.Add(webDesign);

            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
            _scope.Dispose();
        }
    }
}
