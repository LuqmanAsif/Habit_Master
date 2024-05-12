using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Habit_Master.Models
{
    public class DBManager
    {
         string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public List<Habit_> GetHabits()
        {
            try
            {
                List<Habit_> myhabits = new List<Habit_>();
                string query = "select * from HabitMaster";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Habit_ habit = new Habit_();
                    habit.Habit_Id = int.Parse(sdr[0].ToString());
                    habit.Habit_Description = sdr[1].ToString();
                    habit.Habit_Check = bool.Parse(sdr[2].ToString());
                    myhabits.Add(habit);

                }
                sdr.Close();
                con.Close();
                return myhabits;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void SaveHabit(Habit_ h)
        {
            try
            {
                string query = "insert into HabitMaster (Habit_Description,Habit_Check) values ('" + h.Habit_Description + "','" + h.Habit_Check + "')";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public Habit_ Gethabit(int habit_id)
        {
            try
            {
                Habit_ habit = new Habit_();
                string query = "select * from HabitMaster where Habit_Id='"+habit_id+"'";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    
                    habit.Habit_Id = int.Parse(sdr[0].ToString());
                    habit.Habit_Description = sdr[1].ToString();
                    habit.Habit_Check = bool.Parse(sdr[2].ToString());
                }
                sdr.Close();
                con.Close();
                return habit;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public void Update(int habit_id, Habit_ habit)
        {
            try
            {
                string query = "update HabitMaster set Habit_Description='"+habit.Habit_Description+ "',Habit_Check='"+habit.Habit_Check+ "' where Habit_Id='"+habit_id+"'";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public void Update_HabitCheck(int habit_id,bool check)
        {
            try
            {
                string query = "update HabitMaster set Habit_Check='" + check + "' where Habit_Id='" + habit_id + "'";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public void Delete_Habit(int habit_id)
        {
            try
            {
                string query = "delete * from HabitMaster where Habit_Id='" + habit_id + "'";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}