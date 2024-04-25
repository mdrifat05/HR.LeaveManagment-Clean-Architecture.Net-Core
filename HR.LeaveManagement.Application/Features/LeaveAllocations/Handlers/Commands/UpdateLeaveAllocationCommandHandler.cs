﻿using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveAllocations.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;

public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
       _unitOfWork = unitOfWork;    
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveAllocationDtoValidator(_unitOfWork.LeaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.UpdateleaveAllocationDto);
        if (validationResult.IsValid == false) 
        {
            throw new ValidationException(validationResult);
        }
        var leaveAllocation = await _unitOfWork.LeaveAllocationRepository.Get(request.UpdateleaveAllocationDto.Id);
        if (leaveAllocation is null)
        {
            throw new NotFoundException(nameof(leaveAllocation), request.UpdateleaveAllocationDto.Id);
        }
            
        _mapper.Map(request.UpdateleaveAllocationDto, leaveAllocation);
        await _unitOfWork.LeaveAllocationRepository.Update(leaveAllocation);
        await _unitOfWork.Save();
        return Unit.Value;
    }
}
