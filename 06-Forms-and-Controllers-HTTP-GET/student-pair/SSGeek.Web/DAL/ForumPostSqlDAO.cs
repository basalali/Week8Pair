using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SSGeek.Web.Models;

namespace SSGeek.Web.DAL
{
    public class ForumPostSqlDAO : IForumPostDAO
    {
        private readonly string connectionString;

        public ForumPostSqlDAO(string connectionString)
        {

            this.connectionString = connectionString;
        }

        public IList<ForumPost> GetAllPosts()
        {
            IList<ForumPost> post = new List<ForumPost>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT * FROM forum_post";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ForumPost forum = new ForumPost();

                        forum.Id = Convert.ToInt32(reader["id"]);
                        forum.UserName = Convert.ToString(reader["username"]);
                        forum.Subject = Convert.ToString(reader["subject"]);
                        forum.Message = Convert.ToString(reader["message"]);
                        forum.PostDate = Convert.ToDateTime(reader["post_date"]);

                        post.Add(forum);

                    }

                }
            }


            catch (SqlException ex)
            {

                post = new List<ForumPost>();
                    
            }
            return post;
        }

        public bool SaveNewPost(ForumPost post)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();

                    string sql = @"INSERT INTO forum_post (username, subject, message) VALUES (@username, @subject, @message);";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue(@"username", post.UserName);
                    cmd.Parameters.AddWithValue(@"subject", post.Subject);
                    cmd.Parameters.AddWithValue(@"message", post.Message);

                    cmd.ExecuteNonQuery();

                }
                return result;
            }

            catch (SqlException ex)
            {

                throw ex;
            }

        }
    }
}


