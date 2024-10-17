using System;
using System.Collections.Generic;

namespace DataAccess.ModelsDB;

public partial class Album
{
    public string IdOfAlbum { get; set; } = null!;

    public string AuthorId { get; set; } = null!;

    public string NameOfAlbum { get; set; } = null!;

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<AlbumContainer> AlbumContainers { get; set; } = new List<AlbumContainer>();

    public virtual User Author { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Tag> IdOfTags { get; set; } = new List<Tag>();

    public virtual ICollection<User> IdOfUsers { get; set; } = new List<User>();
}
