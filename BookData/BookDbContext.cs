namespace BookData
{
    using System;
    using System.Data.Entity;
    using System.Linq;
  

    public class BookDbContext : DbContext
    {
        // Your context has been configured to use a 'BookDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BookData.BookDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BookDbContext' 
        // connection string in the application configuration file.
        public BookDbContext()
            : base("name=BookDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}