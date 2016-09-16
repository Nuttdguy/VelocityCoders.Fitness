using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VelocityCoders.FitnessPractice.Models;

namespace VelocityCoders.FitnessPractice.DAL
{
    public class EmailAddressDAL
    {

        #region DELETE
        public static bool Delete(int emailId)
        {
            int result;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteEmail", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", (int)QueryExecuteType.DeleteItem);
                    myCommand.Parameters.AddWithValue("@EmailId", emailId);
                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    result = (int)myCommand.Parameters["@ReturnValue"].Value;
                }
                myConnection.Close();
            }
            return result > 0;

        }

        #endregion

        #region INSERT OR UPDATE
        public static int Save(int instructorId, EmailAddress emailToSave)
        {
            int result = 0;
            QueryExecuteType queryId = QueryExecuteType.InsertItem;

            if (emailToSave.EmailId > 0)
                queryId = QueryExecuteType.UpdateItemByEmailId;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteEmail", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@EmailId", emailToSave.EmailId);
                    myCommand.Parameters.AddWithValue("@InstructorId", instructorId);
                    myCommand.Parameters.AddWithValue("@EntityTypeId", emailToSave.EmailType.EntityTypeId);

                    if (emailToSave.EmailValue != null)
                        myCommand.Parameters.AddWithValue("@EmailAddress", emailToSave.EmailValue.ToString());

                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    result = (int)myCommand.Parameters["@ReturnValue"].Value;

                }
                myConnection.Close();
            }
            return result;
        }


        #endregion


        #region

        public static EmailAddress GetItem(int emailId)
        {
            EmailAddress tempItem = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEmail", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", (int)QuerySelectType.GetItemByEmailId);
                    myCommand.Parameters.AddWithValue("@EmailId", emailId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if(myReader.Read())
                        {
                            tempItem = FillDataRecordAddress(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
            }
            return tempItem;
        }

        #endregion


        #region GET COLLECTION OF EMAIL ADDRESSES

        public static EmailAddressCollection GetCollection(int instructorId)
        {
            EmailAddressCollection tempList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEmail", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetCollectionByInstructor);
                    myCommand.Parameters.AddWithValue("@InstructorId", instructorId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new EmailAddressCollection();
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecordAddress(myReader));
                            }
                        }
                    }
                }
            }
            return tempList;
        }

        #endregion


        #region HELPER METHOD | EMAIL ADDRESS
        public static EmailAddress FillDataRecordAddress(IDataReader myDataReader)
        {
            EmailAddress myEmailObject = new EmailAddress();
            myEmailObject.EmailId = myDataReader.GetInt32(myDataReader.GetOrdinal("EmailId"));

            if (!myDataReader.IsDBNull(myDataReader.GetOrdinal("EmailValue")))
                myEmailObject.EmailValue = myDataReader.GetString(myDataReader.GetOrdinal("EmailValue"));

            if (!myDataReader.IsDBNull(myDataReader.GetOrdinal("EntityTypeId")))
            {
                myEmailObject.EmailType.EntityTypeId = myDataReader.GetInt32(myDataReader.GetOrdinal("EntityTypeId"));

                if (!myDataReader.IsDBNull(myDataReader.GetOrdinal("EntityTypeName")))
                    myEmailObject.EmailType.EntityTypeName = myDataReader.GetString(myDataReader.GetOrdinal("EntityTypeName"));
            }

            return myEmailObject;
        }

        #endregion
    }
}
