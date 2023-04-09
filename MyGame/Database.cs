using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class Database : DbContext
    {
        private MainWindow mainWindow;
        public List<RowDb> Rows { get; set; } = new List<RowDb>();

        public string DbPath { get; }

        public Database()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            //DbPath = System.IO.Path.Join(path, "mygame.db");
        }

        public Database(MainWindow mainWindow) : this()
        { 
            this.mainWindow = mainWindow;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //=> options.UseSqlite($"Data Source={DbPath}");

        public void Save()
        {

        }
    }

    public class RowDb
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public List<QuestionDb> Questions { get; set; } = new List<QuestionDb>();
    }

    public class QuestionDb
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Score { get; set; }
    }
}
