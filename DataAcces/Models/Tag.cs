using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Tag
{
    public long IdOfTag { get; set; }

    public string Content { get; set; } = null!;

    public virtual ICollection<Album> IdOfAlbums { get; set; } = new List<Album>();

    public virtual ICollection<Post> IdOfPosts { get; set; } = new List<Post>();
}
