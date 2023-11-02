using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    internal class snackDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Snack() as BaseEntity;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Snack snack = (Snack)entity;
            snack.Id = int.Parse(reader["id"].ToString());
            snack.SnackName = reader["snackName"].ToString();
            snack.IsSweet = bool.Parse(reader["isSweet"].ToString());
            snack.Calories = int.Parse(reader["calories"].ToString());

            return snack;
        }

        public SnackList SelectAll()
        {
            this.command.CommandText = "SELECT * FROM Tblsnacks";
            SnackList list = new SnackList(base.ExecuteCommand());
            return list;
        }

        public Snack SelectById(int id)
        {
            command.CommandText = string.Format("SELECT * FROM Tblsnacks WHERE (ID = {0})", id);
            SnackList list = new SnackList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }

        public SnackList SelectByUser(User user)
        {
            this.command.CommandText = "SELECT * FROM (TblUserSnacks INNER JOIN TblSnacks ON TblUserSnacks.SnackID = TblSnacks.id)" +
                $" WHERE UserID={user.Id}";
            SnackList list = new SnackList(base.ExecuteCommand());
            return list;
        }
    }
}
