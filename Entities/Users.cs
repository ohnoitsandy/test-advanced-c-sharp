using System;


namespace CoreTest.Entities
{
  public class User
  {
    public string Id {get; private set;}
    
    public string FirstName {get; set;}
    
    public string LastName {get; set;}
    
    public string MothersLastName {get; set;}
    
    public DateTime Birthdate {get; set;}
    
    public MaritalStatus MaritalStatus {get; set;}
    
    public BloodType BloodType {get; set;}
    
    public Gender Gender {get; set;}

    public User() => Id = Guid.NewGuid().ToString();
  }


}
