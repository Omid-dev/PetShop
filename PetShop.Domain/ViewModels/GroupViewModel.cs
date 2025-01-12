namespace PetShop.Domain.ViewModels
{
    public class GroupViewModel
    {
        public bool ShowHomeSite { get; set; } = false;
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsDeleted { get; set; }

        public int? UserIdOwner { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string NameOwner { get; set; }
    }
}