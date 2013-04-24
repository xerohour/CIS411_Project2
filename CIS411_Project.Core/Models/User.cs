using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;


namespace CIS411_Project.Core.Models
{
    public class User
    {
        public class EmailAttribute : RegularExpressionAttribute
        {
            public EmailAttribute()
                : base(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}")
            {
                this.ErrorMessage = "Please provide a valid email address";
            }
        }

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
        private string passwordString;
        public string PASSWORD {

            get
            {
                return passwordString;
            }

            set
            {
                MD5 crypt = MD5.Create();
                byte[] passwordInput = System.Text.Encoding.ASCII.GetBytes(value);
                byte[] hash = crypt.ComputeHash(passwordInput);

                StringBuilder builder = new StringBuilder();
                foreach(byte hashChar in hash)
                {
                    builder.Append(hashChar.ToString("X2"));
                }

                passwordString = builder.ToString();
            }

        }

        public Nullable<decimal> REPUTATION { get; set; }

        [Required]
        [Email]
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
                string _sql = @"SELECT [USER_DISPLAYNAME] FROM [USER] " +
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