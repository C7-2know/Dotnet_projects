using Microsoft.AspNetCore.Mvc;
using BloodDonateApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonateApi.Conrollers;

[ApiController]
[Route("api/[Controller]")]
public class BDcandidateController:ControllerBase
{
    private readonly DonationDbContext _context;
    public BDcandidateController(DonationDbContext context){
        _context=context;
    }

    [HttpGet]
    public async Task<List<BDcandidate>> Get(){
        var result=await _context.BDCandidates.ToListAsync();
        return result;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id){
        var res=await _context.BDCandidates.FindAsync(id);
        if(res==null){
            return NotFound();
        }
        return Ok(res);
    }

    [HttpPost]
    public async Task<ActionResult<BDcandidate>> Add(BDcandidate candidate){
        var exist=await _context.BDCandidates.FindAsync(candidate.id);
        if (exist!=null){
            return BadRequest();
        }
        _context.BDCandidates.Add(candidate);
        await _context.SaveChangesAsync();
        return Ok(candidate);
    }

    [HttpPut]
    public async Task<ActionResult> Update(BDcandidate input){
        var candidate=await _context.BDCandidates.FindAsync(input.id);
        if (candidate==null){
            return NotFound();
        }

        candidate.Address=input.Address;
        candidate.Age=input.Age;
        candidate.BloodGroup=input.BloodGroup;
        candidate.Email=input.Email;
        candidate.Mobile=input.Mobile;
        candidate.FullName=input.FullName;
        await _context.SaveChangesAsync();
        return Ok(candidate);
        
    }
    

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id){
        var candi=await _context.BDCandidates.FindAsync(id);
        if (candi==null){
            return BadRequest();
        }
        _context.BDCandidates.Remove(candi);
        await _context.SaveChangesAsync();
        return Ok();
    }
}