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

        #region SECTION 3 ||=======  DELETE ITEM | BY ENTITY-ID  =======||
        public static bool DeleteItem(int entityId)
        {
            int result;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteEntity", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@EntityId", entityId);
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

        #region SECTION 4 ||=======  GET ITEM | BY ENTITY-ID  =======||
        public static Entity GetItem(int entityId)
        {

            Entity tmpObj = new Entity();

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEntity", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@EntityId", entityId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (entityId > 0)
                        {
                            while (myReader.Read())
                            {
                                tmpObj = FillDataRecord(myReader);
                            }
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
            }
            return tmpObj;
        }

        #endregion

        #region SECTION 5 ||=======  SAVE ENTITY-ITEM  =======||
        public static void Save(int entityId, Entity entity)
        {
            ExecuteEnum queryId = ExecuteEnum.InsertItem;
            //int result = 0;

            if (entityId > 0)
                queryId = ExecuteEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteEntity", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (entityId > 0 )
                        myCommand.Parameters.AddWithValue("@EntityId", entityId);
                    if (entity.EntityName != null)
                        myCommand.Parameters.AddWithValue("@EntityName", entity.EntityName);
                    if (entity.Description != null)
                        myCommand.Parameters.AddWithValue("@Description", entity.Description);
                    if (entity.DisplayName != null)
                        myCommand.Parameters.AddWithValue("@DisplayName", entity.DisplayName);

                    //myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    //result = (int)myCommand.Parameters["@ReturnValue"].Value;
                }
                myConnection.Close();
            }
            //return result;
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
