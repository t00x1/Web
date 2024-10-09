using System;
using System.Collections.Generic;

namespace DataAccess.ModelsDB;

public partial class Post
{
    public string IdOfPost { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string AuthorId { get; set; } = null!;

    public bool Private { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual ICollection<Relation> Relations { get; set; } = new List<Relation>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<Tag> IdOfTags { get; set; } = new List<Tag>();
}
