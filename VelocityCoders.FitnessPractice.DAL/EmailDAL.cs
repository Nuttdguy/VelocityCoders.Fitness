using System;
using System.Data;
using System.Data.SqlClient;
using VelocityCoders.FitnessPractice.Models;

namespace VelocityCoders.FitnessPractice.DAL
{
    public class EmailDAL
    {

        #region GET_ITEM
        public static Email GetItem(int emailId)
        {
            Email tmpItem = null;

            using (SqlConnection myConnect = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEmail", myConnect))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetItem);
                    myCommand.Parameters.AddWithValue("@EmailId", emailId);

                    myConnect.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        tmpItem = new Email();
                        if (myReader.Read())
                        {
                            tmpItem = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                }
            }
            return tmpItem;
        }
        #endregion

        #region GET_COLLECTION
        public static Email GetCollection()
        {
            Email tmpList = null;
            // variable instantiation is required for scope/access o
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEmail", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetCollection);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if(myReader.HasRows)
                        {
                            tmpList = new Email();
                            while (myReader.Read())
                            {
                                tmpList.Add(FillDataRecord(myReader));
                            }
                        }
                        
                        myReader.Close();
                    }
                }
            }
            return tmpList;
        }
        #endregion

        #region HELPER METHOD | CREATE OBJECT FOR EACH ROW AND RETURN ITS VALUE TO ADD TO LIST TMPLIST
        public static Email FillDataRecord(IDataReader myDataReader)
        {
            Email myEmailObject = new Email();
            myEmailObject.EmailId = myDataReader.GetInt32(myDataReader.GetOrdinal("EmailId"));

            if (!myDataReader.IsDBNull(myDataReader.GetOrdinal("EntityTypeId")))
                myEmailObject.EntityTypeId = myDataReader.GetInt32(myDataReader.GetOrdinal("EntityTypeId"));
            if (!myDataReader.IsDBNull(myDataReader.GetOrdinal("InstructorId")))
                myEmailObject.InstructorId = myDataReader.GetInt32(myDataReader.GetOrdinal("InstructorId"));
            if (!myDataReader.IsDBNull(myDataReader.GetOrdinal("EmailAddress")))
                myEmailObject.EmailAddress = myDataReader.GetString(myDataReader.GetOrdinal("EmailAddress"));
            if (!myDataReader.IsDBNull(myDataReader.GetOrdinal("Description")))
                myEmailObject.Description = myDataReader.GetString(myDataReader.GetOrdinal("Description"));

            return myEmailObject;

        }
        #endregion
    }
}
