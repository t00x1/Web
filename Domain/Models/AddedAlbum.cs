using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class AddedAlbum
{
    public long IdOfAlbum { get; set; }

    public long IdOfUser { get; set; }

    public virtual Album IdOfAlbumNavigation { get; set; } = null!;

    public virtual User IdOfUserNavigation { get; set; } = null!;
}
