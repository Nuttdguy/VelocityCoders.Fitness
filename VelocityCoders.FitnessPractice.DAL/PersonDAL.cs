using System;
using System.Data;
using System.Data.SqlClient;
using VelocityCoders.FitnessPractice.Models;

namespace VelocityCoders.FitnessPractice.DAL
{
    public class PersonDAL
    {
        #region GET_ITEM
        public static Person GetItem(int personId)
        {
            Person tmpItem = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetPerson", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetItem);
                    myCommand.Parameters.AddWithValue("@PersonId", personId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if(myReader.Read())
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
        public static PersonCollection GetCollection()
        {
            PersonCollection tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetPerson", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetCollection);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if(myReader.HasRows)
                        {
                            tmpList = new PersonCollection();
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

        #region
        public static Person FillDataRecord(IDataRecord myDataRecord)
        {
            Person myPersonObject = new Person();
            myPersonObject.personId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("PersonId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FirstName")))
                myPersonObject.firstName = myDataRecord.GetString(myDataRecord.GetOrdinal("FirstName"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LastName")))
                myPersonObject.lastName = myDataRecord.GetString(myDataRecord.GetOrdinal("LastName"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DisplayFirstName")))
                myPersonObject.displayFirstName = myDataRecord.GetString(myDataRecord.GetOrdinal("DisplayFirstName"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Gender")))
                myPersonObject.gender = myDataRecord.GetString(myDataRecord.GetOrdinal("Gender"));

            return myPersonObject;
        } 

        #endregion

    }
}
