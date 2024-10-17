using System;
using System.Collections.Generic;

namespace DataAccess.ModelsDB;

public partial class Comment
{
    public DateTime DateOfComment { get; set; }

    public string IdOfUser { get; set; } = null!;

    public string IdOfAlbum { get; set; } = null!;

    public virtual Album IdOfAlbumNavigation { get; set; } = null!;

    public virtual User IdOfUserNavigation { get; set; } = null!;
}
