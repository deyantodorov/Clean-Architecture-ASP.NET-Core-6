using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Profiles;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Application.UnitTests.Mocks;

using Moq;

using Shouldly;

using Xunit;

namespace HR.LeaveManagement.Application.UnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly CreateLeaveTypeDto _createLeaveTypeDto;

        public CreateLeaveTypeCommandHandlerTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfiles>();
            });

            _mapper = mapperConfig.CreateMapper();

            _createLeaveTypeDto = new CreateLeaveTypeDto
            {
                DefaultDays = 15,
                Name = "Test Dto"
            };
        }

        [Fact]
        public async Task Valid_LeaveType_Add()
        {
            var handler = new CreateLeaveTypeCommandHandler(_unitOfWork.Object.LeaveTypeRepository, _mapper);

            var result = await handler.Handle(new CreateLeaveTypeCommand { CreateLeaveTypeDto = _createLeaveTypeDto}, CancellationToken.None);

            var leaveTypes = await _unitOfWork.Object.LeaveTypeRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();
            leaveTypes.Count.ShouldBe(3);
        }

        [Fact]
        public async Task InValid_LeaveType_Add()
        {
            var handler = new CreateLeaveTypeCommandHandler(_unitOfWork.Object.LeaveTypeRepository, _mapper);

            _createLeaveTypeDto.DefaultDays = -1;

            var result = await handler.Handle(new CreateLeaveTypeCommand { CreateLeaveTypeDto = _createLeaveTypeDto }, CancellationToken.None);

            var leaveTypes = await _unitOfWork.Object.LeaveTypeRepository.GetAll();

            leaveTypes.Count.ShouldBe(2);
            result.ShouldBeOfType<BaseCommandResponse>();
        }
    }
}

