using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataLog
/// </summary>
public class DataLog
{

    #region Method AddLog
    public int AddLog(int action,string message,string param)
    {
        try
        {
            dynamic parameters = new ExpandoObject();

            parameters.message = message;

            DataSQL data = new DataSQL("tblLog");

            data["LogAction"] = action;
            data["LogMessage"] = JsonConvert.SerializeObject(parameters);
            data["LogParam"] = param;

            return (int)data.setData();
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
    #endregion

    #region Method AddLog
    public int AddLog(int action, dynamic message, string param)
    {
        try
        {
            DataSQL data = new DataSQL("tblLog");

            data["LogAction"] = action;
            data["LogMessage"] = JsonConvert.SerializeObject(message);
            data["LogParam"] = param;

            return (int)data.setData();
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
    #endregion

    #region Method GetLogById
    public DataRow GetLogById(int id)
    {
        try
        {
            DataSQL data = new DataSQL("tblLog");

            return data.GetItem(id);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    #endregion



}