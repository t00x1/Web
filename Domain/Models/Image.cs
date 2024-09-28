using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Image
{
    public long IdOfImage { get; set; }

    public string Directory { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Album> IdOfAlbums { get; set; } = new List<Album>();
}
