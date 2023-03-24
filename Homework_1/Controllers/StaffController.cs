using Homework.Data;
using Homework.Data.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Homework_1.Controllers;

[Route("homework/api/v1.0/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private AppDbContext context;
    public StaffController(IUnitOfWork unitOfWork, AppDbContext context)
    {
        this.unitOfWork = unitOfWork;
        this.context = context;
    }


    [HttpGet]
    public List<Staff> GetAll()
    {
        
        List<Staff> staffList = unitOfWork.StaffRepository.GetAll();
        return staffList;
    }

    [HttpGet("{id}")]
    public Staff GetById(int id)
    {
        
        Staff staff = context.Staff.Find(id);
        
        return staff;
    }

    [HttpPost]
    public void Post([FromBody] Staff request)
    {
        unitOfWork.StaffRepository.Insert(request);
        unitOfWork.Complete();
    }


    [HttpPut("{id}")]
    public void Put([FromRoute] int id, [FromBody] Staff request)
    {
        request.Id = id;
        unitOfWork.StaffRepository.Update(request);
        unitOfWork.Complete();
    }

    [HttpDelete("{id}")]
    public void Remove(int id)
    {
        unitOfWork.StaffRepository.Remove(id);
        unitOfWork.Complete();
    }
    [HttpGet("Filter")]
    public List<Staff> GetByCreatedByAndCountry([FromQuery] string CreatedBy, string Country)
    {
        List<Staff> list = unitOfWork.StaffRepository.GetAll();
        var filteredEntity = list.Where(x => x.CreatedBy.Equals(CreatedBy) && x.Country.Equals(Country));
        return filteredEntity.ToList();
    }


}
