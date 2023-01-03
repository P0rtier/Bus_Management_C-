﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace bd2_proj
{
    public partial class Pojazdy : UserControl
    {

        private string table;
        private MySqlConnection mySqlConnection;

        public void init(MySqlConnection mySqlConnection, string table)
        {
            this.mySqlConnection = mySqlConnection;
            this.table = table;

            updateComboBoxes();
        }

        private void updateComboBox(ComboBox cbox, string fieldName)
        {
            try
            {
                string query = "select " + fieldName + " from `mpk_bd2`.`" + table + "` group by " + fieldName + ";";
                MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = command;
                DataTable dTable = new DataTable();
                mySqlAdapter.Fill(dTable);
                cbox.DataSource = dTable;
                cbox.DisplayMember = fieldName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void updateComboBoxes()
        {
            updateComboBox(this.comboBox1, "numer_rejestracyjny");
            updateComboBox(this.comboBox2, "numer_vin");
            updateComboBox(this.comboBox3, "id_brygada");
            updateComboBox(this.comboBox4, "id_pojazd");
            updateComboBox(this.comboBox5, "maksymalna_liczba_pasażerów");
        }

        private void updateDataGrid()
        {
            try
            {
                string query = "select * from `mpk_bd2`.`" + table + "`";

                var reje = this.comboBox1.Text;
                var vin = this.comboBox2.Text;
                var bryg = this.comboBox3.Text;
                var poj = this.comboBox4.Text;
                var maks = this.comboBox5.Text;
                var date = this.dateTimePicker1;

                int count = 0;

                if (reje.Length > 0 || vin.Length > 0 || bryg.Length > 0 || poj.Length > 0 || maks.Length > 0 || date.Text.Length > 0)
                {
                    query += " where ";
                    if (reje.Length > 0)
                    {
                        query += "nazwa_przystanek=\"" + reje + "\"";
                        count++;
                    }
                    if (vin.Length > 0)
                    {
                        if (count > 0) query += " and ";
                        query += "nr_linii=" + vin;
                        count++;
                    }
                    if (bryg.Length > 0)
                    {
                        if (count > 0) query += " and ";
                        query += "nr_linii=" + bryg;
                        count++;
                    }
                    if (poj.Length > 0)
                    {
                        if (count > 0) query += " and ";
                        query += "nr_linii=" + poj;
                        count++;
                    }
                    if (maks.Length > 0)
                    {
                        if (count > 0) query += " and ";
                        query += "nr_linii=" + maks;
                        count++;
                    }
                    if (date.Text.Length > 0)
                    {
                        if (count > 0) query += " and ";
                        query += "data_odjazdu >= '" + date.Text + "'";
                        count++;
                    }
                }

                query += ";";
                MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter();
                mySqlAdapter.SelectCommand = command;
                DataTable dTable = new DataTable();
                mySqlAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Pojazdy()
        {
            InitializeComponent();
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd hh:mm:ss";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateDataGrid();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
