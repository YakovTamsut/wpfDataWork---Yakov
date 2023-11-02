using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class Snack : BaseEntity
    {
        private string snackName;
        private bool isSweet;
        private int calories;
        private UserList users;

        public string SnackName
        {
            get { return snackName; }
            set { snackName = value; }
        }

        public bool IsSweet
        {
            get { return isSweet; }
            set { isSweet = value; }
        }

        public int Calories
        {
            get { return calories; }
            set { calories = value; }
        }

        public UserList Users
        {
            get { return users; }
            set { users = value; }
        }
    }
    public class SnackList : List<Snack>
    {
        public SnackList() { } //בנאי ברירת מחדל
        public SnackList(IEnumerable<Snack> list) :
            base(list)
        { } //המרה של רשימת קורסים לאוסף של קורסים
        public SnackList(IEnumerable<BaseEntity> list) :
            base(list.Cast<Snack>().ToList())
        { } //המרה כלפי מטה מישות בסיס לרשימת קורסים

    }
}
