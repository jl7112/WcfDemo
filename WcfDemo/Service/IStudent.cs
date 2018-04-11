using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Data;
using Common;
using Entity;

namespace Service
{
    [ServiceContract]
    public interface IStudent
    {
        [OperationContract]
         List<Student> GetInfo(string strWhere);

        [OperationContract]
         bool Add(Student model);

        [OperationContract]
         bool Update(Student model);

        [OperationContract]
         bool Delete(int id);

        [OperationContract]
        bool Exist(int id);
    }
}
