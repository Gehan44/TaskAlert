using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAlert.Models
{
    public class Activity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public TimeSpan Time { get; set; }
        public bool NotiActivity { get; set; }
        public bool ModeActivity { get; set; }
    }
}