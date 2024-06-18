using System;

namespace StudentRegistration.Models
{
    public class FamilyMember
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int RelationshipId { get; set; }
        public Relationship Relationship { get; set; }
        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }
    }
}
