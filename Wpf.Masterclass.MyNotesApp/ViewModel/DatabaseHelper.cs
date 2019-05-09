using System;
using System.IO;
using SQLite;

namespace Wpf.Masterclass.MyNotesApp.ViewModel
{
    public static class DatabaseHelper
    {
        //location of SQLite database file
        public static string DbFile = Path.Combine(Environment.CurrentDirectory, "MyNotesAppDb.db3");

        /// <summary>
        /// Insert object to database
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="item">object item</param>
        /// <returns>true if insert was successful</returns>
        public static bool Insert<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection conn = new SQLiteConnection(DbFile))
            {
                conn.CreateTable<T>();
                int rows = conn.Insert(item);
                if (rows > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Update object in database
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="item">object item</param>
        /// <returns>true if update was successful</returns>
        public static bool Update<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection conn = new SQLiteConnection(DbFile))
            {
                conn.CreateTable<T>();
                int rows = conn.Update(item);
                if (rows > 0)
                {
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Delete object from database
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="item">object item</param>
        /// <returns>true if Delete was successful</returns>
        public static bool Delete<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection conn = new SQLiteConnection(DbFile))
            {
                conn.CreateTable<T>();
                int rows = conn.Delete(item);
                if (rows > 0)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
