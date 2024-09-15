using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Comment
{
    public DateTime DateOfComment { get; set; }

    public long IdOfUser { get; set; }

    public long IdOfAlbum { get; set; }

    public virtual Album IdOfAlbumNavigation { get; set; } = null!;

    public virtual User IdOfUserNavigation { get; set; } = null!;
}
