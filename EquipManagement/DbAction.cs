using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

namespace EquipManagement
{
    public static class DbAction
    {
        static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Data.db");


        public static void CreateDatabase()
        {
            var db = new SQLiteConnection(path);

            db.CreateTable<Equipment>();
            db.CreateTable<Classes>();

            Classes c = new Classes();
            c.ClassName = 10;

        }

        public static void InsertToDB(Classes addClass)
        {
            var db = new SQLite.SQLiteConnection(path);
            db.Insert(addClass);
        }

        public static void InsertToDB(Equipment equip)
        {
            var db = new SQLite.SQLiteConnection(path);
            db.Insert(equip);
        }

        public static bool DeleteClass(int classname)
        {
            try
            {
                var db = new SQLiteConnection(path);
                db.Delete<Classes>(classname);
                return true;
            }
            catch (Exception)
            {
                return false; // classname doesnt exist in table
                
            }
        }
        public static bool DeleteItem(int itemname)
        {
            try
            {
                var db = new SQLiteConnection(path);
                db.Delete<Equipment>(itemname);
                return true;
            }
            catch (Exception)
            {
                return false; // itemname doesnt exist in table

            }
        }

        public static bool UpdateClass(Classes classObj)
        {
            try
            {
                var db = new SQLiteConnection(path);
                db.Update(classObj);
                return true;
            }
            catch (Exception)
            {
                return false; // classObj doesnt exist in table

            }
        }

        public static bool UpdateItem(Equipment equip)
        {
            try
            {
                var db = new SQLiteConnection(path);
                db.Update(equip);
                return true;
            }
            catch (Exception)
            {
                return false; // equip doesnt exist in table ?

            }
        }
        public static IEnumerable<Classes> QueryClasses()
        {
            var db = new SQLiteConnection(path);

            return db.Query<Classes>("select * from Classes");//where Subject = ?", subj.SubjectID);
        }

        public static IEnumerable<Equipment> QueryItems()
        {
            var db = new SQLiteConnection(path);

            return db.Query<Equipment>("select * from Equipment");
        }
        public static List<Classes> SelectOneClass(int classname)
        {
            var db = new SQLiteConnection(path);

            return db.Query<Classes>("select * from Classes where ClassName = ?", classname);
        }

        public static List<Equipment> SelectOneItem(string name) // wouldnt work if there were more same named
        {
            var db = new SQLiteConnection(path);

            return db.Query<Equipment>("select * from Equipment where Name = ?", name);
        }
    }
    
}
