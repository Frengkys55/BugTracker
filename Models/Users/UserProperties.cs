using System;
using System.IO;

namespace Models.Users;

public partial class User{
    public int id {set; get;}
    public Guid guid {set; get;}
    public string? Username {set; get;}
    public string? FirstName {set; get;}
    public string? LastName {set; get;}
    public string? Email {set; get;}
}
