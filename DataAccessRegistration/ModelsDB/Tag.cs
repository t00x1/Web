using System;
using System.Collections.Generic;

namespace DataAccessRegistration.ModelsDB;

public partial class Tag
{
    public string IdOfTag { get; set; } = null!;

    public string Content { get; set; } = null!;

    public virtual ICollection<Album> IdOfAlbums { get; set; } = new List<Album>();

    public virtual ICollection<Post> IdOfPosts { get; set; } = new List<Post>();
}
