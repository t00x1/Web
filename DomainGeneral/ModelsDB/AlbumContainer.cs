using System;
using System.Collections.Generic;

namespace DataAccess.ModelsDB;

public partial class AlbumContainer
{
    public string IdOfAlbum { get; set; } = null!;

    public string IdOfImage { get; set; } = null!;

    public virtual Image IdOfAlbum1 { get; set; } = null!;

    public virtual Album IdOfAlbumNavigation { get; set; } = null!;
}
