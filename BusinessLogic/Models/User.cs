
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace BusinessLogic.Models
{

using System;
    using System.Collections.Generic;
    
public partial class User
{

    public User()
    {

        this.UserImages = new HashSet<UserImage>();

        this.UserImageComments = new HashSet<UserImageComment>();

    }


    public int UserID { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public byte Gender { get; set; }

    public Nullable<System.DateTime> DateOfBirth { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Interests { get; set; }

    public string About { get; set; }

    public string Avatar { get; set; }

    public string Password { get; set; }



    public virtual ICollection<UserImage> UserImages { get; set; }

    public virtual ICollection<UserImageComment> UserImageComments { get; set; }

}

}
