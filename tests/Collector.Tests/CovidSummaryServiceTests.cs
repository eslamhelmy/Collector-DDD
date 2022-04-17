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
    public class CovidSummaryServiceTests
    {
        private Mock<ICovidSummaryRepository> _covidSummaryRepository;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void SetUp()
        {
            _covidSummaryRepository = new Mock<ICovidSummaryRepository>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task GetSummaryAsync_VerifySummaryRepositoryIsCalled_ReturnsTrue()
        {
            //arrange
            var model = new CovidHistory();
            var viewModel = new CovidHistoryCreateViewModel();
            var service = new CovidSummaryService(_covidSummaryRepository.Object, _mapper.Object);

            //act
            await service.GetSummaryAsync();
            
            //assert
            _covidSummaryRepository.Verify(fk => fk.GetSummaryAsync(), Times.Once);
        }

     
    }
}