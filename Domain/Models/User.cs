﻿using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class User
{
    public long IdOfUser { get; set; }

    public string UserName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Password { get; set; } = null!;

    public string? Bio { get; set; }

    public bool Admin { get; set; }

    public long? Avatar { get; set; }

    public DateTime BirthDate { get; set; }

    public string? Phone { get; set; }

    public string? Location { get; set; }

    public bool Male { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

    public virtual Image? AvatarNavigation { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Config? Config { get; set; }

    public virtual ICollection<FriendRequest> FriendRequestIdOfReceiverNavigations { get; set; } = new List<FriendRequest>();

    public virtual ICollection<FriendRequest> FriendRequestIdOfSenderNavigations { get; set; } = new List<FriendRequest>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<RecomendationsAlsRating> RecomendationsAlsRatings { get; set; } = new List<RecomendationsAlsRating>();

    public virtual ICollection<Relation> Relations { get; set; } = new List<Relation>();

    public virtual ICollection<Relationship> RelationshipIdOfReceiverNavigations { get; set; } = new List<Relationship>();

    public virtual ICollection<Relationship> RelationshipIdOfSenderNavigations { get; set; } = new List<Relationship>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<SearchHistory> SearchHistories { get; set; } = new List<SearchHistory>();
}