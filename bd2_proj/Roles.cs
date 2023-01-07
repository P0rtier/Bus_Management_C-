using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bd2_proj
{
    public class Roles
    {
        public static DataTable getQueryResult(MySqlConnection conn, string query)
        {
            DataTable dTable = new DataTable();
            try
            {
                conn.Open();
                MySqlCommand MyCommand = new MySqlCommand(query, conn);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand;
                dTable = new DataTable();
                MyAdapter.Fill(dTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            return dTable;
        }

        static public void addRole(MySqlConnection conn, string table, int id)
        {
            if (roleID(conn, table, id) != -1) return;
            try
            {
                conn.Open();
                string query = $"insert into `mpk_bd2`.`{table}` (id_pracownik) values({id});";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                mySqlCommand.ExecuteReader();
                MessageBox.Show("Inserted Row!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
        static public void removeRole(MySqlConnection conn, string table, int id)
        {
            if (roleID(conn, table, id) == -1) return;
            try
            {
                conn.Open();
                string query = $"delete from `mpk_bd2`.`{table}` where id_pracownik={id};";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                mySqlCommand.ExecuteReader();
                MessageBox.Show("Deleted Row!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        static public int roleID(MySqlConnection conn, string role, int user_id)
        {
            int id = -1;

            var id_query = $"select * from `mpk_bd2`.`{role}` where id_pracownik = {user_id};";
            var res = getQueryResult(conn, id_query);

            if (res.Rows.Count > 0)
            {
                id = Int32.Parse(res.Rows[0][0].ToString());
            }

            return id;
        }

        static public int kierowcaID(MySqlConnection conn, int id)
        {
            return roleID(conn, "kierowca", id);
        }
        static public int brygadzistaID(MySqlConnection conn, int id)
        {
            return roleID(conn,"brygadzista", id);
        }
        static public int administratorID(MySqlConnection conn, int id)
        {
            return roleID(conn, "administrator", id);
        }
    }
}
