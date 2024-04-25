﻿namespace HR.LeaveManagement.Application.DTOs.LeaveRequests;

public interface ILeaveRequestDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LeaveTypeId { get; set; }
}
