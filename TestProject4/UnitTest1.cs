using Findergers1._0.Controllers;
using Findergers1._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestProject4
{
    public class Tests
    {
        public int Id { get; private set; }

        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void NewMissing()
        {
            DesappController controller = new DesappController();
            var result = controller.NewMissing() as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void Index()
        {
            DesappController controller = new DesappController();
            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void Edit()
            
        {
            DesappController controller = new DesappController();
            var result = controller.Edit(2) as ViewResult;
        }
        

    }
}