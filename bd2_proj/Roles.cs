using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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

        private static void grantAdministratorPrivileges(MySqlConnection conn, int id)
        {
            try
            {
                conn.Open();
                string query = $"GRANT administrator_role TO `{id}` with admin option; SET DEFAULT ROLE ALL TO `{id}`;";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                mySqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
        private static void revokeAdministratorPrivileges(MySqlConnection conn, int id)
        {
            try
            {
                conn.Open();
                string query = $"REVOKE administrator_role FROM `{id}`; SET DEFAULT ROLE ALL TO `{id}`;";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                mySqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
        private static void grantBrygadzistaPrivileges(MySqlConnection conn, int id)
        {
            try
            {
                conn.Open();
                string query = $"GRANT brygadzista_role TO `{id}`; SET DEFAULT ROLE ALL TO `{id}`;";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                mySqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
        private static void revokeBrygadzistaPrivileges(MySqlConnection conn, int id)
        {
            try
            {
                conn.Open();
                string query = $"REVOKE brygadzista_role FROM `{id}`; SET DEFAULT ROLE ALL TO `{id}`;";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                mySqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private static void grantKierowcaPrivileges(MySqlConnection conn, int id)
        {
            try
            {
                conn.Open();
                string query = $"GRANT kierowca_role TO `{id}`; SET DEFAULT ROLE ALL TO `{id}`;";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                mySqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
        private static void revokeKierowcaPrivileges(MySqlConnection conn, int id)
        {
            try
            {
                conn.Open();
                string query = $"REVOKE kierowca_role FROM `{id}`; SET DEFAULT ROLE ALL TO `{id}`;";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                mySqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

            switch(table)
            {
                case "administrator":
                    grantAdministratorPrivileges(conn, id);
                    break;
                case "brygadzista":
                    grantBrygadzistaPrivileges(conn, id);
                    break;
                case "kierowca":
                    grantKierowcaPrivileges(conn, id);
                    break;
                default:
                    break;
            }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

            switch (table)
            {
                case "administrator":
                    revokeAdministratorPrivileges(conn, id);
                    break;
                case "brygadzista":
                    revokeBrygadzistaPrivileges(conn, id);
                    break;
                case "kierowca":
                    revokeKierowcaPrivileges(conn, id);
                    break;
                default:
                    break;
            }
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
