using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Token.Models;
using System.Data;
using Token.Library;

namespace Token.Repository
{
    public class AccountRepository
    {

        public static SqlConnection GetConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            var con = new SqlConnection(connectionString);
            return con;
        }
        public User GetUser(string Email, string Password)
        {
            User user = new User();
            string sql = string.Empty;
            DataTable dbResp = null;
            sql = "sproc_admin @flag='log',@UserEmail=" + Dao.FilterString(Email);
            sql += ",@Password=" + Dao.FilterString(Password);
            /* + ",@sessionId=" + Dao.FilterString(model.SessionId)*/
            
            dbResp = Dao.RunSQL(sql);




            if (dbResp.Rows.Count > 0)
            {

                user.RoleId = dbResp.Rows[0]["RoleId"].ToString();
                user.username = dbResp.Rows[0]["UserName"].ToString();
                user.RoleName = dbResp.Rows[0]["RoleName"].ToString();
                user.code = dbResp.Rows[0]["code"].ToString();
                user.message = dbResp.Rows[0]["message"].ToString();
            }
            return user;

        }

        //public Role GetRole(string id)
        //    {
        //        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        //        Role role = null;
        //        using (var con = new SqlConnection(connectionString))
        //        {
        //            con.Open();
        //            string query = "SELECT * FROM tbl_Role WHERE roleId = @RoleId";
        //            var cmd = new SqlCommand(query, con);
        //            cmd.Parameters.AddWithValue("@RoleId", id);
        //            using (var rd = cmd.ExecuteReader())
        //            {
        //                if (!rd.Read())
        //                {
        //                    con.Close();
        //                    return role;
        //                }

        //                role = new Role
        //                {
        //                    RoleId = (long)rd["roleId"],
        //                    RoleName = (string)rd["roleName"],
        //                    CreatedBy = (string)rd["createdBy"],
        //                    CreatedUTCDate = (DateTime)rd["CreatedDate"]
        //                };
        //            }
        //            con.Close();
        //        }
        //        return role;
        //    }


        }
    }