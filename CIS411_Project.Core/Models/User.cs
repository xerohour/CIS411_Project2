using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;


namespace CIS411_Project.Core.Models
{
    public class User
    {
        public decimal USER_ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string USER_FNAME { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string USER_LNAME { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string USER_DISPLAYNAME { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PASSWORD { get; set; }

        public Nullable<decimal> REPUTATION { get; set; }

        [Required]
        [Display(Name = "EMail")]
        public string EMAIL { get; set; }

        public DateTime CREATED_TIMESTAMP { get; set; }

        [Display(Name = "Remember on this computer")]
        public bool RememberMe { get; set; }


        public bool IsValid(string _username, string _password)
        {
            using (var cn = new SqlConnection(@"Data Source=tfs.wesleyreisz.com;Initial Catalog=student6;" +
                   @"Persist Security Info=True;User ID=student6;Password=student6;" +
                   @"MultipleActiveResultSets=True;Application Name=EntityFramework"))
            {
                string _sql = @"SELECT [USER_DISPLAYNAME] FROM [student6].[USER] " +
                       @"WHERE [USER_DISPLAYNAME] = @u AND [PASSWORD] = @p";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = _username;
                cmd.Parameters
                    .Add(new SqlParameter("@p", SqlDbType.NVarChar))
                    .Value = _password;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
            }
        }
    }
}