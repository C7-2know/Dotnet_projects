using DriverAppApi.Services;
using DriversAppApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DriverAppApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DriversController:ControllerBase
{
    private readonly DriverService _driverService;
    public DriversController(DriverService driverService)
    {
        _driverService=driverService;
    }

    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> GetById(string id) 
    {
        var existingDriver=await _driverService.GetAsync(id);
        if (existingDriver == null)
        {
            return NotFound();
        }
        return Ok(existingDriver);
    }

    [HttpGet]
    public async Task<IActionResult> Get() 
    {
        var existingDriver=await _driverService.GetAsync();
        if (existingDriver == null)
        {
            return NotFound();
        }
        return Ok(existingDriver);

    }

    [HttpPost]
    public async Task<IActionResult> Post(Driver driver)
    {
        await _driverService.CreateAsync(driver);
        return CreatedAtAction(nameof(Get), new {id=driver.Id},driver);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Driver driver)
    {
        var existingDriver=await _driverService.GetAsync(driver.Id);
        if (existingDriver == null)
        {
            return NotFound();
        }
        await _driverService.UpdateAsync(driver);
        return Ok("UpdatedSuccessfully");

    }

    [HttpDelete]
    public async Task<IActionResult> Remove(string id)
    {
        var existingDriver = await _driverService.GetAsync(id);
        if(existingDriver == null)
        {
            return NotFound();
        }
        await _driverService.RemoveAsync(id);
        return Ok();
    }
}
