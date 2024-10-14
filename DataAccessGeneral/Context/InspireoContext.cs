using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.ModelsDB;

public partial class InspireoContext : DbContext
{
    public InspireoContext()
    {
    }

    public InspireoContext(DbContextOptions<InspireoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<AlbumContainer> AlbumContainers { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Config> Configs { get; set; }

    public virtual DbSet<EmailConfirmation> EmailConfirmations { get; set; }

    public virtual DbSet<FingerPrinting> FingerPrintings { get; set; }

    public virtual DbSet<FriendRequest> FriendRequests { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Relation> Relations { get; set; }

    public virtual DbSet<Relationship> Relationships { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<SearchHistory> SearchHistories { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-3F0EBO4;Database=Inspireo;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.IdOfAlbum).HasName("PK__Album__A6F0AF26E9B7397E");

            entity.ToTable("Album");

            entity.Property(e => e.IdOfAlbum)
                .HasMaxLength(54)
                .HasColumnName("Id_Of_Album");
            entity.Property(e => e.AuthorId)
                .HasMaxLength(54)
                .HasColumnName("Author_id");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_at");
            entity.Property(e => e.NameOfAlbum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_of_Album");

            entity.HasOne(d => d.Author).WithMany(p => p.Albums)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Album__Author_id__52AE4273");

            entity.HasMany(d => d.IdOfUsers).WithMany(p => p.IdOfAlbums)
                .UsingEntity<Dictionary<string, object>>(
                    "AddedAlbum",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("IdOfUser")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Added_Alb__Id_of__558AAF1E"),
                    l => l.HasOne<Album>().WithMany()
                        .HasForeignKey("IdOfAlbum")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Added_Alb__Id_Of__567ED357"),
                    j =>
                    {
                        j.HasKey("IdOfAlbum", "IdOfUser").HasName("PK__Added_Al__8446838EFB5FF878");
                        j.ToTable("Added_Albums");
                        j.IndexerProperty<string>("IdOfAlbum")
                            .HasMaxLength(54)
                            .HasColumnName("Id_Of_Album");
                        j.IndexerProperty<string>("IdOfUser")
                            .HasMaxLength(54)
                            .HasColumnName("Id_of_User");
                    });
        });

        modelBuilder.Entity<AlbumContainer>(entity =>
        {
            entity.HasKey(e => new { e.IdOfAlbum, e.IdOfImage }).HasName("PK__Album_Co__1FC4DD42735D2EBC");

            entity.ToTable("Album_Container");

            entity.Property(e => e.IdOfAlbum)
                .HasMaxLength(54)
                .HasColumnName("Id_Of_Album");
            entity.Property(e => e.IdOfImage)
                .HasMaxLength(54)
                .HasColumnName("Id_of_image");

            entity.HasOne(d => d.IdOfAlbumNavigation).WithMany(p => p.AlbumContainers)
                .HasForeignKey(d => d.IdOfAlbum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Album_Con__Id_Of__595B4002");

            entity.HasOne(d => d.IdOfAlbum1).WithMany(p => p.AlbumContainers)
                .HasForeignKey(d => d.IdOfAlbum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Album_Con__Id_Of__5A4F643B");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => new { e.IdOfUser, e.IdOfAlbum, e.DateOfComment }).HasName("PK__Comment__8B7144C12F873C35");

            entity.ToTable("Comment");

            entity.Property(e => e.IdOfUser)
                .HasMaxLength(54)
                .HasColumnName("ID_of_user");
            entity.Property(e => e.IdOfAlbum)
                .HasMaxLength(54)
                .HasColumnName("Id_Of_Album");
            entity.Property(e => e.DateOfComment)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdOfAlbumNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdOfAlbum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__Id_Of_A__6C6E1476");

            entity.HasOne(d => d.IdOfUserNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdOfUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__ID_of_u__6B79F03D");
        });

        modelBuilder.Entity<Config>(entity =>
        {
            entity.HasKey(e => e.IdOfUser).HasName("PK__Config__23D22D0A61157907");

            entity.ToTable("Config");

            entity.Property(e => e.IdOfUser)
                .HasMaxLength(54)
                .HasColumnName("ID_of_user");
            entity.Property(e => e.DarkTheme).HasColumnName("Dark_theme");
            entity.Property(e => e.EveryoneSeePosts).HasColumnName("Everyone_see_posts");
            entity.Property(e => e.SaveHistory).HasColumnName("Save_History");

            entity.HasOne(d => d.IdOfUserNavigation).WithOne(p => p.Config)
                .HasForeignKey<Config>(d => d.IdOfUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Config__ID_of_us__45544755");
        });

        modelBuilder.Entity<EmailConfirmation>(entity =>
        {
            entity.HasKey(e => e.IdReq).HasName("PK__EmailCon__182A6452D6AAACC9");

            entity.ToTable("EmailConfirmation");

            entity.Property(e => e.IdReq)
                .HasMaxLength(54)
                .HasColumnName("ID_req");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_at");
            entity.Property(e => e.Expire).HasColumnType("datetime");
            entity.Property(e => e.IdOfUser)
                .HasMaxLength(54)
                .HasColumnName("ID_of_user");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.IdOfUserNavigation).WithMany(p => p.EmailConfirmations)
                .HasForeignKey(d => d.IdOfUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmailConf__ID_of__2C88998B");
        });

        modelBuilder.Entity<FingerPrinting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Finger_p__3214EC277551B974");

            entity.ToTable("Finger_printing");

            entity.Property(e => e.Id)
                .HasMaxLength(54)
                .HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeviceType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Language)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Os)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("OS");
            entity.Property(e => e.Plugins).HasColumnType("text");
            entity.Property(e => e.UserAgent)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FriendRequest>(entity =>
        {
            entity.HasKey(e => e.IdOfFriendRequest).HasName("PK__Friend_R__E6760891002E9BFC");

            entity.ToTable("Friend_Request");

            entity.Property(e => e.IdOfFriendRequest)
                .HasMaxLength(54)
                .HasColumnName("Id_of_Friend_Request");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdOfReceiver)
                .HasMaxLength(54)
                .HasColumnName("Id_of_receiver");
            entity.Property(e => e.IdOfSender)
                .HasMaxLength(54)
                .HasColumnName("Id_of_sender");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.IdOfReceiverNavigation).WithMany(p => p.FriendRequestIdOfReceiverNavigations)
                .HasForeignKey(d => d.IdOfReceiver)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Friend_Re__Id_of__4B0D20AB");

            entity.HasOne(d => d.IdOfSenderNavigation).WithMany(p => p.FriendRequestIdOfSenderNavigations)
                .HasForeignKey(d => d.IdOfSender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Friend_Re__Id_of__4A18FC72");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.IdOfImage).HasName("PK__Images__9347264A00696AF9");

            entity.Property(e => e.IdOfImage)
                .HasMaxLength(54)
                .HasColumnName("Id_of_image");
            entity.Property(e => e.Directory)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.IdOfNotification).HasName("PK__Notifica__36C6F471E566F159");

            entity.Property(e => e.IdOfNotification)
                .HasMaxLength(54)
                .HasColumnName("ID_of_notification");
            entity.Property(e => e.IdOfFriendRequest)
                .HasMaxLength(54)
                .HasColumnName("Id_of_Friend_Request");
            entity.Property(e => e.IdOfSession)
                .HasMaxLength(54)
                .HasColumnName("ID_of_session");
            entity.Property(e => e.IdOfUser)
                .HasMaxLength(54)
                .HasColumnName("ID_of_user");

            entity.HasOne(d => d.IdOfFriendRequestNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.IdOfFriendRequest)
                .HasConstraintName("FK__Notificat__Id_of__7132C993");

            entity.HasOne(d => d.IdOfSessionNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.IdOfSession)
                .HasConstraintName("FK__Notificat__ID_of__703EA55A");

            entity.HasOne(d => d.IdOfUserNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.IdOfUser)
                .HasConstraintName("FK__Notificat__ID_of__6F4A8121");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.IdOfPost).HasName("PK__Posts__D5E419AE908AEE1C");

            entity.Property(e => e.IdOfPost)
                .HasMaxLength(54)
                .HasColumnName("ID_of_post");
            entity.Property(e => e.AuthorId)
                .HasMaxLength(54)
                .HasColumnName("Author_id");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_at");
            entity.Property(e => e.Private).HasDefaultValue(true);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.Author).WithMany(p => p.Posts)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Posts__Author_id__324172E1");
        });

        modelBuilder.Entity<Relation>(entity =>
        {
            entity.HasKey(e => new { e.IdOfPost, e.IdOfUser }).HasName("PK__Relation__67D93B7EEC46E349");

            entity.ToTable("Relation");

            entity.Property(e => e.IdOfPost)
                .HasMaxLength(54)
                .HasColumnName("ID_of_post");
            entity.Property(e => e.IdOfUser)
                .HasMaxLength(54)
                .HasColumnName("ID_of_user");
            entity.Property(e => e.Access).HasDefaultValue(true);
            entity.Property(e => e.UserScore).HasColumnName("User_score");
            entity.Property(e => e.Watched).HasColumnType("datetime");

            entity.HasOne(d => d.IdOfPostNavigation).WithMany(p => p.Relations)
                .HasForeignKey(d => d.IdOfPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Relation__ID_of___361203C5");

            entity.HasOne(d => d.IdOfUserNavigation).WithMany(p => p.Relations)
                .HasForeignKey(d => d.IdOfUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Relation__ID_of___370627FE");
        });

        modelBuilder.Entity<Relationship>(entity =>
        {
            entity.HasKey(e => new { e.IdOfSender, e.IdOfReceiver }).HasName("PK__Relation__609DD34467275F90");

            entity.ToTable("Relationship");

            entity.Property(e => e.IdOfSender)
                .HasMaxLength(54)
                .HasColumnName("Id_of_sender");
            entity.Property(e => e.IdOfReceiver)
                .HasMaxLength(54)
                .HasColumnName("Id_of_receiver");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.IdOfReceiverNavigation).WithMany(p => p.RelationshipIdOfReceiverNavigations)
                .HasForeignKey(d => d.IdOfReceiver)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Relations__Id_of__4FD1D5C8");

            entity.HasOne(d => d.IdOfSenderNavigation).WithMany(p => p.RelationshipIdOfSenderNavigations)
                .HasForeignKey(d => d.IdOfSender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Relations__Id_of__4EDDB18F");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => new { e.IdOfPost, e.IdOfReporter }).HasName("PK__Reports__385CD96F5E965FB6");

            entity.Property(e => e.IdOfPost)
                .HasMaxLength(54)
                .HasColumnName("ID_of_post");
            entity.Property(e => e.IdOfReporter)
                .HasMaxLength(54)
                .HasColumnName("ID_of_reporter");
            entity.Property(e => e.Body).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_AT");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");

            entity.HasOne(d => d.IdOfPostNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.IdOfPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reports__ID_of_p__3AD6B8E2");

            entity.HasOne(d => d.IdOfReporterNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.IdOfReporter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reports__ID_of_r__3BCADD1B");
        });

        modelBuilder.Entity<SearchHistory>(entity =>
        {
            entity.HasKey(e => e.IdOfQuery).HasName("PK__Search_h__5D2590BF29059D03");

            entity.ToTable("Search_history");

            entity.Property(e => e.IdOfQuery)
                .HasMaxLength(54)
                .HasColumnName("Id_of_query");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.IdOfUser)
                .HasMaxLength(54)
                .HasColumnName("ID_of_user");

            entity.HasOne(d => d.IdOfUserNavigation).WithMany(p => p.SearchHistories)
                .HasForeignKey(d => d.IdOfUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Search_hi__ID_of__67A95F59");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.IdOfSession).HasName("PK__Sessions__7599B219AB06F4ED");

            entity.Property(e => e.IdOfSession)
                .HasMaxLength(54)
                .HasColumnName("ID_of_session");
            entity.Property(e => e.IdOfDevice)
                .HasMaxLength(54)
                .HasColumnName("ID_of_device");
            entity.Property(e => e.Token).HasColumnType("text");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.IdOfDeviceNavigation).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.IdOfDevice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sessions__ID_of___4277DAAA");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.IdOfTag).HasName("PK__Tags__E98DE03876F6B3E7");

            entity.Property(e => e.IdOfTag)
                .HasMaxLength(54)
                .HasColumnName("Id_of_tag");
            entity.Property(e => e.Content)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.IdOfAlbums).WithMany(p => p.IdOfTags)
                .UsingEntity<Dictionary<string, object>>(
                    "AlbumsTag",
                    r => r.HasOne<Album>().WithMany()
                        .HasForeignKey("IdOfAlbum")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Albums_ta__Id_Of__60083D91"),
                    l => l.HasOne<Tag>().WithMany()
                        .HasForeignKey("IdOfTag")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Albums_ta__Id_of__5F141958"),
                    j =>
                    {
                        j.HasKey("IdOfTag", "IdOfAlbum").HasName("PK__Albums_t__93E2EACACD4C70A7");
                        j.ToTable("Albums_tags");
                        j.IndexerProperty<string>("IdOfTag")
                            .HasMaxLength(54)
                            .HasColumnName("Id_of_tag");
                        j.IndexerProperty<string>("IdOfAlbum")
                            .HasMaxLength(54)
                            .HasColumnName("Id_Of_Album");
                    });

            entity.HasMany(d => d.IdOfPosts).WithMany(p => p.IdOfTags)
                .UsingEntity<Dictionary<string, object>>(
                    "PostsTag",
                    r => r.HasOne<Post>().WithMany()
                        .HasForeignKey("IdOfPost")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Posts_tag__ID_of__63D8CE75"),
                    l => l.HasOne<Tag>().WithMany()
                        .HasForeignKey("IdOfTag")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Posts_tag__Id_of__62E4AA3C"),
                    j =>
                    {
                        j.HasKey("IdOfTag", "IdOfPost").HasName("PK__Posts_ta__14D3A1A2578AAB25");
                        j.ToTable("Posts_tags");
                        j.IndexerProperty<string>("IdOfTag")
                            .HasMaxLength(54)
                            .HasColumnName("Id_of_tag");
                        j.IndexerProperty<string>("IdOfPost")
                            .HasMaxLength(54)
                            .HasColumnName("ID_of_post");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdOfUser).HasName("PK__Users__23D22D0A34972BF8");

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F28456C0BC7EEB").IsUnique();

            entity.Property(e => e.IdOfUser)
                .HasMaxLength(54)
                .HasColumnName("ID_of_user");
            entity.Property(e => e.Avatar).HasMaxLength(54);
            entity.Property(e => e.Bio)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_at");
            entity.Property(e => e.Email).HasMaxLength(320);
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Patronymic)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.AvatarNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Avatar)
                .HasConstraintName("FK__Users__Avatar__27C3E46E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
