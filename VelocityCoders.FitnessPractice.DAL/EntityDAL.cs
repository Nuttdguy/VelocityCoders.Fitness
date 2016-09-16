using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VelocityCoders.FitnessPractice.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.FitnessPractice.DAL
{
    public static class EntityDAL
    {

        #region SECTION 1 ||=======  GET COLLECTION | ALL =======||
        public static EntityCollectionList GetCollection()
        {
            EntityCollectionList tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEntity", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetCollection);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tmpList = new EntityCollectionList();
                            while (myReader.Read())
                            {
                                tmpList.Add(FillDataRecord(myReader));
                            
                            }
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
            }
            return tmpList;
        }
        #endregion

        #region SECTION 2 ||=======  GET COLLECTION | BY EMAIL/ENTITY-ID =======||
        public static EntityCollectionList GetCollection(int entityId)
        {
            EntityCollectionList tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEntity", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetCollection);
                    myCommand.Parameters.AddWithValue("@EntityId", entityId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tmpList = new EntityCollectionList();
                            while (myReader.Read())
                            {
                                tmpList.Add(FillDataRecord(myReader));

                            }
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
            }
            return tmpList;
        }
        #endregion

        #region HELPER
        public static Entity FillDataRecord(IDataReader myReader)
        {
            Entity tmpObj = new Entity();
            tmpObj.EntityId = myReader.GetInt32(myReader.GetOrdinal("EntityId"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("EntityName")))
                tmpObj.EntityName = myReader.GetString(myReader.GetOrdinal("EntityName"));
            if (!myReader.IsDBNull(myReader.GetOrdinal("DisplayName")))
                tmpObj.DisplayName = myReader.GetString(myReader.GetOrdinal("DisplayName"));
            if (!myReader.IsDBNull(myReader.GetOrdinal("Description")))
                tmpObj.Description = myReader.GetString(myReader.GetOrdinal("Description"));

            return tmpObj;

        } 

        #endregion

    }
}
