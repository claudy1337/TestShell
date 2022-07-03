using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;

namespace App1.DB
{
    internal class Storage
    {
        SQLiteConnection database;

        public Storage(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Password>();
            database.CreateTable<User>();
        }

        //User---------------------------

        public int SaveUser(User user)
        {
            if (user.Id != 0)
            {
                database.Update(user);
                return user.Id;
            }
            else
            {
                return database.Insert(user);
            }
        }

        public IEnumerable<User> GetUsers()
        {
            return database.Table<User>().ToList();
        }

        public User GetUser(string login, string password)
        {
            return GetUsers().Where(user => user.Login == login && user.Password == password).FirstOrDefault();
        }

        //Password---------------------------

        public int SavePassword(Password password)
        {
            if (password.Id != 0)
            {
                database.Update(password);
                return password.Id;
            }
            else
            {
                return database.Insert(password);
            }
        }

        public void EditPassword(Password oldPassword, string kind, string login, string pswd, string url)
        {
            Password pass = oldPassword;
            pass.Kind = kind;
            pass.Login = login;
            pass.Pswd = pswd;
            pass.URL = url;
            database.Update(pass);
        }

        public IEnumerable<Password> GetPasswords()
        {
            return database.Table<Password>().ToList();
        }

        public Password GetPassword(string login)
        {
            return GetPasswords().Where(password => password.Login == login).FirstOrDefault();
        }



        public int DeletePassword(int idPassword)
        {
            return database.Delete<Password>(idPassword);
        }
    }
}
