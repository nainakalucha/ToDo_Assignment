using Adform_Todo.Common.Dtos;
using Adform_Todo.Common.Models;
using Adform_ToDo.DAL;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adform_ToDo.Tests.DALTests
{
    public class LabelDalTest : ToDoDbContextInitiator
    {
        private readonly LabelDal _labelDal;
        public LabelDalTest()
        {
            _labelDal = new LabelDal(DBContext, Mapper);
            DBContext.Labels.Add(new LabelEntity
            {
                Description = "LabelTest",
                CreatedBy = 1,
            });
            DBContext.SaveChanges();
        }

        /// <summary>
        /// Get labels test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetLabels()
        {
            List<LabelDto> LabelList = await _labelDal.GetAllLabels(1);
            int count = LabelList.Count;
            Assert.IsTrue(count > 0);
        }

        /// <summary>
        /// Add label test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task AddLabel()
        {
            LabelDto addedLabel = await _labelDal.AddLabel(new CreateLabelDto { Description = "NewLabel", CreatedBy = 1 });
            Assert.IsNotNull(addedLabel);
            Assert.AreEqual("NewLabel", addedLabel.Description);
        }

        /// <summary>
        /// test to delete existing Label record.
        /// </summary>
        [Test]
        public async Task DeleteLabel()
        {
            int deleteResult = await _labelDal.DeleteLabel(1, 1);
            Assert.IsNotNull(deleteResult);
            Assert.AreEqual(1, deleteResult);
        }
    }
}