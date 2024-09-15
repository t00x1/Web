using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Album
{
    public long IdOfAlbum { get; set; }

    public long AuthorId { get; set; }

    public string NameOfAlbum { get; set; } = null!;

    public DateTime? DeletedAt { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Image> IdOfImages { get; set; } = new List<Image>();

    public virtual ICollection<Tag> IdOfTags { get; set; } = new List<Tag>();

    public virtual ICollection<User> IdOfUsers { get; set; } = new List<User>();
}
