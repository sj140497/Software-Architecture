using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Messaging.Model
{
    class MessagesEntityTypeConfiguration : EntityTypeConfiguration<Messages>
    {
        public MessagesEntityTypeConfiguration()
        {
            Property(c => c.Id).IsRequired();
            Property(c => c.SenderNo).IsRequired();
        }
    }

    class RecipientsEntityTypeConfiguration : EntityTypeConfiguration<Recipients>
    {
        public RecipientsEntityTypeConfiguration()
        {
            Property(p => p.Id).IsRequired();
            Property(p => p.MessageId).IsRequired();
            Property(p => p.RecipientNo).IsRequired();

            HasRequired(p => p.Message)
                .WithMany()
                .HasForeignKey(p => p.MessageId);
        }
    }

    public class Messagedb : DbContext, IDisposable
    {
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Recipients> Recipients { get; set; }

        public Messagedb()
            : base("name=ICA.Messagedb")
        {
        }

        static Messagedb()
        {
            System.Data.Entity.Database.SetInitializer(new DbInitializer());
        }

        class DbInitializer : CreateDatabaseIfNotExists<Messagedb>
        {
            protected override void Seed(Messagedb context)
            {
                var Messages = new List<Messages>()
                {
                    new Messages { Id = 0, SenderNo = "P44_54", Contents = "Message 1" },
                    new Messages { Id = 1, SenderNo = "P44_54", Contents = "Message 2" },
                    new Messages { Id = 2, SenderNo = "P86_44", Contents = "Message 3" }
                };
                Messages.ForEach(c => context.Messages.Add(c));
                context.SaveChanges();

                var Recipients = new List<Recipients>()
                {
                    new Recipients {Id = 0, Message = Messages[0], MessageId = Messages[0].Id, RecipientNo = "P44_54" },
                    new Recipients {Id = 1, Message = Messages[1], MessageId = Messages[1].Id, RecipientNo = "P44_54" },
                    new Recipients {Id = 2, Message = Messages[2], MessageId = Messages[2].Id, RecipientNo = "P86_44" }

                };
                Recipients.ForEach(b => context.Recipients.Add(b));

                context.SaveChanges();

                base.Seed(context);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new MessagesEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new RecipientsEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
