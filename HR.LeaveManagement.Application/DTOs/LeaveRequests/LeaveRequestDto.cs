﻿using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using HR.LeaveManagement.Application.Models.Identity;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequests;

public class LeaveRequestDto : BaseDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Employee Employee { get; set; }
    public string RequestingEmployeeId { get; set; }
    public LeaveTypeDto LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public string RequestComments { get; set; }
    public DateTime? DateActioned { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
}
