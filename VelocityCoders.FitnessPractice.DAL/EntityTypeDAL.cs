using System.Data;
using System.Data.SqlClient;
using VelocityCoders.FitnessPractice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.FitnessPractice.DAL
{
    public class EntityTypeDAL
    {

        #region GET_ITEM
        public static EntityType GetItem(int entityTypeId)
        {
            EntityType tmpItem = null;

            using (SqlConnection myConnect = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEntityType", myConnect))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetItem);
                    myCommand.Parameters.AddWithValue("@EntityTypeId", entityTypeId);

                    myConnect.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        tmpItem = new EntityType();
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
        public static EntityType GetCollection()
        {
            EntityType tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEntityType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetCollection);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if(myReader.HasRows)
                        {
                            tmpList = new EntityType();
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

        #region HELPER METHOD
        public static EntityType FillDataRecord(IDataReader myDataRecord)
        {
            EntityType myObject = new EntityType();
            myObject.EntityTypeId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EntityTypeId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EntityId")))
                myObject.EntityId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EntityId"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Description")))
                myObject.Description = myDataRecord.GetString(myDataRecord.GetOrdinal("Description"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DisplayName")))
                myObject.DisplayName = myDataRecord.GetString(myDataRecord.GetOrdinal("DisplayName"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EntityTypeName")))
                myObject.EntityTypeName = myDataRecord.GetString(myDataRecord.GetOrdinal("EntityTypeName"));

            return myObject;
        }
        #endregion

    }
}
