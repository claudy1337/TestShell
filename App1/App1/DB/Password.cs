using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.DB
{
    [Table("Passwords")]
    public class Password
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Pswd { get; set; }
        public string URL { get; set; }
        public string Kind { get; set; }
        public int UserId { get; set; }
    }
}
