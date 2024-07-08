using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonateApi.Models;
public class BDcandidate{
    [Key]
    public int id {get;set;}
    
    public string FullName{get;set;}
    public int Mobile {get;set;}

    public string Email {get;set;}
    public int Age {get;set;}

    public string BloodGroup {get;set;}

    public string Address {get;set;}

}