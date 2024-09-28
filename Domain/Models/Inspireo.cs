using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class Inspireo : DbContext
{
    public Inspireo()
    {
    }

    public Inspireo(DbContextOptions<Inspireo> options)
        : base(options)
    {
    }

    public virtual DbSet<AddedAlbum> AddedAlbums { get; set; }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Config> Configs { get; set; }

    public virtual DbSet<FingerPrinting> FingerPrintings { get; set; }

    public virtual DbSet<FriendRequest> FriendRequests { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<RecomendationsAlsRating> RecomendationsAlsRatings { get; set; }

    public virtual DbSet<Relation> Relations { get; set; }

    public virtual DbSet<Relationship> Relationships { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<SearchHistory> SearchHistories { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

   /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-3F0EBO4;Database=model;Trusted_Connection=True;TrustServerCertificate=True;");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddedAlbum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Added_Albums");

            entity.Property(e => e.IdOfAlbum).HasColumnName("Id_Of_Album");
            entity.Property(e => e.IdOfUser).HasColumnName("Id_of_User");

            entity.HasOne(d => d.IdOfAlbumNavigation).WithMany()
                .HasForeignKey(d => d.IdOfAlbum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Added_Alb__Id_Of__68487DD7");

            entity.HasOne(d => d.IdOfUserNavigation).WithMany()
                .HasForeignKey(d => d.IdOfUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Added_Alb__Id_of__6754599E");
        });

        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.IdOfAlbum).HasName("PK__Album__A6F0AF269CD08F9D");

            entity.ToTable("Album");

            entity.Property(e => e.IdOfAlbum)
                .ValueGeneratedNever()
                .HasColumnName("Id_Of_Album");
            entity.Property(e => e.AuthorId).HasColumnName("Author_id");
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
                .HasConstraintName("FK__Album__Author_id__656C112C");

            entity.HasMany(d => d.IdOfImages).WithMany(p => p.IdOfAlbums)
                .UsingEntity<Dictionary<string, object>>(
                    "AlbumContainer",
                    r => r.HasOne<Image>().WithMany()
                        .HasForeignKey("IdOfImage")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Album_Con__Id_of__6C190EBB"),
                    l => l.HasOne<Album>().WithMany()
                        .HasForeignKey("IdOfAlbum")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Album_Con__Id_Of__6B24EA82"),
                    j =>
                    {
                        j.HasKey("IdOfAlbum", "IdOfImage").HasName("PK__Album_Co__1FC4DD423516AD9B");
                        j.ToTable("Album_Container");
                        j.IndexerProperty<long>("IdOfAlbum").HasColumnName("Id_Of_Album");
                        j.IndexerProperty<long>("IdOfImage").HasColumnName("Id_of_image");
                    });
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => new { e.IdOfUser, e.IdOfAlbum, e.DateOfComment }).HasName("PK__Comment__8B7144C16231156E");

            entity.ToTable("Comment");

            entity.Property(e => e.IdOfUser).HasColumnName("ID_of_user");
            entity.Property(e => e.IdOfAlbum).HasColumnName("Id_Of_Album");
            entity.Property(e => e.DateOfComment)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdOfAlbumNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdOfAlbum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__Id_Of_A__7E37BEF6");

            entity.HasOne(d => d.IdOfUserNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdOfUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__ID_of_u__7D439ABD");
        });

        modelBuilder.Entity<Config>(entity =>
        {
            entity.HasKey(e => e.IdOfUser).HasName("PK__Config__23D22D0A9535D7FB");

            entity.ToTable("Config");

            entity.Property(e => e.IdOfUser)
                .ValueGeneratedNever()
                .HasColumnName("ID_of_user");
            entity.Property(e => e.DarkTheme).HasColumnName("Dark_theme");
            entity.Property(e => e.EveryoneSeePosts).HasColumnName("Everyone_see_posts");
            entity.Property(e => e.SaveHistory).HasColumnName("Save_History");

            entity.HasOne(d => d.IdOfUserNavigation).WithOne(p => p.Config)
                .HasForeignKey<Config>(d => d.IdOfUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Config__ID_of_us__5812160E");
        });

        modelBuilder.Entity<FingerPrinting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Finger_p__3214EC27C7794ECD");

            entity.ToTable("Finger_printing");

            entity.Property(e => e.Id).HasColumnName("ID");
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
            entity.HasKey(e => e.IdOfFriendRequest).HasName("PK__Friend_R__E676089128624697");

            entity.ToTable("Friend_Request");

            entity.Property(e => e.IdOfFriendRequest).HasColumnName("Id_of_Friend_Request");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdOfReceiver).HasColumnName("Id_of_receiver");
            entity.Property(e => e.IdOfSender).HasColumnName("Id_of_sender");
            entity.Property(e => e.Updated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdOfReceiverNavigation).WithMany(p => p.FriendRequestIdOfReceiverNavigations)
                .HasForeignKey(d => d.IdOfReceiver)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Friend_Re__Id_of__5DCAEF64");

            entity.HasOne(d => d.IdOfSenderNavigation).WithMany(p => p.FriendRequestIdOfSenderNavigations)
                .HasForeignKey(d => d.IdOfSender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Friend_Re__Id_of__5CD6CB2B");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.IdOfImage).HasName("PK__Images__9347264AEF71F245");

            entity.Property(e => e.IdOfImage).HasColumnName("Id_of_image");
            entity.Property(e => e.Directory)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.IdOfNotification).HasName("PK__Notifica__8B33F693A26B66D9");

            entity.Property(e => e.IdOfNotification).HasColumnName("idOfNotification");
            entity.Property(e => e.IdOfFriendRequest).HasColumnName("Id_of_Friend_Request");
            entity.Property(e => e.IdOfSession).HasColumnName("ID_of_session");
            entity.Property(e => e.IdOfUser).HasColumnName("ID_of_user");

            entity.HasOne(d => d.IdOfFriendRequestNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.IdOfFriendRequest)
                .HasConstraintName("FK__Notificat__Id_of__02FC7413");

            entity.HasOne(d => d.IdOfSessionNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.IdOfSession)
                .HasConstraintName("FK__Notificat__ID_of__02084FDA");

            entity.HasOne(d => d.IdOfUserNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.IdOfUser)
                .HasConstraintName("FK__Notificat__ID_of__01142BA1");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.IdOfPost).HasName("PK__Posts__D5E419AEFC2C3E20");

            entity.Property(e => e.IdOfPost).HasColumnName("ID_of_post");
            entity.Property(e => e.AuthorId).HasColumnName("Author_id");
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
                .HasConstraintName("FK__Posts__Author_id__412EB0B6");
        });

        modelBuilder.Entity<RecomendationsAlsRating>(entity =>
        {
            entity.HasKey(e => new { e.IdOfPost, e.IdOfUser }).HasName("PK__Recomend__67D93B7EB082BBDC");

            entity.ToTable("Recomendations_ALS_RATING");

            entity.Property(e => e.IdOfPost).HasColumnName("ID_of_post");
            entity.Property(e => e.IdOfUser).HasColumnName("ID_of_user");

            entity.HasOne(d => d.IdOfPostNavigation).WithMany(p => p.RecomendationsAlsRatings)
                .HasForeignKey(d => d.IdOfPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Recomenda__ID_of__4D94879B");

            entity.HasOne(d => d.IdOfUserNavigation).WithMany(p => p.RecomendationsAlsRatings)
                .HasForeignKey(d => d.IdOfUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Recomenda__ID_of__4E88ABD4");
        });

        modelBuilder.Entity<Relation>(entity =>
        {
            entity.HasKey(e => new { e.IdOfPost, e.IdOfUser }).HasName("PK__Relation__67D93B7E0E5F017E");

            entity.ToTable("Relation");

            entity.Property(e => e.IdOfPost).HasColumnName("ID_of_post");
            entity.Property(e => e.IdOfUser).HasColumnName("ID_of_user");
            entity.Property(e => e.Access).HasDefaultValue(true);
            entity.Property(e => e.UserScore).HasColumnName("User_score");
            entity.Property(e => e.Watched).HasColumnType("datetime");

            entity.HasOne(d => d.IdOfPostNavigation).WithMany(p => p.Relations)
                .HasForeignKey(d => d.IdOfPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Relation__ID_of___44FF419A");

            entity.HasOne(d => d.IdOfUserNavigation).WithMany(p => p.Relations)
                .HasForeignKey(d => d.IdOfUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Relation__ID_of___45F365D3");
        });

        modelBuilder.Entity<Relationship>(entity =>
        {
            entity.HasKey(e => new { e.IdOfSender, e.IdOfReceiver }).HasName("PK__Relation__609DD344E3D6DAEF");

            entity.ToTable("Relationship");

            entity.Property(e => e.IdOfSender).HasColumnName("Id_of_sender");
            entity.Property(e => e.IdOfReceiver).HasColumnName("Id_of_receiver");
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
                .HasConstraintName("FK__Relations__Id_of__628FA481");

            entity.HasOne(d => d.IdOfSenderNavigation).WithMany(p => p.RelationshipIdOfSenderNavigations)
                .HasForeignKey(d => d.IdOfSender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Relations__Id_of__619B8048");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => new { e.IdOfPost, e.IdOfReporter }).HasName("PK__Reports__385CD96F6C7E4941");

            entity.Property(e => e.IdOfPost).HasColumnName("ID_of_post");
            entity.Property(e => e.IdOfReporter).HasColumnName("ID_of_reporter");
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
                .HasConstraintName("FK__Reports__ID_of_p__49C3F6B7");

            entity.HasOne(d => d.IdOfReporterNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.IdOfReporter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reports__ID_of_r__4AB81AF0");
        });

        modelBuilder.Entity<SearchHistory>(entity =>
        {
            entity.HasKey(e => e.IdOfQuery).HasName("PK__Search_h__5D2590BF80C3B647");

            entity.ToTable("Search_history");

            entity.Property(e => e.IdOfQuery).HasColumnName("Id_of_query");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.IdOfUser).HasColumnName("ID_of_user");

            entity.HasOne(d => d.IdOfUserNavigation).WithMany(p => p.SearchHistories)
                .HasForeignKey(d => d.IdOfUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Search_hi__ID_of__797309D9");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.IdOfSession).HasName("PK__Sessions__7599B219C769F252");

            entity.Property(e => e.IdOfSession).HasColumnName("ID_of_session");
            entity.Property(e => e.IdOfDevice).HasColumnName("ID_of_device");
            entity.Property(e => e.Token).HasColumnType("text");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.IdOfDeviceNavigation).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.IdOfDevice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sessions__ID_of___5535A963");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.IdOfTag).HasName("PK__Tags__E98DE03858BFF4B6");

            entity.Property(e => e.IdOfTag).HasColumnName("Id_of_tag");
            entity.Property(e => e.Contatin)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.IdOfAlbums).WithMany(p => p.IdOfTags)
                .UsingEntity<Dictionary<string, object>>(
                    "AlbumsTag",
                    r => r.HasOne<Album>().WithMany()
                        .HasForeignKey("IdOfAlbum")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Albums_ta__Id_Of__71D1E811"),
                    l => l.HasOne<Tag>().WithMany()
                        .HasForeignKey("IdOfTag")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Albums_ta__Id_of__70DDC3D8"),
                    j =>
                    {
                        j.HasKey("IdOfTag", "IdOfAlbum").HasName("PK__Albums_t__93E2EACA2324156B");
                        j.ToTable("Albums_tags");
                        j.IndexerProperty<long>("IdOfTag").HasColumnName("Id_of_tag");
                        j.IndexerProperty<long>("IdOfAlbum").HasColumnName("Id_Of_Album");
                    });

            entity.HasMany(d => d.IdOfPosts).WithMany(p => p.IdOfTags)
                .UsingEntity<Dictionary<string, object>>(
                    "PostsTag",
                    r => r.HasOne<Post>().WithMany()
                        .HasForeignKey("IdOfPost")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Posts_tag__ID_of__75A278F5"),
                    l => l.HasOne<Tag>().WithMany()
                        .HasForeignKey("IdOfTag")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Posts_tag__Id_of__74AE54BC"),
                    j =>
                    {
                        j.HasKey("IdOfTag", "IdOfPost").HasName("PK__Posts_ta__14D3A1A298688623");
                        j.ToTable("Posts_tags");
                        j.IndexerProperty<long>("IdOfTag").HasColumnName("Id_of_tag");
                        j.IndexerProperty<long>("IdOfPost").HasColumnName("ID_of_post");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdOfUser).HasName("PK__Users__23D22D0AD1AD8F9B");

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F28456D0DA8930").IsUnique();

            entity.Property(e => e.IdOfUser).HasColumnName("ID_of_user");
            entity.Property(e => e.Bio)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_at");
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
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
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
                .HasConstraintName("FK__Users__Avatar__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
