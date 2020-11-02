using Adform_Todo.Common.Contracts;
using Adform_Todo.Common.Dtos;
using Adform_Todo.Common.Models;
using Adform_ToDo.BL;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adform_ToDo.Tests.ServiceTests
{
    /// <summary>
    /// Label service tests.
    /// </summary>
    public class LabelManagerTest
    {
        private Mock<ILabelDal> _labelDbOps;
        private ILabelManager _labelContract;
        private int _userId;
        private readonly LabelDto _labelDto = new LabelDto { LabelId = 1, Description = "TestLabel" };
        readonly List<LabelDto> _labelDtos = new List<LabelDto>();
        readonly PaginationParameters paginationParameters = new PaginationParameters()
        {
            PageNumber = 1,
            PageSize = 10,
            SearchString = "SearchText"
        };

        /// <summary>
        /// Setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _labelDbOps = new Mock<ILabelDal>();
            _labelContract = new LabelManager(_labelDbOps.Object);
            _labelDbOps.Setup(p => p.AddLabel(It.IsAny<CreateLabelDto>())).Returns(Task.FromResult(_labelDto));
            _labelDbOps.Setup(p => p.DeleteLabel(It.IsAny<long>(), It.IsAny<long>())).Returns(Task.FromResult(1));
            _labelDbOps.Setup(p => p.GetLabelById(It.IsAny<long>(), It.IsAny<long>())).Returns(Task.FromResult(_labelDto));
            _labelDbOps.Setup(p => p.GetAllLabels(It.IsAny<long>())).Returns(Task.FromResult(_labelDtos));
        }

        /// <summary>
        /// Add label test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task AddLabelTest()
        {
            LabelDto result = await _labelContract.AddLabel(new CreateLabelDto() { Description = "TestLabel", CreatedBy = _userId });
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.LabelId);
        }

        /// <summary>
        /// Add label test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task DeleteLabelTest()
        {
            int result = await _labelContract.DeleteLabel(1, _userId);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task GetLabels()
        {
            PagedList<LabelDto> result = await _labelContract.GetAllLabels(paginationParameters, _userId);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetLabeById()
        {
            LabelDto result = await _labelContract.GetLabelById(1, 1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.LabelId);
        }

    }
}
