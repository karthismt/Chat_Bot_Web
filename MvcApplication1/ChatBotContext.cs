using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MvcApplication1
{
    public class ChatBotContext : DbContext
    {
        public ChatBotContext()
            : base("DB_Context")
        {
            Database.SetInitializer<ChatBotContext>(null);//Disable initializer
        }

        public DbSet<chatbot> ChatBot { get; set; }
        public DbSet<ContactInfromation> ContactInfromation { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}



