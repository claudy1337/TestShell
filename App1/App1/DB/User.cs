using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.DB
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
