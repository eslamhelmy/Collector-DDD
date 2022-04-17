using AutoMapper;
using Collector.Domain.Base;
using Collector.Domain.Entities;
using Collector.Domain.Interfaces.Repositories;
using Collector.Domain.Interfaces.UnitOfWork;
using Collector.Domain.ViewModels;
using Collector.Infrastructure.Services;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Collector.Tests
{
    public class CovidHistoryServiceTests
    {
        private Mock<ICovidHistoryRepository> _covidHistoryRepository;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void SetUp()
        {
            _covidHistoryRepository = new Mock<ICovidHistoryRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task AddAsync_whenCalled_ReturnNewEntityId()
        {
            //arrange
            var model = new CovidHistory();
            var viewModel = new CovidHistoryCreateViewModel();
            var service = new CovidHistoryService(_covidHistoryRepository.Object, _unitOfWork.Object, _mapper.Object);
            _mapper.Setup(m => m.Map<CovidHistory>(viewModel)).Returns(model);
            _covidHistoryRepository.Setup(fk => fk.AddAsync(model))
                              .Returns(Task.FromResult(new CovidHistory { Id = 1 }));
            //act
            var res = await service.AddAsync(viewModel);

            //assert
            Assert.That(res.Data, Is.EqualTo(1));
        }

        [Test]
        public async Task UpdateAsync_EntityExist_ReturnsTrue()
        {
            //arrange
            var model = new CovidHistory();
            var viewModel = new CovidHistoryEditViewModel { Id = 1};
            var service = new CovidHistoryService(_covidHistoryRepository.Object, _unitOfWork.Object, _mapper.Object);
            _mapper.Setup(m => m.Map<CovidHistory>(viewModel)).Returns(model);
            _covidHistoryRepository.Setup(fk => fk.GetByIdAsync(viewModel.Id))
                              .Returns(Task.FromResult<CovidHistory>(model));
            //act
            var res = await service.UpdateAsync(viewModel);

            //assert
            Assert.That(res.Status, Is.EqualTo(true));
        }

        [Test]
        public async Task DeleteAsync_EntityNotExist_ReturnsFalse()
        {
            //arrange
            var model = new CovidHistory();
            var viewModel = new CovidHistoryCreateViewModel();
            var service = new CovidHistoryService(_covidHistoryRepository.Object, _unitOfWork.Object, _mapper.Object);
            _mapper.Setup(m => m.Map<CovidHistory>(viewModel)).Returns(model);
            _covidHistoryRepository.Setup(fk => fk.GetByIdAsync(1))
                              .Returns(Task.FromResult<CovidHistory>(null));
            //act
            var res = await service.DeleteAsync(1);
           
            //assert
            Assert.That(res.Status, Is.EqualTo(false));
        }
    }
}