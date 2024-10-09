using System;
using System.Collections.Generic;

namespace DataAccess.ModelsDB;

public partial class Image
{
    public string IdOfImage { get; set; } = null!;

    public string Directory { get; set; } = null!;

    public virtual ICollection<AlbumContainer> AlbumContainers { get; set; } = new List<AlbumContainer>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
